using System.Collections.ObjectModel;
using System.ComponentModel;
using HeaderAndFooter.Helpers;
using HeaderAndFooter.Models;

namespace HeaderAndFooter;

public partial class MainPage : ContentPage, INotifyPropertyChanged
{
    ObservableCollection<CollectionModel>? routeInformation;
    
    public ObservableCollection<CollectionModel>? RouteInformation
    {
        get => routeInformation;
        set
        {
            if (value?.Count != 0)
            {
                routeInformation = value;
                OnPropertyChanged("Route");
            }
        }
    }
    

    public MainPage()
    {
        InitializeComponent();

        // get the data from a different class=
        var info = new GenerateCollectionData().CreateBackingData();

        RouteInformation = info.OrderBy(t => t.BusOperatorName).ToList().ToObservable();
        
        // set the binding context
        BindingContext = this;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // event registered to intercept when a value has changed
        //PropertyChanged += PropertyHasChanged;
    }

    void PropertyHasChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            case "Route":
                if (routeview.ItemsSource != null)
                {
                    routeview.ItemsSource = new ObservableCollection<CollectionModel>();
                    MainThread.BeginInvokeOnMainThread(() => routeview.ItemsSource = RouteInformation);
                }

                break;
        }
    }
}