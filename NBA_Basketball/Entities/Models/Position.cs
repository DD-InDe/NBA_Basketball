using System;
using System.Collections.Generic;

namespace NBA_Basketball.Models;

public partial class Position
{
    public int PositionId { get; set; }

    public string Name { get; set; } = null!;

    public string Abbr { get; set; } = null!;

    public virtual ICollection<Player> Players { get; set; } = new List<Player>();
}
