namespace CollectionView.Models;

public class CollectionModel
{
    public string RouteNumber { get; set; }
    public string From { get; set; }
    public string Destination { get; set; }
    public int RouteInterval { get; set; }
    public ImageSource BusOperateLogo { get; set; }
    public string BusOperatorName { get; set; }
    
    public bool MonToFri { get; set; } = true;
    public bool Sat { get; set; } = true;
    public bool Sun { get; set; } = false;
}