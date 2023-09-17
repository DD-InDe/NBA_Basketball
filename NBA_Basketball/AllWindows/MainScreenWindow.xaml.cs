using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using NBA_Basketball.AllPages.AdminPages;
using NBA_Basketball.AllPages.VisitorsPages;
using NBA_Basketball.AllWindowsWindow;
using NBA_Basketball.Entities;
using NBA_Basketball.Models;
using NBA_Basketball.Resources;

namespace NBA_Basketball.AllWindows;

public partial class MainScreenWindow : Window
{
    public MainScreenWindow()
    {
        try
        {
            InitializeComponent();
            ImagesLoad();

            currentPosition = 2;
            ImageOne.Source = allImages[0];
            ImageTwo.Source = allImages[1];
            ImageThree.Source = allImages[2];
            appMain = new AppMain();
            CurrentSeasonTextBlock.Text = appMain.SeasonShow();
        }
        catch (IOException exc)
        {
            MessageBox.Show(exc.Message);
        }
    }
    
    private AppMain appMain;
    private List<BitmapImage> allImages;
    private int currentPosition;

    private void GoRightButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            ImagesShow("right");
        }
        catch (IOException ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void GoLeftButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            ImagesShow("left");
        }
        catch (IOException ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void ImagesLoad()
    {
        try
        {
            allImages = new List<BitmapImage>();

            foreach (var item in DB.entities.Pictures.Select(c => c.Img).ToList())
            {
                MemoryStream byteStream = new MemoryStream(item);
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = byteStream;
                image.EndInit();
                allImages.Add(image);
            }
        }
        catch (IOException exc)
        {
            MessageBox.Show(exc.Message);
        }
    }

    private void ImagesShow(string direction)
    {
        switch (direction)
        {
            case "right":
                RightIndexCheck();
                ImageOne.Source = allImages[currentPosition];
                currentPosition++;
                RightIndexCheck();
                ImageTwo.Source = allImages[currentPosition];
                currentPosition++;
                RightIndexCheck();
                ImageThree.Source = allImages[currentPosition];
                currentPosition++;
                break;
            case "left":
                LeftIndexCheck();
                ImageOne.Source = allImages[currentPosition];
                currentPosition--;
                LeftIndexCheck();
                ImageTwo.Source = allImages[currentPosition];
                currentPosition--;
                LeftIndexCheck();
                ImageThree.Source = allImages[currentPosition];
                currentPosition--;
                break;
        }

        void RightIndexCheck()
        {
            if (currentPosition == allImages.Count - 1)
                currentPosition = 0;
        }

        void LeftIndexCheck()
        {
            if (currentPosition == 0)
                currentPosition = allImages.Count - 1;
        }
    }

    private void VisitorButton_OnClick(object sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.MainFrame.NavigationService.Navigate(new VisitorMenuPage());
        mainWindow.Show();
        Close();
    }

    private void AdminButton_OnClick(object sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.MainFrame.NavigationService.Navigate(new AdminLoginPage());
        mainWindow.Show();
        Close();  
    } 
}