using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using NBA_Basketball.Entities;
using NBA_Basketball.Models;

namespace NBA_Basketball.AllPages.VisitorsPages;

public partial class PhotosPage : Page
{
    public PhotosPage()
    {
        InitializeComponent();

        _pictures = DB.entities.Pictures.ToList();
        currentPage = 1;
        LoadPhotos();
        ShowPhotos();
    }

    private List<List<Picture>> pagesPictures;
    private List<Picture> visiblePictures;
    private List<Picture> _pictures;
    private int pages;
    private int currentPage;

    private void LoadPhotos()
    {
        pagesPictures = new List<List<Picture>>();

        if (_pictures.Count % 12 == 0)
            pages = _pictures.Count / 12;
        else
            pages = _pictures.Count / 12 + 1;

        for (int i = 0; i < pages; i++)
        {
            visiblePictures = new List<Picture>();
            for (int j = 0; j < 12; j++)
            {
                if (j + i * 12 <= _pictures.Count - 1)
                    visiblePictures.Add(_pictures[j + i * 12]);
                else
                    break;
            }

            pagesPictures.Add(visiblePictures);
        }
    }

    private void ShowPhotos()
    {
        ImageListBox.ItemsSource = pagesPictures[currentPage - 1];
        CurrentPageTextBox.Text = currentPage.ToString();
        PageInfoTextBlock.Text = $"Total {_pictures.Count} Photos, {pagesPictures[currentPage - 1].Count} Photos in one page, Total {pages} Pages";
    }

    private void CurrentPageTextBox_OnKeyUp(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            if (Convert.ToInt32(CurrentPageTextBox.Text) < 1 || Convert.ToInt32(CurrentPageTextBox.Text) > pages)
                CurrentPageTextBox.Text = Convert.ToString(currentPage);
            else
            {
                currentPage = Convert.ToInt32(CurrentPageTextBox.Text);
                ShowPhotos();
            }
        }
    }

    private void CurrentPageTextBox_OnPreviewTextInput(object sender, TextCompositionEventArgs e) => e.Handled = "0123456789".IndexOf(e.Text) < 0;

    private void NextPageButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (currentPage < pages)
            currentPage++;
        ShowPhotos();
    }

    private void FirstPageButton_OnClick(object sender, RoutedEventArgs e)
    {
        currentPage = 1;
        ShowPhotos();
    }

    private void PreviousPageButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (currentPage > 1)
            currentPage--;
        ShowPhotos();
    }

    private void LastPageButton_OnClick(object sender, RoutedEventArgs e)
    {
        currentPage = pages;
        ShowPhotos();
    }

    private void SaveFiles(Picture picture)
    {
        try
        {
            string dirName = "LoadedImages";
            if (!Directory.Exists(dirName))
                Directory.CreateDirectory(dirName);
            DirectoryInfo directoryInfo = new DirectoryInfo(dirName);

            SaveFileDialog save = new SaveFileDialog
            {
                Filter = "JPG Files (*.jpg)|*.jpg"
            };
            if (save.ShowDialog() == true)
            {
                JpegBitmapEncoder jpegBitmapEncoder = new JpegBitmapEncoder();
                jpegBitmapEncoder.Frames.Add(BitmapFrame.Create((BitmapSource)new ImageSourceConverter().ConvertFrom(picture.Img)));
                using (FileStream fileStream = new FileStream(save.FileName, FileMode.Create))
                    jpegBitmapEncoder.Save(fileStream);
            }
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
        }
    }

    private void DownloadAll_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            SaveFileDialog save = new SaveFileDialog
            {
                Filter = "JPG Files (*.jpg)|*.jpg"
            };
            if (save.ShowDialog() == true)
            {
                foreach (var picture in pagesPictures[currentPage - 1])
                {
                    JpegBitmapEncoder jpegBitmapEncoder = new JpegBitmapEncoder();
                    jpegBitmapEncoder.Frames.Add(BitmapFrame.Create((BitmapSource)new ImageSourceConverter().ConvertFrom(picture.Img)));
                    using (FileStream fileStream = new FileStream(save.FileName, FileMode.Create))
                        jpegBitmapEncoder.Save(fileStream);
                }
            }
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
        }
    }

    private void MenuItem_OnClick(object sender, RoutedEventArgs e) => SaveFiles((Picture)((MenuItem)sender).DataContext);
}