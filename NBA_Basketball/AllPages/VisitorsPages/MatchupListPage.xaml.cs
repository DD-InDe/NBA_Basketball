using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using NBA_Basketball.Entities;
using NBA_Basketball.Entities.Models;

namespace NBA_Basketball.AllPages.VisitorsPages;

public partial class MatchupListPage : Page
{
    public MatchupListPage()
    {
        InitializeComponent();
        try
        {
            matchupList = DB.entities.Matchups.Include(c => c.TeamAwayNavigation).Include(c => c.TeamHomeNavigation)
                .ToList();

            MatchDatePicker.DisplayDateStart = matchupList.Select(c => c.StartTime.Date).First();
            MatchDatePicker.DisplayDateEnd = matchupList.Select(c => c.StartTime.Date).Last();

            MatchDatePicker.SelectedDate = matchupList.Where(c => c.Status == 0 || c.Status == -1)
                .Select(c => c.StartTime.Date).ToList().First();

            List<Matchup> tempList = matchupList
                .Where(c => c.StartTime.Date == ((DateTime)MatchDatePicker.SelectedDate).Date).ToList();
            ContentLoad(tempList);
        }
        catch (Exception exc)
        {
            MessageBox.Show(exc.Message);
        }
    }

    private List<Matchup> matchupList;

    private void BackButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            MatchDatePicker.SelectedDate = MatchDatePicker.SelectedDate.Value.AddDays(-1);
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
        }
    }

    private void NextButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            MatchDatePicker.SelectedDate = MatchDatePicker.SelectedDate.Value.AddDays(1);
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
        }
    }

    private void MatchDatePicker_OnSelectedDateChanged(object sender, SelectionChangedEventArgs e)
    {
        try
        {
            List<Matchup> matchupsListView =
                matchupList.Where(c => c.StartTime.Date == MatchDatePicker.SelectedDate).ToList();

            if (matchupsListView.Count != 0)
                ContentLoad(matchupsListView);
            else
            {
                LastMatchStackPanel.Visibility = Visibility.Hidden;
                MatchesDataGrid.Visibility = Visibility.Hidden;
                DataTextBlock.Visibility = Visibility.Visible;
            }
        }
        catch (Exception exc)
        {
            MessageBox.Show(exc.Message);
        }
    }

    private void ContentLoad(List<Matchup> matchupsListView)
    {
        MatchesDataGrid.Visibility = Visibility.Visible;
        LastMatchStackPanel.Visibility = Visibility.Visible;
        DataTextBlock.Visibility = Visibility.Hidden;
        matchupsListView = matchupsListView.OrderBy(c => c.TimeStart).ToList();

        MatchesDataGrid.ItemsSource = matchupsListView;

        List<Matchup> tempList = matchupsListView.Where(c => c.Status == 0).ToList(); // running
        if (tempList.Count != 0)
            LastMatchStackPanel.DataContext = tempList.First();
        else
        {
            tempList = matchupsListView.Where(c => c.Status == -1).ToList(); // not started 
            if (tempList.Count != 0)
                LastMatchStackPanel.DataContext = tempList.First();
            else
            {
                tempList = matchupsListView.Where(c => c.Status == 1).ToList();
                LastMatchStackPanel.DataContext = tempList.Last();
            }
        }
    }

    private void ViewButton_OnClick(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new MatchupDetailPage(((Matchup)((Button)sender).DataContext).MatchupId));
    }
}