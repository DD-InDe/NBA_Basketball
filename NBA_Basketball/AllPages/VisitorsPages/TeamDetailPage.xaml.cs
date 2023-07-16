using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using NBA_Basketball.Entities;
using NBA_Basketball.Models;

namespace NBA_Basketball.AllPages.VisitorsPages;

public partial class TeamDetailPage : Page
{
    public TeamDetailPage(Team team)
    {
        InitializeComponent();

        // TeamInfoStackPanel.DataContext = DB.entities.Teams.Include(c => c.Division).Include(c => c.Division.Conference)
        //     .FirstOrDefault(c => c.TeamId == team.TeamId);
        // RosterLoad(team);

        List<Matchup> matchups = DB.entities.Matchups.Include(c=>c.MatchupType).Include(c => c.TeamAwayNavigation)
            .Include(c => c.TeamHomeNavigation).Where(c => c.TeamAway == team.TeamId || c.TeamHome == team.TeamId)
            .ToList();
        foreach (var item in matchups)
        {
            if (item.TeamAway == team.TeamId)
            {
                item.Opponent = item.TeamHomeNavigation.TeamName;
                // item.TotalScore = item.TeamAwayScore + ":" + item.TeamHomeScore;
            }
            else
            {
                item.Opponent = item.TeamAwayNavigation.TeamName;
                // item.TotalScore = item.TeamHomeScore + ":" + item.TeamAwayScore;
            }
        }
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
        // try
        // {
        //     List<Matchup> matchups = DB.entities.Matchups.Include(c=>c.MatchupType).Include(c => c.TeamAwayNavigation)
        //         .Include(c => c.TeamHomeNavigation).Where(c => c.TeamAway == team.TeamId || c.TeamHome == team.TeamId)
        //         .ToList();
        //     foreach (var item in matchups)
        //     {
        //         if (item.TeamAway == team.TeamId)
        //         {
        //             item.Opponent = item.TeamHomeNavigation.TeamName;
        //             // item.TotalScore = item.TeamAwayScore + ":" + item.TeamHomeScore;
        //         }
        //         else
        //         {
        //             item.Opponent = item.TeamAwayNavigation.TeamName;
        //             // item.TotalScore = item.TeamHomeScore + ":" + item.TeamAwayScore;
        //         }
        //     }
        //
        //     MatchupDataGrid.ItemsSource = matchups;
        // }
        // catch (Exception exc)
        // {
        //     MessageBox.Show(exc.Message);
        // }
    }
}