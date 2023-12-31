﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NBA_Basketball.AllPages.AdminPages;
using NBA_Basketball.AllPages.VisitorsPages;
using NBA_Basketball.AllWindows;
using NBA_Basketball.Entities;
using NBA_Basketball.Models;
using NBA_Basketball.Resources;

namespace NBA_Basketball.AllWindowsWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Application.Current.MainWindow = this;
            appMain = new AppMain();
            appMain.SeasonShow();
            CurrentSeasonTextBlock.Text = appMain.SeasonShow();
        }

        AppMain appMain;

        private void BackButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack) MainFrame.GoBack();
            else
            {
                MainScreenWindow mainScreenWindow = new MainScreenWindow();
                mainScreenWindow.Show();
                Close();
            }
        }

        private void LogOutButton_OnClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            File.Delete("rememberme.txt");
            mainWindow.MainFrame.NavigationService.Navigate(new AdminLoginPage());
            mainWindow.Show();
            Close();
        }
    }
}