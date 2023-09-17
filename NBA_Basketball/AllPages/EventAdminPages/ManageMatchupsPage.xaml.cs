using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using NBA_Basketball.Entities;
using NBA_Basketball.Entities.Models;
using NBA_Basketball.Models;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace NBA_Basketball.AllPages.EventAdminPages;

public partial class ManageMatchupsPage : Page
{
    public ManageMatchupsPage()
    {
        InitializeComponent();
        
        _matchups = DB.entities.Matchups.Include(c => c.Season).Include(c => c.MatchupType).Include(c => c.TeamAwayNavigation)
            .Include(c => c.TeamHomeNavigation).OrderBy(c=>c.StartTime).ToList();
        
        PreseasonButton.IsEnabled = false;
        SeasonComboBox.ItemsSource = DB.entities.Seasons.ToList();
    }

    private List<Matchup> _matchups;

    private void UpdateButton_OnClick(object sender, RoutedEventArgs e) =>
        MessageBox.Show("The feature would be a future add-on to the current system.", "Update Matchup - Future Add-on", MessageBoxButton.OK,
            MessageBoxImage.Information);

    private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
    {
        Matchup matchup = (Matchup)((Button)sender).DataContext;
        DB.entities.Matchups.Remove(matchup);
        DB.entities.SaveChanges();
        _matchups.Remove(matchup);
        
        UpdateCall();
    }

    private void DateCheckBox_OnChecked(object sender, RoutedEventArgs e)
    {
            MatchDatePicker.IsEnabled = true;
            string startDate = "Jan 01 " + ((Season)SeasonComboBox.SelectedItem).Name.Split("-")[0];
            string endDate = "Dec 31 " + ((Season)SeasonComboBox.SelectedItem).Name.Split("-")[1];
        
            MatchDatePicker.DisplayDateStart = DateTime.Parse(startDate); 
            MatchDatePicker.DisplayDateEnd = DateTime.Parse(endDate);
    }

    private void UpdateCall()
    {
        if (PreseasonButton.IsEnabled)
            DataGridUpdate(_matchups.Where(c => c.MatchupTypeId == 1).ToList());
        else
            DataGridUpdate(_matchups.Where(c => c.MatchupTypeId != 1).ToList());
    }
    
    private void DataGridUpdate(List<Matchup> matchups)
    {
        if (DateCheckBox.IsChecked == true)
            MatchupDataGrid.ItemsSource = matchups.Where(c =>
                c.SeasonId == ((Season)SeasonComboBox.SelectedItem).SeasonId && c.DateStart == MatchDatePicker.SelectedDate.ToString()).ToList();
        else
            MatchupDataGrid.ItemsSource = matchups.Where(c => c.SeasonId == ((Season)SeasonComboBox.SelectedItem).SeasonId).ToList();
    }

    private void MatchDatePicker_OnSelectedDateChanged(object? sender, SelectionChangedEventArgs e) => UpdateCall();

    private void SeasonComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (SeasonComboBox.SelectedItem == null)
            return;

        UpdateCall();
    }

    private void PreseasonButton_OnClick(object sender, RoutedEventArgs e)
    {
        PreseasonButton.IsEnabled = false;
        RegularButton.IsEnabled = true;
        DataGridUpdate(_matchups.Where(c => c.MatchupTypeId != 1).ToList());
        AddButton.Visibility = Visibility.Hidden;
        ExportButton.Visibility = Visibility.Hidden;
    }

    private void RegularButton_OnClick(object sender, RoutedEventArgs e)
    {
        PreseasonButton.IsEnabled = true;
        RegularButton.IsEnabled = false;
        AddButton.Visibility = Visibility.Visible;
        ExportButton.Visibility = Visibility.Visible;
        DataGridUpdate(_matchups.Where(c => c.MatchupTypeId == 1).ToList());
    }

    private void DateCheckBox_OnUnchecked(object sender, RoutedEventArgs e)
    {
        MatchDatePicker.IsEnabled = false;
        UpdateCall();
    }

    private void AddButton_OnClick(object sender, RoutedEventArgs e) => NavigationService.Navigate(new MatchupAddPage());

    private void ExportButton_OnClick(object sender, RoutedEventArgs e)
    {
        IWorkbook workbook = new XSSFWorkbook();
        ISheet sheet = workbook.CreateSheet("Sheet1");
        IRow row = sheet.CreateRow(0);

        for (int i = 0; i < MatchupDataGrid.Columns.Count-2; i++)
        {
            var column = MatchupDataGrid.Columns[i];
            row.CreateCell(i).SetCellValue(column.Header.ToString());
        }

        for (int i = 1; i < _matchups.Count; i++)
        {
            row = sheet.CreateRow(i);
            int count = 0;
            row.CreateCell(count++).SetCellValue(_matchups[i-1].DateStart);
            row.CreateCell(count++).SetCellValue(_matchups[i-1].TeamAwayNavigation.TeamName);
            row.CreateCell(count++).SetCellValue(_matchups[i-1].TeamHomeNavigation.TeamName);
            row.CreateCell(count++).SetCellValue(_matchups[i-1].TimeStart);
            row.CreateCell(count++).SetCellValue(_matchups[i-1].Location);
            row.CreateCell(count++).SetCellValue(_matchups[i-1].StatusName);
        }

        try
        {
            using (FileStream stream = new FileStream("Matchups.xlsx",FileMode.Create))
            {
                workbook.Write(stream);
            }

            Process.Start("explorer.exe", "Matchups.xlsx");
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
        }
    }
}