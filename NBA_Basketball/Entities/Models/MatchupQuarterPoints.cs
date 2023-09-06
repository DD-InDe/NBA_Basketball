namespace NBA_Basketball.Entities.Models;

public class MatchupQuarterPoints
{
    public string Team { get; set; }
    public string Total { get; set; }
    public string First { get; set; }
    public string Second { get; set; }
    public string Third { get; set; }
    public string Fourth { get; set; }
    public string FirstOT { get; set; }
    public string SecondOT { get; set; }

    public MatchupQuarterPoints(string name, string total, string first, string second, string third, string fourth,
        string firstOT, string secondOT)
    {
        Team = name;
        Total = total;
        First = first;
        Second = second;
        Third = third;
        Fourth = fourth;
        FirstOT = firstOT;
        SecondOT = secondOT;
    }
}