using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.EntityFrameworkCore;
using NBA_Basketball.Entities;
using NBA_Basketball.Models;

namespace NBA_Basketball.AllPages.VisitorsPages;

public partial class PlayersMainPage : Page
{
    public PlayersMainPage()
    {
        InitializeComponent();

        try
        {
            playerInTeamsList = DB.entities.PlayerInTeams.Include(c => c.Player).Include(c => c.Team)
                .Include(c => c.Player.CountryCodeNavigation).Include(c => c.Player.Position).ToList();

            List<string> teamList = new List<string>() { "all" };
            foreach (var item in DB.entities.Teams)
                teamList.Add(item.TeamName);
            SeasonComboBox.ItemsSource = DB.entities.Seasons.ToList();
            TeamComboBox.ItemsSource = teamList;

            ListSorting();
            PlayerDataGrid.ItemsSource = listOfVisibleLists[currentPage];
            CurrentPageTextBox.Text = Convert.ToString(currentPage + 1);
            RecordsInOnePage.Text = listOfVisibleLists[currentPage].Count.ToString();
        }
        catch (Exception exc)
        {
            MessageBox.Show(exc.Message);
        }
    }

    private string check = "ALL";
    private int pages;
    private int currentPage;
    private List<PlayerInTeam> playerInTeamsList;
    private List<List<PlayerInTeam>> listOfVisibleLists;
    private List<PlayerInTeam> visiblePlayersList;
    private List<PlayerInTeam> tempList;

    private void ListSorting()
    {
        try
        {
            currentPage = 0;
            listOfVisibleLists = new List<List<PlayerInTeam>>();

            if (check != "ALL" && TeamComboBox.SelectedIndex == 0)
                tempList = playerInTeamsList.Where(c =>
                    c.Player.Name.StartsWith(check) && c.SeasonId == ((Season)SeasonComboBox.SelectedItem).SeasonId &&
                    c.Player.Name.ToLower().Contains(SearchTextBox.Text.ToLower())).ToList();
            if (check != "ALL" && TeamComboBox.SelectedIndex != 0)
                tempList = playerInTeamsList.Where(c =>
                    c.Player.Name.StartsWith(check) && c.SeasonId == ((Season)SeasonComboBox.SelectedItem).SeasonId &&
                    c.Team.Abbr == TeamComboBox.SelectedItem.ToString() &&
                    c.Player.Name.ToLower().Contains(SearchTextBox.Text.ToLower())).ToList();
            if (check == "ALL" && TeamComboBox.SelectedIndex == 0)
                tempList = playerInTeamsList.Where(c =>
                    c.SeasonId == ((Season)SeasonComboBox.SelectedItem).SeasonId &&
                    c.Player.Name.ToLower().Contains(SearchTextBox.Text.ToLower())).ToList();
            if (check == "ALL" && TeamComboBox.SelectedIndex != 0)
                tempList = playerInTeamsList.Where(c =>
                    c.SeasonId == ((Season)SeasonComboBox.SelectedItem).SeasonId &&
                    c.Team.TeamName == TeamComboBox.SelectedItem.ToString() &&
                    c.Player.Name.ToLower().Contains(SearchTextBox.Text.ToLower())).ToList();

            TotalRecordsTextBlock.Text = tempList.Count().ToString();
            ListUpdate();
        }
        catch (Exception exc)
        {
            MessageBox.Show(exc.Message);
        }
    }

    private void ListUpdate()
    {
        if (tempList.Count % 10 == 0)
            pages = tempList.Count / 10;
        else
            pages = tempList.Count / 10 + 1;
        
        for (int i = 0; i < pages; i++)
        {
            visiblePlayersList = new List<PlayerInTeam>();
            for (int j = 0; j < 10; j++)
            {
                if (j + i * 10 <= tempList.Count - 1)
                    visiblePlayersList.Add(tempList[j + i * 10]);
                else
                    break;
            }

            NumberOfPagesTextBlock.Text = pages.ToString();
            listOfVisibleLists.Add(visiblePlayersList);
        }
    }

    private void DataGridUpdate()
    {
        if (listOfVisibleLists.Count != 0)
        {
        PlayerDataGrid.ItemsSource = listOfVisibleLists[currentPage];
        CurrentPageTextBox.Text = Convert.ToString(currentPage + 1);
        RecordsInOnePage.Text = listOfVisibleLists[currentPage].Count.ToString();
        }
        else
        {
            PlayerDataGrid.ItemsSource = null;
            CurrentPageTextBox.Text = Convert.ToString(currentPage + 1);
            RecordsInOnePage.Text = "0";            
        }
    }
    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        foreach (var button in AlphabetStackPanel.Children)
            ((Button)button).Background = Brushes.Transparent;
        currentPage = 0;
        ((Button)sender).Background = Brushes.LightGray;
        check = ((Button)sender).Content.ToString();
        ListSorting();
        DataGridUpdate();
    }

    private void FirstPageButton_OnClick(object sender, RoutedEventArgs e)
    {
        currentPage = 0;
        ListUpdate();
        DataGridUpdate();
    }

    private void NextPageButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (currentPage < pages - 1)
        {
            currentPage++;
            ListUpdate();
            DataGridUpdate();
        }
    }

    private void PreviousPageButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (currentPage > 0)
        {
            currentPage--;
            ListUpdate();
            DataGridUpdate();
        }
    }

    private void LastPageButton_OnClick(object sender, RoutedEventArgs e)
    {
        currentPage = pages - 1;
        ListUpdate();
        DataGridUpdate();
    }

    private void SeasonComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (TeamComboBox.SelectedItem != null)
        {
            ListSorting();
            DataGridUpdate();
        }
    }

    private void TeamComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (SeasonComboBox.SelectedItem != null)
        {
            ListSorting();
            DataGridUpdate();
        }
    }

    private void SearchTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        if (TeamComboBox.SelectedItem != null && SeasonComboBox.SelectedItem != null)
        {
            ListSorting();
            DataGridUpdate();
        }
    }

    private void CurrentPageTextBox_OnPreviewTextInput(object sender, TextCompositionEventArgs e) => e.Handled = "0123456789".IndexOf(e.Text) < 0;

    private void CurrentPageTextBox_OnKeyUp(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            if (Convert.ToInt32(CurrentPageTextBox.Text) < 1 || Convert.ToInt32(CurrentPageTextBox.Text) > pages)
                CurrentPageTextBox.Text = Convert.ToString(currentPage + 1);
            else
            {
                currentPage = Convert.ToInt32(CurrentPageTextBox.Text);
                PlayerDataGrid.ItemsSource = listOfVisibleLists[currentPage];
                RecordsInOnePage.Text = listOfVisibleLists[currentPage].Count.ToString();
            }
        }
    }

    private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        NavigationService.Navigate(new PlayerDetailPage(((PlayerInTeam)((Image)sender).DataContext).PlayerId));
    }
}