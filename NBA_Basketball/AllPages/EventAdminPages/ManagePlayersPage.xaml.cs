using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using NBA_Basketball.Entities;
using NBA_Basketball.Models;

namespace NBA_Basketball.AllPages.EventAdminPages;

public partial class ManagePlayersPage : Page
{
    public ManagePlayersPage()
    {
        InitializeComponent();
        _players = DB.entities.Players.Include(c => c.Position).Include(c => c.CountryCodeNavigation).ToList();

        List<string> positionList = new List<string>() { "All" };
        positionList.AddRange(DB.entities.Positions.Select(c => c.Name).ToList());
        PositionComboBox.ItemsSource = positionList;

        List<string> countryList = new List<string>() { "All" };
        countryList.AddRange(DB.entities.Countries.Select(c => c.CountryName).ToList());
        CountryComboBox.ItemsSource = countryList;

        PositionComboBox.SelectedIndex = 0;
        CountryComboBox.SelectedIndex = 0;
    }

    private List<Player> _players;

    private void DataGridUpdate()
    {
        if (PositionComboBox.SelectedItem == null || CountryComboBox.SelectedItem == null) return;

        if (PositionComboBox.SelectedIndex == 0 && CountryComboBox.SelectedIndex == 0)
            PlayerGrid.ItemsSource = _players.Where(c => c.Name.ToLower().Contains(SearchTextBox.Text.ToLower())).ToList();

        if (PositionComboBox.SelectedIndex != 0 && CountryComboBox.SelectedIndex == 0)
            PlayerGrid.ItemsSource = _players.Where(c =>
                c.Name.ToLower().Contains(SearchTextBox.Text.ToLower()) && c.Position.Name == PositionComboBox.SelectedItem.ToString()).ToList();

        if (PositionComboBox.SelectedIndex == 0 && CountryComboBox.SelectedIndex != 0)
            PlayerGrid.ItemsSource = _players.Where(c =>
                c.Name.ToLower().Contains(SearchTextBox.Text.ToLower()) &&
                c.CountryCodeNavigation.CountryName == CountryComboBox.SelectedItem.ToString()).ToList();

        if (PositionComboBox.SelectedIndex != 0 && CountryComboBox.SelectedIndex != 0)
            PlayerGrid.ItemsSource = _players.Where(c =>
                c.Name.ToLower().Contains(SearchTextBox.Text.ToLower()) &&
                c.CountryCodeNavigation.CountryName == CountryComboBox.SelectedItem.ToString() &&
                c.Position.Name == PositionComboBox.SelectedItem.ToString()).ToList();

        PlayersTextBlock.Text = "Total players:" + PlayerGrid.Items.Count;
    }

    private void PositionComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e) => DataGridUpdate();

    private void CountryComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e) => DataGridUpdate();

    private void SearchTextBox_OnTextChanged(object sender, TextChangedEventArgs e) => DataGridUpdate();
}