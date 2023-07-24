using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.EntityFrameworkCore;
using NBA_Basketball.Entities;
using NBA_Basketball.Models;

namespace NBA_Basketball.AllPages.VisitorsPages;

public partial class PlayersMainPage : Page
{
    public PlayersMainPage()
    {
        InitializeComponent();

        try
        {
            SeasonComboBox.ItemsSource = DB.entities.Seasons.ToList();

            List<string> teamList = new List<string>() { "all" };
            foreach (var item in DB.entities.Teams)
                teamList.Add(item.TeamName);
            TeamComboBox.ItemsSource = teamList;

            playerInTeamsList = DB.entities.PlayerInTeams.Include(c => c.Player).Include(c => c.Team)
                .Include(c => c.Player.CountryCodeNavigation).Include(c => c.Player.Position).ToList();
            PlayerDataGrid.ItemsSource =
                playerInTeamsList.Where(c => c.SeasonId == ((Season)SeasonComboBox.SelectedItem).SeasonId);

            startIndex = 0;
            currentPage = 1;
            visiblePlayersList = playerInTeamsList;
            PlayerDataGrid.ItemsSource = playerInTeamsList.GetRange(startIndex, 10).ToList();
        }
        catch (Exception exc)
        {
            MessageBox.Show(exc.Message);
        }
    }

    private int currentPage;
    private int allPages;
    private int startIndex;
    private List<PlayerInTeam> playerInTeamsList;
    private List<PlayerInTeam> visiblePlayersList;


    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        string check = ((Button)sender).Content.ToString();
        startIndex = 0;
        if (check != "ALL" && TeamComboBox.SelectedIndex == 0)
            visiblePlayersList = playerInTeamsList.Where(c =>
                    c.Player.Name.StartsWith(check) && c.SeasonId == ((Season)SeasonComboBox.SelectedItem).SeasonId)
                .ToList();
        if (check != "ALL" && TeamComboBox.SelectedIndex != 0)
            visiblePlayersList = playerInTeamsList.Where(c =>
                c.Player.Name.StartsWith(check) && c.SeasonId == ((Season)SeasonComboBox.SelectedItem).SeasonId &&
                c.Team.Abbr == TeamComboBox.SelectedItem.ToString()).ToList();
        if (check == "ALL" && TeamComboBox.SelectedIndex == 0)
            visiblePlayersList = playerInTeamsList.Where(c => 
                    c.SeasonId == ((Season)SeasonComboBox.SelectedItem).SeasonId)
                .ToList();
        if (check == "ALL" && TeamComboBox.SelectedIndex != 0)
            visiblePlayersList = playerInTeamsList.Where(c=>
                c.SeasonId == ((Season)SeasonComboBox.SelectedItem).SeasonId &&
                c.Team.TeamName == TeamComboBox.SelectedItem.ToString()).ToList();
        PlayerDataGrid.ItemsSource = visiblePlayersList.GetRange(startIndex, 10);
    }

    private void FirstPageButton_OnClick(object sender, RoutedEventArgs e)
    {
        startIndex = 0;
        PlayerDataGrid.ItemsSource = visiblePlayersList.GetRange(startIndex, 10).ToList();
    }

    private void NextPageButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (startIndex <= visiblePlayersList.Count - 10)
        {
            startIndex += 10;
            if (startIndex>visiblePlayersList.Count-10)
            {
                PlayerDataGrid.ItemsSource = visiblePlayersList.GetRange(startIndex, visiblePlayersList.Count-10);
            }
            else
            {
                if (visiblePlayersList.Count >= 10)
                    PlayerDataGrid.ItemsSource = visiblePlayersList.GetRange(startIndex, 10);
                else
                    PlayerDataGrid.ItemsSource = visiblePlayersList;
            }
          
        }

        else
            visiblePlayersList = visiblePlayersList.ToList();

    }

    private void DataGridUpdate()
    {
        if (startIndex>visiblePlayersList.Count-10 )
        {
            PlayerDataGrid.ItemsSource = visiblePlayersList.GetRange(startIndex, visiblePlayersList.Count-10);
        }
        else
        {
            if (visiblePlayersList.Count >= 10)
                PlayerDataGrid.ItemsSource = visiblePlayersList.GetRange(startIndex, 10);
            else
                PlayerDataGrid.ItemsSource = visiblePlayersList;
        }
    }

    private void PreviousPageButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (startIndex >= 10)
        {
            startIndex -= 10;
            // visiblePlayersList = visiblePlayersList.Skip(startIndex).ToList();

            if (visiblePlayersList.Count >= 10)
                PlayerDataGrid.ItemsSource = visiblePlayersList.GetRange(startIndex, 10);
            else
                PlayerDataGrid.ItemsSource = visiblePlayersList;
        }
    }

    private void LastPageButton_OnClick(object sender, RoutedEventArgs e)
    {
        startIndex = visiblePlayersList.Count - 10;
        PlayerDataGrid.ItemsSource = visiblePlayersList.GetRange(startIndex, 10).ToList();
    }

    private void SeasonComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        
    }

    private void TeamComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        
    }
}