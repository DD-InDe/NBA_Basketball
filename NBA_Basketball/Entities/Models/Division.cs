using System;
using System.Collections.Generic;

namespace NBA_Basketball.Models;

public partial class Division
{
    public int DivisionId { get; set; }

    public string Name { get; set; } = null!;

    public int? ConferenceId { get; set; }

    public virtual Conference? Conference { get; set; }

    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();
}
