using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using Microsoft.EntityFrameworkCore;
using NBA_Basketball.Entities;
using NBA_Basketball.Models;

namespace NBA_Basketball.AllPages.TechAdminPages;

public partial class TeamReportPage : Page
{
    public TeamReportPage()
    {
        InitializeComponent();

        List<string> matchupType = new List<string>() { "Preseason", "Regular Season", "Post Season" };
        List<string> rankBy = new List<string>() { "Points", "Rebounds", "Assists", "Steals", "Turnovers" };
        List<string> viewBy = new List<string>() { "Average", "Total" };

        MatchupTypeComboBox.ItemsSource = matchupType;
        RankByComboBox.ItemsSource = rankBy;
        ViewByComboBox.ItemsSource = viewBy;

        onLoad = false;
        MatchupTypeComboBox.SelectedIndex = 0;
        RankByComboBox.SelectedIndex = 0;
        ViewByComboBox.SelectedIndex = 0;

        currentPage = 1;
        onLoad = true;
        DataLoad(); // DataLoad -> Sorting -> Paging (RankAdd) -> DataGridUpdate
    }

    private bool onLoad;
    private List<TeamStatistic> _teamStatistics;
    private List<List<TeamStatistic>> allTeamStatistics;
    TeamStatistic teamStatistic;
    private int pages;
    private int currentPage;

    private void Paging(List<TeamStatistic> list)
    {
        List<TeamStatistic> page;
        List<TeamStatistic> tempList = RankAdd(list.Where(c => c.Season == MatchupTypeComboBox.SelectedItem.ToString()).ToList());
        allTeamStatistics = new List<List<TeamStatistic>>();

        if (tempList.Count % 20 == 0)
            pages = tempList.Count / 20;
        else
            pages = tempList.Count / 20 + 1;

        for (int i = 0; i < pages; i++)
        {
            page = new List<TeamStatistic>();
            for (int j = 0; j < 20; j++)
            {
                if (j + i * 20 <= tempList.Count - 1)
                    page.Add(tempList[j + i * 20]);
                else
                    break;
            }

            allTeamStatistics.Add(page);
        }

        DataGridUpdate();
    }

    private void DataGridUpdate()
    {
        if (allTeamStatistics.Count == 0)
        {
            MessageTextBlock.Visibility = Visibility.Visible;
            DataStackPanel.Visibility = Visibility.Hidden;
            return;
        }
        else
        {
            MessageTextBlock.Visibility = Visibility.Hidden;
            DataStackPanel.Visibility = Visibility.Visible;
        }

        TeamDataGrid.ItemsSource = allTeamStatistics[currentPage - 1].ToList();

        PagesTextBlock.Text = currentPage + " of " + pages;
    }

    private List<TeamStatistic> RankAdd(List<TeamStatistic> tempList)
    {
        int rank = 1;
        for (int i = 0; i < tempList.Count; i++)
        {
            if (i != 0)
            {
                if (tempList[i].CurrentPoint == tempList[i - 1].CurrentPoint)
                    tempList[i].Rank = rank;
                else
                {
                    tempList[i].Rank = rank;
                    rank++;
                }
            }
            else
            {
                tempList[i].Rank = rank;
                rank++;
            }
        }

        return tempList;
    }

    private void Sorting()
    {
        switch (RankByComboBox.SelectedItem.ToString())
        {
            case "Points":
                foreach (TeamStatistic statistic in _teamStatistics)
                    statistic.CurrentPoint = statistic.Points;
                break;
            case "Rebounds":
                foreach (TeamStatistic statistic in _teamStatistics)
                    statistic.CurrentPoint = statistic.Rebounds;
                break;
            case "Assists":
                foreach (TeamStatistic statistic in _teamStatistics)
                    statistic.CurrentPoint = statistic.Assists;
                break;
            case "Steals":
                foreach (TeamStatistic statistic in _teamStatistics)
                    statistic.CurrentPoint = statistic.Steals;
                break;
            case "Turnovers":
                foreach (TeamStatistic statistic in _teamStatistics)
                    statistic.CurrentPoint = statistic.Turnovers;
                break;
        }

        _teamStatistics = _teamStatistics.OrderByDescending(c => c.CurrentPoint).ToList();
        Paging(_teamStatistics);
    }

    private void DataLoad()
    {
        _teamStatistics = new List<TeamStatistic>();
        List<Team> teams = DB.entities.Teams.Include(c => c.Division).Include(c => c.Division.Conference).ToList();
        List<PlayerStatistic> playerStatistics = DB.entities.PlayerStatistics.Include(c => c.Matchup).Include(c => c.Team)
            .Include(c => c.Matchup.MatchupType).ToList();
        int count;


        foreach (Team team in teams)
        {
            for (int i = 0; i < 3; i++)
            {
                double points = 0;
                double rebounds = 0;
                double assists = 0;
                double steals = 0;
                double blocks = 0;
                double turnovers = 0;
                double fouls = 0;
                string season = string.Empty;

                if (i < 2)
                {
                    foreach (var statistic in playerStatistics.Where(c => c.Team == team && c.Matchup.MatchupTypeId == i).ToList())
                    {
                        points += statistic.Point;
                        rebounds += statistic.Rebound;
                        assists += statistic.Assist;
                        steals += statistic.Steal;
                        blocks += statistic.Block;
                        turnovers += statistic.Turnover;
                        fouls += statistic.Foul;
                    }

                    count = playerStatistics.Where(c => c.Team == team && c.Matchup.MatchupTypeId == i).ToList().Count;
                }
                else
                {
                    foreach (var statistic in playerStatistics.Where(c => c.Team == team && c.Matchup.MatchupTypeId > 200).ToList())
                    {
                        points += statistic.Point;
                        rebounds += statistic.Rebound;
                        assists += statistic.Assist;
                        steals += statistic.Steal;
                        blocks += statistic.Block;
                        turnovers += statistic.Turnover;
                        fouls += statistic.Foul;
                    }

                    count = playerStatistics.Where(c => c.Team == team && c.Matchup.MatchupTypeId > 200).ToList().Count();
                }

                if (ViewByComboBox.SelectedItem.ToString() == "Average" && count != 0)
                {
                    points = Math.Round(points / count, 2);
                    rebounds = Math.Round(rebounds / count, 2);
                    assists = Math.Round(assists / count, 2);
                    steals = Math.Round(steals / count, 2);
                    blocks = Math.Round(blocks / count, 2);
                    turnovers = Math.Round(turnovers / count, 2);
                    fouls = Math.Round(fouls / count, 2);
                }

                if (i == 0) season = "Preseason";
                if (i == 1) season = "Regular Season";
                if (i > 1) season = "Post Season";

                teamStatistic = new TeamStatistic(team.TeamName, team.Division.Conference.Name, team.Division.Name, points, rebounds, assists, steals,
                    blocks, turnovers, fouls, season);
                _teamStatistics.Add(teamStatistic);
            }
        }

        Sorting();
    }

    private void RankByComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (!onLoad) return;
        currentPage = 1;
        Sorting();
    }

    private void ViewByComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (!onLoad) return;
        currentPage = 1;
        DataLoad();
    }

    private void MatchupTypeComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (!onLoad) return;
        currentPage = 1;
        Paging(_teamStatistics);
    }

    private void PreviousButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (currentPage > 1)
        {
            currentPage--;
            DataGridUpdate();
        }
    }

    private class TeamStatistic
    {
        public string Name { get; set; }
        public string Conference { get; set; }
        public string Division { get; set; }
        public double Points { get; set; }
        public double Rebounds { get; set; }
        public double Assists { get; set; }
        public double Steals { get; set; }
        public double Blocks { get; set; }
        public double Turnovers { get; set; }
        public double Fouls { get; set; }
        public string Season { get; set; }
        public int Rank { get; set; }
        public double CurrentPoint { get; set; }

        public TeamStatistic(string name, string conference, string division, double points, double rebounds, double assists, double steals,
            double blocks, double turnovers, double fouls, string season)
        {
            Name = name;
            Conference = conference;
            Division = division;
            Points = points;
            Rebounds = rebounds;
            Assists = assists;
            Steals = steals;
            Blocks = blocks;
            Turnovers = turnovers;
            Fouls = fouls;
            Season = season;
        }
    }

    private void NextButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (currentPage < pages)
        {
            currentPage++;
            DataGridUpdate();
        }
    }
}