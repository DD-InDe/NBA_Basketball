using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using Microsoft.EntityFrameworkCore;
using NBA_Basketball.Entities;
using NBA_Basketball.Entities.Models;
using NBA_Basketball.Models;

namespace NBA_Basketball.AllPages.VisitorsPages;

public partial class PlayerDetailPage : Page
{
    public PlayerDetailPage(int playerId)
    {
        InitializeComponent();
        _playerId = playerId;

        playerList = DB.entities.PlayerInTeams.Include(c => c.Player).Include(c => c.Team)
            .Include(c => c.Player.Position).Include(c => c.Season).Include(c => c.Player.CountryCodeNavigation)
            .Where(c => c.PlayerId == playerId).ToList();
        playerInfoList = DB.entities.PlayerStatistics.Include(c => c.Matchup).Include(c => c.Matchup.Season)
            .Where(c => c.PlayerId == playerId).ToList();

        SeasonResultDataGrid.ItemsSource = StatisticLoad(playerInfoList
            .Where(c => c.Matchup.SeasonId == DB.entities.Seasons.ToList().Last().SeasonId).ToList());
        CareerResultDataGrid.ItemsSource = StatisticLoad(playerInfoList
            .Where(c => c.Matchup.SeasonId != DB.entities.Seasons.ToList().Last().SeasonId).ToList());


        playerStatistics = DB.entities.PlayerStatistics.Include(c => c.Matchup).Where(c =>
            c.PlayerId == _playerId && c.Matchup.SeasonId == DB.entities.Seasons.ToList().Last().SeasonId).ToList();

        GraphLoad(new ChartValues<int>(playerStatistics.Select(c => c.Point).ToArray()));
        AverageTextBlock.Text = $"The average of points: {average}";
    }

    private int average;
    private List<PlayerStatistic> playerStatistics;

    private void GraphLoad(ChartValues<int> score)
    {
        average = 0;
        if (score.Count() != 0)
        {
            ChartValues<int> points = score;
            List<string> labels = new();

            foreach (var point in points)
                average += point;
            average /= points.Count;

            foreach (var item in playerStatistics)
                labels.Add(item.Matchup.StartTime.Day + "/" + item.Matchup.StartTime.Month);

            AxesCollection axisList = new AxesCollection();
            axisList.Add(new Axis() { Labels = labels });
            CartesianChart.AxisX = axisList;
            CartesianChart.Series = new SeriesCollection()
            {
                new LineSeries()
                {
                    Values = points,
                }
            };

            CartesianChart.Visibility = Visibility.Visible;
            DataTextBlock.Visibility = Visibility.Hidden;
        }
        else
        {
            CartesianChart.Visibility = Visibility.Hidden;
            DataTextBlock.Visibility = Visibility.Visible;
        }
    }

    private List<PlayerStatistic> playerInfoList;
    private int _playerId;

    private List<PlayerResult> StatisticLoad(List<PlayerStatistic> playerStatistics)
    {
        List<PlayerResult> playerResultsList = new List<PlayerResult>();
        if (playerStatistics.Count != 0)
        {
            int point = 0;
            int assist = 0;
            int rebound = 0;
            foreach (var item in playerStatistics)
            {
                point += item.Point;
                assist += item.Assist;
                rebound += item.Rebound;
            }

            playerResultsList.Add(new PlayerResult(point, assist, rebound, playerStatistics.Count));
        }
        else
            playerResultsList.Add(new PlayerResult());

        return playerResultsList;
    }

    private List<PlayerInTeam> playerList;
    private SolidColorBrush brush = new SolidColorBrush(Color.FromRgb(105, 149, 194));

    private void PlayerDetailPage_OnLoaded(object sender, RoutedEventArgs e)
    {
        DataContext = playerList.Last();
        SeasonTextBlock.Text = playerList.Last().Season.Name + " season";
    }

    private void GraphButton_OnClick(object sender, RoutedEventArgs e)
    {
        foreach (var button in GraphButtonStackPanel.Children)
            ((Button)button).Background = Brushes.Transparent;

        ((Button)sender).Background = brush;

        switch (((Button)sender).Content)
        {
            case "POINTS":
                GraphLoad(new ChartValues<int>(playerStatistics.Select(c => c.Point).ToArray()));
                AverageTextBlock.Text = $"The average of points: {average}";
                break;
            case "REBOUNDS":
                GraphLoad(new ChartValues<int>(playerStatistics.Select(c => c.Rebound).ToArray()));
                AverageTextBlock.Text = $"The average of rebounds: {average}";
                break;
            case "ASSISTS":
                GraphLoad(new ChartValues<int>(playerStatistics.Select(c => c.Assist).ToArray()));
                AverageTextBlock.Text = $"The average of assists: {average}";
                break;
            case "STEALS":
                GraphLoad(new ChartValues<int>(playerStatistics.Select(c => c.Steal).ToArray()));
                AverageTextBlock.Text = $"The average of steals: {average}";
                break;
            case "BLOCKS":
                GraphLoad(new ChartValues<int>(playerStatistics.Select(c => c.Block).ToArray()));
                AverageTextBlock.Text = $"The average of blocks: {average}";
                break;
        }
    }
}