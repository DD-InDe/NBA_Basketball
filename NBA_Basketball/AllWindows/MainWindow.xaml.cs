using System;
using System.Collections.Generic;
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
            AppMain appMain = new AppMain();
            appMain.SeasonShow();
            CurrentSeasonTextBlock.Text = appMain.SeasonShow();
            MainFrame.Navigate(new VisitorMenuPage());
        }

        private void BackButton_OnClick(object sender, RoutedEventArgs e)
        {
            if(MainFrame.CanGoBack) MainFrame.GoBack();
            else
            {
                MainScreenWindow mainScreenWindow = new MainScreenWindow();
                mainScreenWindow.Show();
                Close();
            }
        }

    }
}