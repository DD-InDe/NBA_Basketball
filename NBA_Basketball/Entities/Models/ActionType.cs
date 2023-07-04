using System;
using System.Collections.Generic;

namespace NBA_Basketball.Models;

public partial class ActionType
{
    public int ActionTypeId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<MatchupLog> MatchupLogs { get; set; } = new List<MatchupLog>();
}
