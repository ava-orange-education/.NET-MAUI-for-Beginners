using System.Collections.ObjectModel;
using AddingSQLiteToExistingApp.Helpers;
using AddingSQLiteToExistingApp.Interfaces;
using AddingSQLiteToExistingApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AddingSQLiteToExistingApp.ViewModels;

public partial class FirstViewModel : ObservableObject
{
#nullable enable
    IRepository? repository => Startup.ServiceProvider.GetService<IRepository>();
    IGenerateData? data => Startup.ServiceProvider.GetService<IGenerateData>();

    
    readonly ObservableCollection<CollectionModel>? unsorted;
    
    
    [ObservableProperty]
    ObservableCollection<CollectionModel>? routeInformation;
    
    [ObservableProperty]
    List<string>? orderByOptions;
#nullable disable
    
    public int option { get; set; } = 4;

    public FirstViewModel()
    {
        unsorted = Task.Run(async()=> await CreateData()).Result;
    }
    
    public async Task SetupDBData()
    {
        if ((await repository.Count<CollectionModelDTO>()) != 0)
        {
            var _ = await repository.GetList<CollectionModelDTO>();
            await repository.DeleteList(_);
        }

        await repository.SaveListData(data.CreateBackingData().ToList());
    }

    async Task<ObservableCollection<CollectionModel>> CreateData(ObservableCollection<CollectionModelDTO> collection = null)
    {
        var info = collection != null ? collection : data.CreateBackingData();
        var dto = new ObservableCollection<CollectionModel>();
        foreach (var d in info)
        {
            var tr = new CollectionModel
            {
                RouteNumber = d.RouteNumber,
                RouteInterval = d.RouteInterval,
                From = d.From,
                Destination = d.Destination,
                MonToFri = d.MonToFri,
                Sun = d.Sun,
                Sat = d.Sat,
                BusOperatorName = d.BusOperatorName,
            };
            try
            {
               tr.BusOperateLogo = ImageSource.FromFile(d.BusOperateLogo);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            dto.Add(tr);
        }

        return dto;
    }

    public async Task SetupData()
    {
        var info = data.CreateBackingData();
        info = (await repository.GetList<CollectionModelDTO>()).ToObservable();

        RouteInformation = await CreateData(info);
 
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