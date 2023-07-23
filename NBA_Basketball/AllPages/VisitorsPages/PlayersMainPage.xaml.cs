using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using NBA_Basketball.Entities;

namespace NBA_Basketball.AllPages.VisitorsPages;

public partial class PlayersMainPage : Page
{
    public PlayersMainPage()
    {
        InitializeComponent();

        try
        {
            SeasonComboBox.ItemsSource = DB.entities.Seasons.ToList();
            TeamComboBox.ItemsSource = DB.entities.Teams.ToList();
        }
        catch (Exception exc)
        {
            MessageBox.Show(exc.Message);
        }
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
    }
}