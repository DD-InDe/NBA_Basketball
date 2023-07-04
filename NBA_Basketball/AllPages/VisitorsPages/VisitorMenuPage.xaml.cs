using System;
using System.Windows;
using System.Windows.Controls;

namespace NBA_Basketball.AllPages.VisitorsPages;

public partial class VisitorMenuPage : Page
{
    public VisitorMenuPage()
    {
        InitializeComponent();
    }

    private void TeamsButton_OnClick(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new TeamsMainPage());
    }
}