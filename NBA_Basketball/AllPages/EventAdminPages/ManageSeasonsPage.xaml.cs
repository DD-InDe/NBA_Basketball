using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using NBA_Basketball.Entities;
using NBA_Basketball.Entities.Models;

namespace NBA_Basketball.AllPages.EventAdminPages;

public partial class ManageSeasonsPage : Page
{
    public ManageSeasonsPage()
    {
        InitializeComponent();

        _matchups = DB.entities.Matchups.Include(c => c.Season).Include(c => c.MatchupType).Include(c => c.TeamAwayNavigation)
            .Include(c => c.TeamHomeNavigation).ToList();
        List<string> seasonNamesList = new List<string>() { "All" };
        seasonNamesList.AddRange(DB.entities.Seasons.Select(c => c.Name).ToList());
        SeasonComboBox.ItemsSource = seasonNamesList;
        List<string> matchupTypeList = new List<string>() { "All" };
        matchupTypeList.AddRange(DB.entities.MatchupTypes.Select(c => c.Name).ToList());
        MatchupTypeComboBox.ItemsSource = matchupTypeList;
    }

    private List<Matchup> _matchups;
    private List<Matchup> selectedMatchups;

    private void SeasonComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e) => SeasonDataUpdate();

    private void MatchupTypeComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e) => SeasonDataUpdate();

    private void SeasonDataUpdate()
    {
        MatchupsDataGrid.ItemsSource = null;
        if (SeasonComboBox.SelectedItem == null || MatchupTypeComboBox.SelectedItem == null)
            return;
        if (SeasonComboBox.SelectedIndex == 0 && MatchupTypeComboBox.SelectedIndex == 0)
            SeasonsDataGrid.ItemsSource = _matchups;
        if (SeasonComboBox.SelectedIndex != 0 && MatchupTypeComboBox.SelectedIndex == 0)
            SeasonsDataGrid.ItemsSource = _matchups.Where(c => c.Season.Name == SeasonComboBox.SelectedItem.ToString()).ToList();
        if (SeasonComboBox.SelectedIndex == 0 && MatchupTypeComboBox.SelectedIndex != 0)
            SeasonsDataGrid.ItemsSource = _matchups.Where(c => c.MatchupType.Name == MatchupTypeComboBox.SelectedItem.ToString()).ToList();
        if (SeasonComboBox.SelectedIndex != 0 && MatchupTypeComboBox.SelectedIndex != 0)
            SeasonsDataGrid.ItemsSource = _matchups.Where(c => c.Season.Name == SeasonComboBox.SelectedItem.ToString() && 
                                                               c.MatchupType.Name == MatchupTypeComboBox.SelectedItem.ToString()).ToList();
    }

    private void SeasonsDataGrid_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        selectedMatchups = new List<Matchup>();
        var d = SeasonsDataGrid.SelectedItems;
        foreach (Matchup item in d)
            selectedMatchups.Add(item);
        MatchupsDataGrid.ItemsSource = selectedMatchups;
    }
}