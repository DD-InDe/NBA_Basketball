using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using NBA_Basketball.Entities;
using NBA_Basketball.Entities.Models;
using NBA_Basketball.Models;

namespace NBA_Basketball.AllPages.VisitorsPages;

public partial class TeamDetailPage : Page
{
    public TeamDetailPage(Team team, string tab)
    {
        InitializeComponent();
        _team = team;

        TeamInfoStackPanel.DataContext = DB.entities.Teams.Include(c => c.Division).Include(c => c.Division.Conference)
            .FirstOrDefault(c => c.TeamId == team.TeamId);
        SeasonComboBox.ItemsSource = DB.entities.Seasons.ToList();
        SeasonComboBox.SelectedIndex = 0;

        MatchupLoad(team);
        LineupLoad(team, DB.entities.Seasons.ToList().Last().SeasonId);

        switch (tab)
        {
            case "Roster":
                TabControl.SelectedIndex = 0;
                break;
            case "Matchup":
                TabControl.SelectedIndex = 1;
                break;
            case "Lineup":
                TabControl.SelectedIndex = 2;
                break;
        }
    }

    private Team _team;
    private List<MatchupPlus> matchupPlusList;

    private void RosterLoad(Team team, int season)
    {
        try
        {
            RosterDataGrid.ItemsSource = DB.entities.PlayerInTeams.Include(c => c.Player)
                .Include(c => c.Player.Position)
                .Where(c => c.TeamId == team.TeamId && c.SeasonId== season).ToList();
        }
        catch (Exception exc)
        {
            MessageBox.Show(exc.Message);
        }
    }

    private void MatchupLoad(Team team)
    {
        try
        {
            List<Matchup> matchups = DB.entities.Matchups.Include(c => c.MatchupType).Include(c => c.TeamAwayNavigation)
                .Include(c => c.TeamHomeNavigation).Where(c => c.TeamAway == team.TeamId || c.TeamHome == team.TeamId)
                .ToList();
            matchupPlusList = new List<MatchupPlus>();
            MatchupPlus matchupPlus;
            foreach (var item in matchups)
            {
                matchupPlus = new MatchupPlus();
                matchupPlus.MatchupType = item.MatchupType.Name;
                matchupPlus.Location = item.Location;
                if (item.TeamAway == team.TeamId)
                {
                    matchupPlus.Opponent = item.TeamHomeNavigation.TeamName;
                    matchupPlus.Result = item.TeamAwayScore + ":" + item.TeamHomeScore;
                }
                else
                {
                    matchupPlus.Opponent = item.TeamAwayNavigation.TeamName;
                    matchupPlus.Result = item.TeamHomeScore + ":" + item.TeamAwayScore;
                }

                matchupPlus.StartTime = item.StartTime.ToString("h:mm tt");
                matchupPlus.StartDate = item.StartTime.ToString("d");
                matchupPlus.Status = item.StatusName;
                matchupPlusList.Add(matchupPlus);
            }

            MatchupDataGrid.ItemsSource = matchupPlusList;
        }
        catch (Exception exc)
        {
            MessageBox.Show(exc.Message);
        }
    }

    private void LineupLoad(Team team, int season)
    {
        try
        {
            /*
            1	SmallForward	SF 
            2	PowerForward	PF 
            3	Center      	C  
            4	ShootingGuard	SG 
            5	PointGuard  	PG 
             */
            List<PlayerInTeam> playersInTeam = DB.entities.PlayerInTeams.Include(c => c.Player)
                .Where(c => c.TeamId == team.TeamId && c.SeasonId == season).ToList();
            PFListView.ItemsSource =
                playersInTeam.Where(c => c.Player.PositionId == 2).ToList().OrderBy(c => c.StarterIndex);
            SGListView.ItemsSource =
                playersInTeam.Where(c => c.Player.PositionId == 4).ToList().OrderBy(c => c.StarterIndex);
            CListView.ItemsSource =
                playersInTeam.Where(c => c.Player.PositionId == 3).ToList().OrderBy(c => c.StarterIndex);
            PGListView.ItemsSource =
                playersInTeam.Where(c => c.Player.PositionId == 5).ToList().OrderBy(c => c.StarterIndex);
            SFListView.ItemsSource =
                playersInTeam.Where(c => c.Player.PositionId == 1).ToList().OrderBy(c => c.StarterIndex);
        }
        catch (Exception exc)
        {
            MessageBox.Show(exc.Message);
        }
    }

    private void SearchTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            MatchupDataGrid.ItemsSource = matchupPlusList.Where(c =>
                c.StartDate.Contains(SearchTextBox.Text) ||
                c.MatchupType.ToLower().Contains(SearchTextBox.Text.ToLower()) ||
                c.Opponent.ToLower().Contains(SearchTextBox.Text.ToLower()) ||
                c.StartTime.ToLower().Contains(SearchTextBox.Text.ToLower()) || c.Result.Contains(SearchTextBox.Text) ||
                c.Location.ToLower().Contains(SearchTextBox.Text.ToLower()) ||
                c.Status.ToLower().Contains(SearchTextBox.Text.ToLower())).ToList();
        }
        catch (Exception exc)
        {
            MessageBox.Show(exc.Message);
        }
    }

    private void SeasonComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e) => RosterLoad(_team, Convert.ToInt32(((Season)SeasonComboBox.SelectedItem).SeasonId));
}