using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using NBA_Basketball.Entities;
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
    }

    private List<PlayerInTeam> playerList;
    
    private void PlayerDetailPage_OnLoaded(object sender, RoutedEventArgs e)
    {
        this.DataContext = playerList.Last();
    }
}