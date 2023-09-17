using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using NBA_Basketball.Entities;
using NBA_Basketball.Entities.Models;
using NBA_Basketball.Models;

namespace NBA_Basketball.AllPages.EventAdminPages;

public partial class MatchupAddPage : Page
{
    public MatchupAddPage()
    {
        InitializeComponent();
        SeasonTextBlock.Text = DB.entities.Seasons.ToList().Last().Name;
        _teams = DB.entities.Teams.ToList();

        TeamAwayComboBox.ItemsSource = _teams;
        TeamHomeComboBox.ItemsSource = _teams;
    }

    private List<Team> _teams;
    private List<Team> tempList;

    private void AddButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            Season season = DB.entities.Seasons.ToList().Last();
            MatchupType matchupType = DB.entities.MatchupTypes.First(c => c.MatchupTypeId == 1);

            DateTime dateTime = new DateTime(2016, 01, 01, 00, 00, 00);
            if (DateTimePicker.Value != null && TeamAwayComboBox.SelectedItem != null && TeamHomeComboBox.SelectedItem != null)
            {
                if (DateTimePicker.Value < dateTime)
                {
                    MessageBox.Show("It is not possible to schedule a match before the start of the season");
                    return;
                }

                if (teamAway == teamHome)
                {
                    MessageBox.Show("Teams cannot be the same");
                    return;
                }

                Matchup matchup = new Matchup
                {
                    Season = season,
                    MatchupType = matchupType,
                    StartTime = (DateTime)DateTimePicker.Value,
                    Location = LocationTextBox.Text,
                    TeamAwayNavigation = teamAway,
                    TeamHomeNavigation = teamHome,
                    TeamAwayScore = 0,
                    TeamHomeScore = 0
                };
                DB.entities.Add(matchup);
                DB.entities.SaveChanges();
                NavigationService.Navigate(new ManageMatchupsPage());
            }
            else
                MessageBox.Show("Fields cannot be empty");
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
        }
    }

    private Team teamAway;
    private Team teamHome;

    private void TeamAwayComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e) => teamAway = (Team)TeamAwayComboBox.SelectedItem;

    private void TeamHomeNavigation_OnSelectionChanged(object sender, SelectionChangedEventArgs e) => teamHome = (Team)TeamHomeComboBox.SelectedItem;
}