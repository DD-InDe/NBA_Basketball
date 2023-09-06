using System;
using System.Collections.Generic;
using System.Windows.Media;
using NBA_Basketball.Models;

namespace NBA_Basketball.Entities.Models;

public class Matchup
{
    public int MatchupId { get; set; }

    public int SeasonId { get; set; }

    public int MatchupTypeId { get; set; }

    public int TeamAway { get; set; }

    public int TeamHome { get; set; }

    public DateTime StartTime { get; set; }

    public string? Opponent { get; set; } = null;

    public string DateStart => StartTime.ToString("MM/dd/yyyy");

    public string TimeStart => StartTime.ToString("hh:mm tt");

    public string DateTimeStart => StartTime.ToString("MM/dd") + " " + StartTime.ToString("HH:mm");

    public string MatchInfo
    {
        get
        {
            if (StatusName == "Finished") return MatchResult;
            else
                return StartTime.ToString("HH:mm") + " Start";
        }
    }

    public string MatchResult => TeamAwayScore + "-" + TeamHomeScore;

    public string StatusName
    {
        get
        {
            if (Status == -1) return "Not start";
            if (Status == 0) return "Running";
            else return "Finished";
        }
    }

    public SolidColorBrush ColorBrush
    {
        get
        {
            if (Status == -1) return Brushes.DodgerBlue;
            if (Status == 0) return Brushes.Red;
            return Brushes.DarkGray;
        }
    }

    public int TeamAwayScore { get; set; }

    public int TeamHomeScore { get; set; }

    public string? Location { get; set; }

    public int Status { get; set; }

    public string? CurrentQuarter { get; set; }

    public virtual ICollection<MatchupDetail> MatchupDetails { get; set; } = new List<MatchupDetail>();

    public virtual ICollection<MatchupLog> MatchupLogs { get; set; } = new List<MatchupLog>();

    public virtual MatchupType MatchupType { get; set; } = null!;

    public virtual ICollection<PlayerStatistic> PlayerStatistics { get; set; } = new List<PlayerStatistic>();

    public virtual Season Season { get; set; } = null!;

    public virtual Team TeamAwayNavigation { get; set; } = null!;

    public virtual Team TeamHomeNavigation { get; set; } = null!;
}