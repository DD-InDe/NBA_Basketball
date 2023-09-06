using System;
using System.Collections.Generic;
using System.Linq;
using NBA_Basketball.Entities;
using NBA_Basketball.Entities.Models;

namespace NBA_Basketball.Models;

public partial class MatchupLog
{
    public int MatchupLogId { get; set; }

    public int MatchupId { get; set; }

    public int Quarter { get; set; }

    public string OccurTime { get; set; } = null!;

    public int TeamId { get; set; }

    public int PlayerId { get; set; }
    
    public int ActionTypeId { get; set; }

    public string? Remark { get; set; }

    public virtual ActionType ActionType { get; set; } = null!;

    public virtual Matchup Matchup { get; set; } = null!;

    public virtual Player Player { get; set; } = null!;

    public virtual Team Team { get; set; } = null!;

    public string PlayerNumber => Remark.Split(")")[0] + ")";
}
