using System.Collections.ObjectModel;
using AddingMvvm.Helpers;
using AddingMvvm.Interfaces;
using AddingMvvm.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AddingMvvm.ViewModels;

public partial class BusViewModel : ObservableObject
{
    #nullable enable
    IGenerateData? data => Startup.ServiceProvider.GetService<IGenerateData>();
    #nullable disable
    
    readonly ObservableCollection<CollectionModel>? unsorted;
    
    [ObservableProperty]
    ObservableCollection<CollectionModel>? routeInformation;
    
    [ObservableProperty]
    List<string>? orderByOptions;

    public int option { get; set; } = 4;

    public BusViewModel()
    {
        unsorted = data.CreateBackingData();
    }

    public void InitData()
    {
        RouteInformation = data.CreateBackingData();
        OrderByOptions = new List<string>{"Operator", "Route Number", "Frequency", 
            "Not Sunday", "Reset sort"};
    }

    public void ChangePickedItem(int value)
    {
        option = value;
        
        RouteInformation = unsorted;
        
        switch (option)
        {
            case 0:
                RouteInformation = RouteInformation?.OrderBy(t => t.BusOperatorName).ToList().ToObservable(); 
                break;
            case 1:
                RouteInformation = RouteInformation?.OrderBy(t => t.RouteNumber).ToList().ToObservable();
                break;
            case 2:
                RouteInformation = RouteInformation?.OrderBy(t => t.RouteInterval).ToList().ToObservable();
                break;
            case 3:
                RouteInformation = RouteInformation?.Where(t => t.Sun).ToList().ToObservable();
                break;
            case 4:
                RouteInformation = unsorted;
                break;
        }
    }
}