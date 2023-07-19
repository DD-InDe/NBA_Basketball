using System;

namespace NBA_Basketball.Entities.Models;

public class MatchupPlus
{
    public string StartDate { get; set; }
    public string StartTime { get; set; }
    public string MatchupType { get; set; }
    public string Opponent { get; set; }
    public string Result { get; set; }
    public string Location { get; set; }
    public string Status { get; set; }
}