using System.Windows;
using System.Windows.Controls;
using NBA_Basketball.AllWindowsWindow;

namespace NBA_Basketball.AllPages.TechAdminPages;

public partial class AdminMenuPage : Page
{
    public AdminMenuPage()
    {
        InitializeComponent();
        ((MainWindow)Application.Current.MainWindow).LogOutButton.Visibility = Visibility.Visible;
    }

    private void TeamReport_OnClick(object sender, RoutedEventArgs e) => NavigationService.Navigate(new TeamReportPage());

    private void ExecutionsButton_OnClick(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("The feature would be a future add-on to the current system.", "Manage Executions - Future Add-on", MessageBoxButton.OK,
            MessageBoxImage.Information);
    }
}