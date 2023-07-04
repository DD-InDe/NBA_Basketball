using System;
using System.Collections.Generic;

namespace NBA_Basketball.Models;

public partial class Player
{
    public int PlayerId { get; set; }

    public string Name { get; set; } = null!;

    public int PositionId { get; set; }

    public DateTime JoinYear { get; set; }

    public decimal Height { get; set; }

    public decimal Weight { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? College { get; set; }

    public string CountryCode { get; set; } = null!;

    public string? Photo { get; set; }

    public byte[]? PhotoImage { get; set; }

    public bool IsRetirment { get; set; }

    public DateTime? RetirementTime { get; set; }

    public virtual Country CountryCodeNavigation { get; set; } = null!;

    public virtual ICollection<MatchupLog> MatchupLogs { get; set; } = new List<MatchupLog>();

    public virtual ICollection<PlayerInTeam> PlayerInTeams { get; set; } = new List<PlayerInTeam>();

    public virtual ICollection<PlayerStatistic> PlayerStatistics { get; set; } = new List<PlayerStatistic>();

    public virtual Position Position { get; set; } = null!;
}
