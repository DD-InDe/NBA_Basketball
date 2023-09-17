using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using NBA_Basketball.AllPages.EventAdminPages;
using NBA_Basketball.AllWindowsWindow;
using NBA_Basketball.Entities;
using NBA_Basketball.Models;

namespace NBA_Basketball.AllPages.AdminPages;

public partial class AdminLoginPage : Page
{
    public AdminLoginPage()
    {
        InitializeComponent();
        
        FileInfo fileInfo = new FileInfo(path);
        if (fileInfo.Exists)
        {
            string[] file = File.ReadAllLines(path);
            LoginTextBox.Text = file[0];
            PasswordTextBox.Text = file[1];
        }
    }

    private string path = "rememberme.txt";

    private void LoginButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            if (LoginTextBox.Text != string.Empty && PasswordTextBox.Text != string.Empty)
            {
                AdminCheck();
                ((MainWindow)Application.Current.MainWindow).LogOutButton.Visibility = Visibility.Visible;
            }
            else
                MessageBox.Show("Fields can't be empty", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
        }
    }

    private void AdminCheck()
    {
        Admin admin = DB.entities.Admins.Where(c => c.Jobnumber == LoginTextBox.Text && c.Password == PasswordTextBox.Text).First();
        if (admin != null)
        {
            if (RememberCheckBox.IsChecked == true)
                File.WriteAllText(path, LoginTextBox.Text + "\n" + PasswordTextBox.Text);

            RoleCheck(admin);
        }
        else
            MessageBox.Show("Login or password entered incorrectly", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
    }

    private void RoleCheck(Admin admin)
    {
        switch (admin.RoleId)
        {
            case "1":
                NavigationService.Navigate(new EventAdminPages.AdminMenuPage());
                break;
            case "2":
                NavigationService.Navigate(new TechAdminPages.AdminMenuPage());
                break;
        }
    }

    private void CancelButton_OnClick(object sender, RoutedEventArgs e) => NavigationService.GoBack();
}