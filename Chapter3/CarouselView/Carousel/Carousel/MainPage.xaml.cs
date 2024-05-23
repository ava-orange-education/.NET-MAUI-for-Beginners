using System.Collections.ObjectModel;
using Carousel.Models;

namespace Carousel;

public partial class MainPage : ContentPage
{
    public ObservableCollection<Transport> BusRotation { get; set; }

    public MainPage()
    {
        InitializeComponent();
        BusRotation = GetBuses();
        BindingContext = this;
    }

    ObservableCollection<Transport> GetBuses()
    {
        return new ObservableCollection<Transport>
        {
            new Transport { Filename = "gtl.jpg", OperatorName = "Glanvale Transport" },
            new Transport { Filename = "liverpoolcorp.jpg", OperatorName = "Liverpool Corporation" },
            new Transport { Filename = "liverpoolcorp2.jpg", OperatorName = "Liverpool Corporatiion" },
            new Transport { Filename = "merseybus.jpg", OperatorName = "Merseybus" },
            new Transport { Filename = "mpte1.jpg", OperatorName = "MPTE" },
            new Transport { Filename = "mpte2.jpg", OperatorName = "MPTE" },
            new Transport { Filename = "mpte3.jpg", OperatorName = "MPTE" },
            new Transport { Filename = "mpte4.jpg", OperatorName = "MPTE" },
            new Transport { Filename = "wirral.jpg", OperatorName = "Wirral and District" },
            new Transport { Filename = "wirral2.jpg", OperatorName = "Wirral and District" }
        };
    }
}