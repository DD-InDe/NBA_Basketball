using System;
using System.Collections.Generic;
using NBA_Basketball.Entities.Models;

namespace NBA_Basketball.Models;

public partial class PlayerStatistic
{
    public int PlayerStatisticsId { get; set; }

    public int MatchupId { get; set; }

    public int TeamId { get; set; }

    public int PlayerId { get; set; }

    public int IsStarting { get; set; }

    public decimal Minutes { get; set; }

    public int Point { get; set; }

    public int Assist { get; set; }

    public int FieldGoalMade { get; set; }

    public int FieldGoalMissed { get; set; }

    public int ThreePointFieldGoalMade { get; set; }

    public int ThreePointFieldGoalMissed { get; set; }

    public int FreeThrowMade { get; set; }

    public int FreeThrowMissed { get; set; }

    public int Rebound { get; set; }

    public int Offr { get; set; }

    public int Dffr { get; set; }

    public int Steal { get; set; }

    public int Block { get; set; }

    public int Turnover { get; set; }

    public int Foul { get; set; }

    public virtual Matchup Matchup { get; set; } = null!;

    public virtual Player Player { get; set; } = null!;

    public virtual Team Team { get; set; } = null!;
}
