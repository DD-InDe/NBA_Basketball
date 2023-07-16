using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NBA_Basketball.Models;

public partial class Matchup
{
    public int MatchupId { get; set; }

    public int SeasonId { get; set; }

    public int MatchupTypeId { get; set; }

    public int TeamAway { get; set; }

    public int TeamHome { get; set; }

    public DateTime StartTime { get; set; }

    public string DateStart => StartTime.ToString("MM/dd/yyyy");

    public string TimeStart => StartTime.ToString("hh:mm tt");


    public string StatusName
    {
        get
        {
            if (Status == -1) return "Not start";
            if (Status == 0) return "Running";
            else return "Finished";
        }
    }

    public int TeamAwayScore { get; set; }

    public int TeamHomeScore { get; set; }

    public string? Location { get; set; }

    public string Opponent { get; set; }
    // public string? TotalScore { get; set; } = null!;


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