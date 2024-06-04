using SQLite;

namespace AddingSQLiteToExistingApp.Models;

public class CollectionModelDTO
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    #nullable enable
    public string? RouteNumber { get; set; }
    public string? From { get; set; }
    public string? Destination { get; set; }
    public string? BusOperateLogo { get; set; }
    public string? BusOperatorName { get; set; }
    #nullable disable
    public int RouteInterval { get; set; }
    
    public bool MonToFri { get; set; } = true;
    public bool Sat { get; set; } = true;
    public bool Sun { get; set; } = false;
}