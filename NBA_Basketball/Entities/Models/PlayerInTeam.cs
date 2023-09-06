using System;
using System.Collections.Generic;

namespace NBA_Basketball.Models;

public partial class PlayerInTeam
{
    public int PlayerInTeam1 { get; set; }

    public int PlayerId { get; set; }

    public int TeamId { get; set; }

    public int SeasonId { get; set; }

    public int ShirtNumber { get; set; }

    public string ShirtNumberText => "#" + ShirtNumber;

    public string PlayerNumber => Player.Name + $"({ShirtNumberText})";

    public decimal Salary { get; set; }
    
    public string SalaryText => "$" + Math.Round(Salary,0);

    public int StarterIndex { get; set; }

    public virtual Player Player { get; set; } = null!;

    public virtual Season Season { get; set; } = null!;

    public virtual Team Team { get; set; } = null!;
}
