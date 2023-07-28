using System;

namespace NBA_Basketball.Entities.Models;

public class PlayerResult
{
    public double PPG { get; set; }
    public double APG { get; set; }
    public double RPG { get; set; }

    public PlayerResult(int points, int assists, int rebounds, int matches)
    {
        PPG = points / matches;
        APG = assists / matches;
        RPG = rebounds / matches;
    }

    public PlayerResult()
    {
        PPG = 0;
        APG = 0;
        RPG = 0;
    }
}