using System;
using System.Collections.Generic;
using NBA_Basketball.Entities.Models;

namespace NBA_Basketball.Models;

public partial class MatchupType
{
    public int MatchupTypeId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Matchup> Matchups { get; set; } = new List<Matchup>();
}
