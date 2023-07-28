using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
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

        playerList = DB.entities.PlayerInTeams.Include(c => c.Player).Include(c => c.Team)
            .Include(c => c.Player.Position).Include(c => c.Season).Include(c => c.Player.CountryCodeNavigation)
            .Where(c => c.PlayerId == playerId).ToList();
        playerInfoList = DB.entities.PlayerStatistics.Include(c => c.Matchup).Include(c => c.Matchup.Season)
            .Where(c => c.PlayerId == playerId).ToList();

        SeasonResultDataGrid.ItemsSource = StatisticLoad(playerInfoList
            .Where(c => c.Matchup.SeasonId == DB.entities.Seasons.ToList().Last().SeasonId).ToList());
        CareerResultDataGrid.ItemsSource = StatisticLoad(playerInfoList
            .Where(c => c.Matchup.SeasonId != DB.entities.Seasons.ToList().Last().SeasonId).ToList());
    }

    private List<PlayerStatistic> playerInfoList;

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

    private void PlayerDetailPage_OnLoaded(object sender, RoutedEventArgs e)
    {
        DataContext = playerList.Last();
        SeasonTextBlock.Text = playerList.Last().Season.Name + " season";
    }
}