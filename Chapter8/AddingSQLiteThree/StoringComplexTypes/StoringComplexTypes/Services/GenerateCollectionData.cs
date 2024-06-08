using System.Collections.ObjectModel;
using System.Drawing;
using StoringComplexTypes.Interfaces;
using StoringComplexTypes.Models;

namespace StoringComplexTypes.Services;

public class GenerateCollectionData : IGenerateData
{
    public ObservableCollection<CollectionModel> CreateBackingData()
    {
        return new ObservableCollection<CollectionModel>
        {
            new CollectionModel
            {
                Id = Guid.NewGuid(), ParentId = 1,
                RouteNumber = "66", From = "Garston Banks Road", Destination = "Garston MPTE Depot",
                RouteInterval = 30,
                BusOperateLogo = "mpte.png",
                Sun = true, BusOperatorName = "MPTE"
            },
            new CollectionModel
            {
                Id = Guid.NewGuid(), ParentId = 1,
                RouteNumber = "89", From = "Speke Woodend Avenue", Destination = "St Helens",
                RouteInterval = 30, BusOperateLogo = "crosville.png", BusOperatorName = "Crosville"
            },
            new CollectionModel
            {
                Id = Guid.NewGuid(), ParentId = 1,
                RouteNumber = "300", From = "Liverpool Skelhorne Street", Destination = "Southport Ribble Bus Station",
                RouteInterval = 120, Sun = true, BusOperateLogo = "ribble.png", BusOperatorName = "Ribble"
            },
            new CollectionModel
            {
                Id = Guid.NewGuid(), ParentId = 1,
                RouteNumber = "34", From = "Liverpool Mann Island", Destination = "Manchester Arndale Bus Station",
                RouteInterval = 60, BusOperateLogo = "gmpte.png", BusOperatorName = "GM Buses"
            },
            new CollectionModel
            {
                Id = Guid.NewGuid(), ParentId = 1,
                RouteNumber = "79", From = "Netherley", Destination = "Liverpool Pier Head",
                RouteInterval = 10, BusOperateLogo = "mpte.png", Sun = true, BusOperatorName = "MPTE"
            },
            new CollectionModel
            {
                Id = Guid.NewGuid(), ParentId = 1,
                RouteNumber = "H20", From = "Runcorn Shopping City", Destination = "Liverpool Mann Island",
                RouteInterval = 60, BusOperateLogo = "crosville.png", BusOperatorName = "Crosville"
            },
            new CollectionModel
            {
                Id = Guid.NewGuid(), ParentId = 1,
                RouteNumber = "365", From = "Liverpool Skelhorne Street", Destination = "Skelmersdale Bus Station",
                RouteInterval = 60, BusOperateLogo = "ribble.png", Sun = true, BusOperatorName = "Ribble"
            },
            new CollectionModel
            {
                Id = Guid.NewGuid(), ParentId = 1,
                RouteNumber = "320", From = "Wigan Market Street Bus Station",
                Destination = "Liverpool Central Bus Station",
                RouteInterval = 30, Sun = true, BusOperateLogo = "gmpte.png", BusOperatorName = "GM Buses"
            }
        };
    }

    public ObservableCollection<ComplexCollectionModel> CreateComplexData()
    {
        return new ObservableCollection<ComplexCollectionModel>
        {
            new ComplexCollectionModel
            {
                Id = Guid.NewGuid(), ParentKey = 1,
                Bounds = GetRandomValues(),
                DictionaryLabels = GetDictionaryLabels(),
            },
            new ComplexCollectionModel
            {
                Id = Guid.NewGuid(), ParentKey = 1,
                Bounds = GetRandomValues(),
                DictionaryLabels = GetDictionaryLabels(),
            },
            new ComplexCollectionModel
            {
                Id = Guid.NewGuid(), ParentKey = 1,
                Bounds = GetRandomValues(),
                DictionaryLabels = GetDictionaryLabels(),
            },
            new ComplexCollectionModel
            {
                Id = Guid.NewGuid(), ParentKey = 1,
                Bounds = GetRandomValues(),
                DictionaryLabels = GetDictionaryLabels(),
            },
            new ComplexCollectionModel
            {
                Id = Guid.NewGuid(), ParentKey = 1,
                Bounds = GetRandomValues(),
                DictionaryLabels = GetDictionaryLabels(),
            },
            new ComplexCollectionModel
            {
                Id = Guid.NewGuid(), ParentKey = 1,
                Bounds = GetRandomValues(),
                DictionaryLabels = GetDictionaryLabels(),
            },
            new ComplexCollectionModel
            {
                Id = Guid.NewGuid(), ParentKey = 1,
                Bounds = GetRandomValues(),
                DictionaryLabels = GetDictionaryLabels(),
            },
            new ComplexCollectionModel
            {
                Id = Guid.NewGuid(), ParentKey = 1,
                Bounds = GetRandomValues(),
                DictionaryLabels = GetDictionaryLabels(),
            }
        };

        Rectangle GetRandomValues() => new Rectangle
        {
            Height = new Random().Next(0,600),
            Width = new Random().Next(0, 480),
            X = new Random().Next(0, 150),
            Y = new Random().Next(0, 300)
        };

        List<string> GetDictionaryLabels()
        {
            var guid = Guid.NewGuid();
            return new List<string> 
            { 
               "Hello", $"World (Id = {guid})" 
            };
        };
    }
}