using SQLite;

namespace StoringComplexTypes.Models;

public class CollectionModel
{
    [PrimaryKey]
    public Guid Id { get; set; }

    public int ParentId { get;set; }
    #nullable enable
    public string? RouteNumber { get; set; }
    public string? From { get; set; }
    public string? Destination { get; set; }
    public string? BusOperatorName { get; set; }
    public ImageSource? BusOperateLogo { get; set; }
    #nullable disable
    
    public int RouteInterval { get; set; }
    
    public bool MonToFri { get; set; } = true;
    public bool Sat { get; set; } = true;
    public bool Sun { get; set; } = false;
}