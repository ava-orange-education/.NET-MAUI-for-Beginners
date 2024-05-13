using GroupedData.Models;

namespace GroupedData;

public partial class MainPage : ContentPage
{
    List<Transport>? routeInformation = new List<Transport>();

    public List<Transport>? RouteInformation
    {
        get => routeInformation;
        set => routeInformation = value;
    }

    public MainPage()
    {
        InitializeComponent();

        // get the data from a different class=
        var data = new GenerateCollectionData().CreateBackingData();
        var sorted = data.OrderBy(t=>t.BusOperatorName).ToList();
        var titles = sorted.DistinctBy(t=>t.BusOperatorName).ToList();

        foreach (var title in titles)
        {
            var op = sorted.Where(t => t.BusOperatorName == title.BusOperatorName).ToList();
            RouteInformation.Add(new Transport(title.BusOperatorName, op));
        }
        
        // set the binding context
        BindingContext = this;
    }
}