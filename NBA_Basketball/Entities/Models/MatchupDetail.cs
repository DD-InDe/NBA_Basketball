using System;
using System.Collections.Generic;

namespace NBA_Basketball.Models;

public partial class MatchupDetail
{
    public int MatchupDetailId { get; set; }

    public int MatchupId { get; set; }

    public int Quarter { get; set; }

    public int TeamAwayScore { get; set; }

    public int TeamHomeScore { get; set; }

    public virtual Matchup Matchup { get; set; } = null!;
}
