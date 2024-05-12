using System.Collections.ObjectModel;
using CollectionView.Models;

namespace CollectionView;

public class GenerateCollectionData
{
    /// <summary>
    /// this method fills the ObservableCollection with the data used by the app
    /// it is in a separate file to keep the code readable and not to bog down the
    /// code behind for the MainPage.xaml.cs file
    /// </summary>
    /// <returns>ObservableCollection</returns>

    public ObservableCollection<CollectionModel> CreateBackingData()
    {
        var data = new ObservableCollection<CollectionModel>();
        data.Add(new CollectionModel
        {
            RouteNumber = "66", From = "Garston Banks Road", Destination = "Garston MPTE Depot",
            RouteInterval = 30, BusOperateLogo = "mpte.png", Sun = true, BusOperatorName = "MPTE"
        });
        data.Add(new CollectionModel
        {
            RouteNumber = "89", From = "Speke Woodend Avenue", Destination = "St Helens",
            RouteInterval = 30, BusOperateLogo = "crosville.png", BusOperatorName = "Crosville"
        });
        data.Add(new CollectionModel
        {
            RouteNumber = "300", From = "Liverpool Skelhorne Street", Destination = "Southport Ribble Bus Station",
            RouteInterval = 120, Sun = true, BusOperateLogo = "ribble.png", BusOperatorName = "Ribble"
        });
        data.Add(new CollectionModel
        {
            RouteNumber = "34", From = "Liverpool Mann Island", Destination = "Manchester Arndale Bus Station",
            RouteInterval = 60, BusOperateLogo = "gmpte.png", BusOperatorName = "GM Buses"
        });
        data.Add(new CollectionModel
        {
            RouteNumber = "79", From = "Netherley", Destination = "Liverpool Pier Head",
            RouteInterval = 10, BusOperateLogo = "mpte.png", Sun = true, BusOperatorName = "MPTE"
        });
        data.Add(new CollectionModel
        {
            RouteNumber = "H20", From = "Runcorn Shopping City", Destination = "Liverpool Mann Island",
            RouteInterval = 60, BusOperateLogo = "crosville.png", BusOperatorName = "Crosville"
        });
        data.Add(new CollectionModel
        {
            RouteNumber = "365", From = "Liverpool Skelhorne Street", Destination = "Skelmersdale Bus Station",
            RouteInterval = 60, BusOperateLogo = "ribble.png", Sun = true, BusOperatorName = "Ribble"
        });
        data.Add(new CollectionModel
        {
            RouteNumber = "320", From = "Wigan Market Street Bus Station",
            Destination = "Liverpool Central Bus Station",
            RouteInterval = 30, Sun = true, BusOperateLogo = "gmpte.png", BusOperatorName = "GM Buses"
        });
        return data;
    }
}