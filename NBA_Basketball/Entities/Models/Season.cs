using System;
using System.Collections.Generic;

namespace NBA_Basketball.Models;

public partial class Season
{
    public int SeasonId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Matchup> Matchups { get; set; } = new List<Matchup>();

    public virtual ICollection<PlayerInTeam> PlayerInTeams { get; set; } = new List<PlayerInTeam>();

    public virtual ICollection<PostSeason> PostSeasons { get; set; } = new List<PostSeason>();
}