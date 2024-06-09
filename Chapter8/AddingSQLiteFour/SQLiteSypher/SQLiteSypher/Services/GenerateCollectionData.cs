using System.Collections.ObjectModel;
using SQLiteSypher.Interfaces;
using SQLiteSypher.Models;

namespace SQLiteSypher.Services;

public class GenerateCollectionData : IGenerateData
{
    public ObservableCollection<CollectionModelDTO> CreateBackingData()
    {
        var data = new ObservableCollection<CollectionModelDTO>();
        data.Add(new CollectionModelDTO
        {
            RouteNumber = "66", From = "Garston Banks Road", Destination = "Garston MPTE Depot",
            RouteInterval = 30, 
            BusOperateLogo = "mpte.png",
            Sun = true, BusOperatorName = "MPTE"
        });
        data.Add(new CollectionModelDTO
        {
            RouteNumber = "89", From = "Speke Woodend Avenue", Destination = "St Helens",
            RouteInterval = 30, BusOperateLogo = "crosville.png", BusOperatorName = "Crosville"
        });
        data.Add(new CollectionModelDTO
        {
            RouteNumber = "300", From = "Liverpool Skelhorne Street", Destination = "Southport Ribble Bus Station",
            RouteInterval = 120, Sun = true, BusOperateLogo = "ribble.png", BusOperatorName = "Ribble"
        });
        data.Add(new CollectionModelDTO
        {
            RouteNumber = "34", From = "Liverpool Mann Island", Destination = "Manchester Arndale Bus Station",
            RouteInterval = 60, BusOperateLogo = "gmpte.png", BusOperatorName = "GM Buses"
        });
        data.Add(new CollectionModelDTO
        {
            RouteNumber = "79", From = "Netherley", Destination = "Liverpool Pier Head",
            RouteInterval = 10, BusOperateLogo = "mpte.png", Sun = true, BusOperatorName = "MPTE"
        });
        data.Add(new CollectionModelDTO
        {
            RouteNumber = "H20", From = "Runcorn Shopping City", Destination = "Liverpool Mann Island",
            RouteInterval = 60, BusOperateLogo = "crosville.png", BusOperatorName = "Crosville"
        });
        data.Add(new CollectionModelDTO
        {
            RouteNumber = "365", From = "Liverpool Skelhorne Street", Destination = "Skelmersdale Bus Station",
            RouteInterval = 60, BusOperateLogo = "ribble.png", Sun = true, BusOperatorName = "Ribble"
        });
        data.Add(new CollectionModelDTO
        {
            RouteNumber = "320", From = "Wigan Market Street Bus Station",
            Destination = "Liverpool Central Bus Station",
            RouteInterval = 30, Sun = true, BusOperateLogo = "gmpte.png", BusOperatorName = "GM Buses"
        });
        return data;
    }
}