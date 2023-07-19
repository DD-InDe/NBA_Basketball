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
    public TeamDetailPage(Team team)
    {
        InitializeComponent();

        TeamInfoStackPanel.DataContext = DB.entities.Teams.Include(c => c.Division).Include(c => c.Division.Conference)
            .FirstOrDefault(c => c.TeamId == team.TeamId);
        RosterLoad(team);
        MatchupLoad(team);
        LineupLoad(team);
    }

    private void RosterLoad(Team team)
    {
        try
        {
            RosterDataGrid.ItemsSource = DB.entities.PlayerInTeams.Include(c => c.Player)
                .Include(c => c.Player.Position)
                .Where(c => c.TeamId == team.TeamId).ToList();
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
            List<MatchupPlus> matchupPlusList = new List<MatchupPlus>();
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

    private void LineupLoad(Team team)
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
                .Where(c => c.TeamId == team.TeamId).ToList();
            PFListView.ItemsSource = playersInTeam.Where(c => c.Player.PositionId == 2).ToList().DistinctBy(c=>c.Player).ToList();
            SGListView.ItemsSource = playersInTeam.Where(c => c.Player.PositionId == 4).ToList().DistinctBy(c=>c.Player).ToList();
            CListView.ItemsSource = playersInTeam.Where(c => c.Player.PositionId == 3).ToList().DistinctBy(c=>c.Player).ToList();
            PGListView.ItemsSource = playersInTeam.Where(c => c.Player.PositionId == 5).ToList().DistinctBy(c=>c.Player).ToList();
            SFListView.ItemsSource = playersInTeam.Where(c => c.Player.PositionId == 1).ToList().DistinctBy(c=>c.Player).ToList();
        }
        catch (Exception exc)
        {
            MessageBox.Show(exc.Message);
        }
    }
}