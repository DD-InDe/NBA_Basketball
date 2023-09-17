using System.Windows;
using System.Windows.Controls;
using NBA_Basketball.AllWindowsWindow;

namespace NBA_Basketball.AllPages.EventAdminPages;

public partial class AdminMenuPage : Page
{
    public AdminMenuPage()
    {
        InitializeComponent();
    }

    private void SeasonsButton_OnClick(object sender, RoutedEventArgs e) => NavigationService.Navigate(new ManageSeasonsPage());

    private void PlayersButton_OnClick(object sender, RoutedEventArgs e) => NavigationService.Navigate(new ManagePlayersPage());

    private void TeamsButton_OnClick(object sender, RoutedEventArgs e) => NavigationService.Navigate(new ManageTeamsPage());

    private void MatchupsButton_OnClick(object sender, RoutedEventArgs e) => NavigationService.Navigate(new ManageMatchupsPage());
}