using System;
using System.Linq;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using NBA_Basketball.Entities;
using NBA_Basketball.Models;
using Size = System.Drawing.Size;

namespace NBA_Basketball.AllPages.VisitorsPages;

public partial class TeamsMainPage : Page
{
    public TeamsMainPage()
    {
        InitializeComponent();
    }

    private void TeamsMainPage_OnLoaded(object sender, RoutedEventArgs e)
    {
        try
        {
            AtlanticTeamsListView.ItemsSource = DB.entities.Teams.Where(c => c.Division.Name == "Atlantic").ToList();
            CentralTeamsListView.ItemsSource = DB.entities.Teams.Where(c => c.Division.Name == "Central").ToList();
            SoutheastTeamsListView.ItemsSource =
                DB.entities.Teams.Where(c => c.Division.Name == "Southeastern").ToList();
            SouthwesternTeamsListView.ItemsSource =
                DB.entities.Teams.Where(c => c.Division.Name == "Southwestern").ToList();
            NorthwesternTeamsListView.ItemsSource =
                DB.entities.Teams.Where(c => c.Division.Name == "Northwestern").ToList();
            PacificTeamsListView.ItemsSource = DB.entities.Teams.Where(c => c.Division.Name == "Pacific").ToList();
        }
        catch (Exception exc)
        {
            MessageBox.Show(exc.Message);
        }
    }

    private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        try
        {
            NavigationService.Navigate(new TeamDetailPage(((Image)e.OriginalSource).DataContext as Team));
        }
        catch (Exception exc)
        {
            MessageBox.Show(exc.Message);
        }
    }
}