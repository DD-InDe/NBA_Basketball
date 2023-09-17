namespace NBA_Basketball.Entities.Models;

public class TeamPartial
{
    public string Name { get; set; }
    public string Conference { get; set; }
    public string Division { get; set; }
    public string Coach { get; set; }
    public int TotalSalary { get; set; }
    public byte[]? LogoImage { get; set; }

    public TeamPartial(string name, string conference, string division, string coach, int totalSalary, byte[]? logoImage)
    {
        Name = name;
        Conference = conference;
        Division = division;
        Coach = coach;
        TotalSalary = totalSalary;
        LogoImage = logoImage;
    }
}