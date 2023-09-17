using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using NBA_Basketball.Entities;
using NBA_Basketball.Entities.Models;
using NBA_Basketball.Models;

namespace NBA_Basketball.AllPages.EventAdminPages;

public partial class ManageTeamsPage : Page
{
    public ManageTeamsPage()
    {
        InitializeComponent();

        allTeams = DB.entities.Teams.Include(c => c.Division).Include(c => c.Division.Conference).ToList();

        List<string> conferenceList = new List<string>() { "All" };
        conferenceList.AddRange(DB.entities.Conferences.Select(c => c.Name).ToList());
        ConferenceComboBox.ItemsSource = conferenceList;
        ConferenceComboBox.SelectedIndex = 0;

        List<string> divisionList = new List<string>() { "All" };
        divisionList.AddRange(DB.entities.Divisions.Select(c => c.Name).ToList());
        DivisionComboBox.ItemsSource = divisionList;
        DivisionComboBox.SelectedIndex = 0;
    }

    private List<Team> allTeams;
    private List<TeamPartial> _teams;

    private void LoadTeamData(List<Team> teams)
    {
        _teams = new List<TeamPartial>();
        TeamPartial teamPartial;
        int seasonId = DB.entities.Seasons.ToList().Last().SeasonId;

        foreach (Team team in teams)
        {
            int sum = 0;
            foreach (var playerInTeam in DB.entities.PlayerInTeams.Where(c => c.SeasonId == seasonId && c.TeamId == team.TeamId).ToList())
                sum += Convert.ToInt32(playerInTeam.Salary);
            teamPartial = new TeamPartial(team.TeamName, team.Division.Conference.Name, team.Division.Name, team.Coach, sum, team.LogoImage);
            _teams.Add(teamPartial);
        }
    }

    private void DataGridUpdate()
    {
        if (ConferenceComboBox.SelectedItem == null || DivisionComboBox.SelectedItem == null)
            return;

        if (ConferenceComboBox.SelectedIndex == 0 && DivisionComboBox.SelectedIndex == 0)
            LoadTeamData(allTeams.Where(c => c.TeamName.ToLower().Contains(SearchTextBox.Text.ToLower())).ToList());

        if (ConferenceComboBox.SelectedIndex != 00 && DivisionComboBox.SelectedIndex == 0)
            LoadTeamData(allTeams.Where(c =>
                c.Division.Conference.Name == ConferenceComboBox.SelectedItem.ToString() &&
                c.TeamName.ToLower().Contains(SearchTextBox.Text.ToLower())).ToList());
        if (ConferenceComboBox.SelectedIndex == 0 && DivisionComboBox.SelectedIndex != 0)
            LoadTeamData(allTeams.Where(c =>
                c.Division.Name == DivisionComboBox.SelectedItem.ToString() && c.TeamName.ToLower().Contains(SearchTextBox.Text.ToLower())).ToList());
        if (ConferenceComboBox.SelectedIndex != 0 && DivisionComboBox.SelectedIndex != 0)
            LoadTeamData(allTeams.Where(c =>
                c.Division.Name == DivisionComboBox.SelectedItem.ToString() && c.TeamName.ToLower().Contains(SearchTextBox.Text.ToLower()) &&
                c.Division.Conference.Name == ConferenceComboBox.SelectedItem.ToString()).ToList());

        TeamDataGrid.ItemsSource = _teams;
        TotalTeamsTextBlock.Text = "Total teams: " + _teams.Count;
    }

    private void ConferenceComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e) => DataGridUpdate();

    private void DivisionComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e) => DataGridUpdate();

    private void SearchTextBox_OnTextChanged(object sender, TextChangedEventArgs e) => DataGridUpdate();

    private void AddButton_OnClick(object sender, RoutedEventArgs e) => 
        MessageBox.Show("The feature would be a future add-on to the current system.",
        "Add a new team - Future Add-on", MessageBoxButton.OK, MessageBoxImage.Information);
}