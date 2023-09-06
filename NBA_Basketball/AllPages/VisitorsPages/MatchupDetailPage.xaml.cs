using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using Microsoft.EntityFrameworkCore;
using NBA_Basketball.Entities;
using NBA_Basketball.Entities.Models;
using NBA_Basketball.Models;

namespace NBA_Basketball.AllPages.VisitorsPages;

public partial class MatchupDetailPage : Page
{
    public MatchupDetailPage(int matchupId)
    {
        InitializeComponent();
        _matchupId = matchupId;
        _matchup = DB.entities.Matchups.Include(c => c.TeamAwayNavigation).Include(c => c.TeamHomeNavigation).First(c => c.MatchupId == _matchupId);
        _matchupLogs = DB.entities.MatchupLogs.Include(c=>c.Team).Include(c=>c.Player).Include(c=>c.ActionType).Where(c => c.MatchupId == _matchupId)
        .ToList();
        QuarterComboBox.ItemsSource =
            DB.entities.MatchupLogs.Where(c => c.MatchupId == matchupId).Select(c => c.Quarter).ToList().Distinct().ToList();

        LogLoad();
        MatchInfoLoad();
        // team status
        TeamInfoLoad();
        BarsInfoLoad();
        // short chart
        ChartLoad();
    }

    private int _matchupId;
    private Matchup _matchup;
    private List<TeamStatistic> teamStatistics;
    private List<MatchupLog> _matchupLogs;

    private void MatchInfoLoad()
    {
        try
        {
            List<MatchupDetail> matchupDetails = DB.entities.MatchupDetails.Include(c => c.Matchup)
                .Include(c => c.Matchup.TeamHomeNavigation).Include(c => c.Matchup.TeamAwayNavigation)
                .Where(c => c.MatchupId == _matchupId).ToList();

            int awayTotal = 0;
            int homeTotal = 0;
            //
            string awayFirst = "";
            string awaySecond = "";
            string awayThird = "";
            string awayFourth = "";
            string awayFirstOT = "";
            string awaySecondOT = "";
            //
            string homeFirst = "";
            string homeSecond = "";
            string homeThird = "";
            string homeFourth = "";
            string homeFirstOT = "";
            string homeSecondOT = "";

            foreach (var detail in matchupDetails)
            {
                if (detail.Quarter == 1)
                {
                    awayFirst = detail.TeamAwayScore.ToString();
                    homeFirst = detail.TeamHomeScore.ToString();
                    TotalPlus();
                }

                if (detail.Quarter == 2)
                {
                    awaySecond = detail.TeamAwayScore.ToString();
                    homeSecond = detail.TeamHomeScore.ToString();
                    TotalPlus();
                }

                if (detail.Quarter == 3)
                {
                    awayThird = detail.TeamAwayScore.ToString();
                    homeThird = detail.TeamHomeScore.ToString();
                    TotalPlus();
                }

                if (detail.Quarter == 4)
                {
                    awayFourth = detail.TeamAwayScore.ToString();
                    homeFourth = detail.TeamHomeScore.ToString();
                    TotalPlus();
                }

                if (detail.Quarter == 5)
                {
                    awayFirstOT = detail.TeamAwayScore.ToString();
                    homeFirstOT = detail.TeamHomeScore.ToString();
                    TotalPlus();
                }

                if (detail.Quarter == 6)
                {
                    awaySecondOT = detail.TeamAwayScore.ToString();
                    homeSecondOT = detail.TeamHomeScore.ToString();
                    TotalPlus();
                }

                void TotalPlus()
                {
                    awayTotal += detail.TeamAwayScore;
                    homeTotal += detail.TeamHomeScore;
                }
            }

            MatchupQuarterPoints awayQuarterPoints = new MatchupQuarterPoints(
                matchupDetails.Select(c => c.Matchup.TeamAwayNavigation.Abbr).First(), awayTotal.ToString(), awayFirst,
                awaySecond,
                awayThird, awayFourth, awayFirstOT, awaySecondOT);
            MatchupQuarterPoints homeQuarterPoints = new MatchupQuarterPoints(
                matchupDetails.Select(c => c.Matchup.TeamHomeNavigation.Abbr).First(), homeTotal.ToString(), homeFirst,
                homeSecond,
                homeThird, homeFourth, homeFirstOT, homeSecondOT);
            List<MatchupQuarterPoints> quarterPointsList = new List<MatchupQuarterPoints>
            {
                awayQuarterPoints, homeQuarterPoints
            };

            PointsDataGrid.ItemsSource = quarterPointsList;
            TeamInfoStackPanel.DataContext = _matchup;
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
        }
    }

    private void TeamInfoLoad()
    {
        try
        {
            List<MatchupLog> matchupLogs = DB.entities.MatchupLogs.Include(c => c.Matchup)
                .Include(c => c.Matchup.TeamAwayNavigation).Include(c => c.Matchup.TeamHomeNavigation)
                .Include(c => c.ActionType)
                .Where(c => c.MatchupId == _matchupId).ToList();

            TeamStatistic teamStatistic;
            teamStatistics = new List<TeamStatistic>();

            int awayTeam = DB.entities.Matchups.Where(c => c.MatchupId == _matchupId).Select(c => c.TeamAway).First();
            int homeTeam = DB.entities.Matchups.Where(c => c.MatchupId == _matchupId).Select(c => c.TeamHome).First();

            List<string> actionTypes = new List<string>()
            {
                "Field Goal",
                "3-Points Field Goal",
                "Free Throw",
                "Rebound",
                "Assist",
                "Steal",
                "Block",
                "Turnover"
            };

            foreach (var action in actionTypes)
            {
                try
                {
                    List<MatchupLog> tempList;

                    string awayScore;
                    tempList = matchupLogs.Where(c => c.TeamId == awayTeam && c.ActionType.Name.Contains(action))
                        .ToList();

                    if (tempList.Count == 0)
                    {
                        if (action.StartsWith("Field") || action.StartsWith("3") || action.StartsWith("Free"))
                            awayScore = "0:0";
                        else
                            awayScore = "0";
                    }
                    else
                    {
                        if (action.StartsWith("Field") || action.StartsWith("3") || action.StartsWith("Free"))
                            awayScore = tempList.Where(c => c.ActionType.Name == action + " " + "Made").ToList().Count +
                                        ":" +
                                        (tempList.Where(c => c.ActionType.Name == action + " " + "Missed").ToList()
                                             .Count +
                                         tempList.Where(c => c.ActionType.Name == action + " " + "Made").ToList()
                                             .Count);
                        else
                            awayScore = tempList.Count.ToString();
                    }

                    string homeScore;
                    tempList = matchupLogs.Where(c => c.TeamId == homeTeam && c.ActionType.Name.Contains(action))
                        .ToList();

                    if (tempList.Count == 0)
                    {
                        if (action.StartsWith("Field") || action.StartsWith("3") || action.StartsWith("Free"))
                            homeScore = "0:0";
                        else
                            homeScore = "0";
                    }
                    else
                    {
                        if (action.StartsWith("Field") || action.StartsWith("3") || action.StartsWith("Free"))
                            homeScore = tempList.Where(c => c.ActionType.Name == action + " " + "Made").ToList().Count +
                                        ":" +
                                        (tempList.Where(c => c.ActionType.Name == action + " " + "Missed").ToList()
                                             .Count +
                                         tempList.Where(c => c.ActionType.Name == action + " " + "Made").ToList()
                                             .Count);
                        else
                            homeScore = tempList.Count.ToString();
                    }

                    teamStatistic = new TeamStatistic()
                    {
                        ActionName = action,
                        TeamAwayScore = awayScore,
                        TeamHomeScore = homeScore
                    };
                    teamStatistics.Add(teamStatistic);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }

            ImagesGrid.DataContext = _matchup;
            TeamStatusDataGrid.ItemsSource = teamStatistics;
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
        }
    }

    private void BarsInfoLoad()
    {
        try
        {
            double made;
            double miss;

            //fg team away
            FgTeamAwayAbbr.Text = _matchup.TeamAwayNavigation.Abbr;
            made = Convert.ToDouble(teamStatistics[0].TeamAwayScore.Split(":")[0]);
            miss = Convert.ToDouble(teamStatistics[0].TeamAwayScore.Split(":")[1]);
            if (made == 0)
                FgTeamAwayBar.Value = 0;
            else
                FgTeamAwayBar.Value = Math.Round(made / miss * 100, 2);
            FgTeamAwayTextBlock.Text = FgTeamAwayBar.Value.ToString();

            // fg team home
            FgTeamHomeAbbr.Text = _matchup.TeamHomeNavigation.Abbr;
            made = Convert.ToDouble(teamStatistics[0].TeamHomeScore.Split(":")[0]);
            miss = Convert.ToDouble(teamStatistics[0].TeamHomeScore.Split(":")[1]);
            if (made == 0)
                FgTeamHomeBar.Value = 0;
            else
                FgTeamHomeBar.Value = Math.Round(made / miss * 100, 2);
            FgTeamHomeTextBlock.Text = FgTeamHomeBar.Value.ToString();

            // fp team away
            FpTeamAwayAbbr.Text = _matchup.TeamAwayNavigation.Abbr;
            made = Convert.ToDouble(teamStatistics[1].TeamAwayScore.Split(":")[0]);
            miss = Convert.ToDouble(teamStatistics[1].TeamAwayScore.Split(":")[1]);
            if (made == 0)
                FpTeamAwayBar.Value = 0;
            else
                FpTeamAwayBar.Value = Math.Round(made / miss * 100, 2);
            FpTeamAwayTextBlock.Text = FpTeamAwayBar.Value.ToString();

            // fp team home
            FpTeamHomeAbbr.Text = _matchup.TeamHomeNavigation.Abbr;
            made = Convert.ToDouble(teamStatistics[1].TeamAwayScore.Split(":")[0]);
            miss = Convert.ToDouble(teamStatistics[1].TeamAwayScore.Split(":")[1]);
            if (made == 0)
                FpTeamHomeBar.Value = 0;
            else
                FpTeamHomeBar.Value = Math.Round(made / miss * 100, 2);
            FpTeamHomeTextBlock.Text = FpTeamHomeBar.Value.ToString();
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
        }
    }

    public class TeamStatistic
    {
        public string ActionName { get; set; }
        public string TeamAwayScore { get; set; }
        public string TeamHomeScore { get; set; }

        public string CurrentActionName
        {
            get
            {
                switch (ActionName)
                {
                    case "Field Goal":
                        return "FG Made-Attempted";
                    case "3-Points Field Goal":
                        return "3PT Made-Attempted";
                    case "Free Throw":
                        return "FT Made-Attempted";
                    default:
                        return ActionName + "s";
                }
            }
        }
    }

    private void ChartLoad()
    {
        try
        {
            ShortChartGrid.DataContext = _matchup;
            TeamAwayListView.ItemsSource = DB.entities.PlayerInTeams.Include(c => c.Player).Where(c =>
                c.TeamId == _matchup.TeamAway && c.StarterIndex == 1 && c.SeasonId == _matchup.SeasonId).ToList();
            TeamHomeListView.ItemsSource = DB.entities.PlayerInTeams.Include(c => c.Player).Where(c =>
                c.TeamId == _matchup.TeamHome && c.StarterIndex == 1 && c.SeasonId == _matchup.SeasonId).ToList();
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
        }
    }

    private void LogLoad()
    {
        if (_matchupLogs.Count == 0)
        {
            DataTextBlock.Visibility = Visibility.Visible;
            LogsStackPanel.Visibility = Visibility.Hidden;
        }
    }

    private void QuarterComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        try
        {
            LogDataGrid.ItemsSource = _matchupLogs.Where(c => c.Quarter == Convert.ToInt32(QuarterComboBox.SelectedItem)).ToList();
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
        }
    }
}