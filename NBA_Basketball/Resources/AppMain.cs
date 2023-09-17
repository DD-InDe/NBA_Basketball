using System;
using System.Linq;
using System.Windows;
using NBA_Basketball.AllWindows;
using NBA_Basketball.AllWindowsWindow;
using NBA_Basketball.Entities;
using NBA_Basketball.Models;

namespace NBA_Basketball.Resources;

public class AppMain
{
    public string SeasonShow()
    {
        try
        {
            Season currentSeason = DB.entities.Seasons.ToList().Last();
            int years = Convert.ToInt32(currentSeason.Name.Split('-')[1]) - 1946;

            return $"The current season is {currentSeason.Name}, and the NBA already has a history of {years} years.";
        }
        catch(Exception exc)
        {
            MessageBox.Show(exc.Message);
            return null;
        }
    }
}