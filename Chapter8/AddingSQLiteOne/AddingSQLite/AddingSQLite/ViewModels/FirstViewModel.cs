using System.Collections.ObjectModel;
using AddingSQLite.Helpers;
using AddingSQLite.Interfaces;
using AddingSQLite.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AddingSQLite.ViewModels;

public partial class FirstViewModel : ObservableObject
{
#nullable enable
    IRepository? repository => Startup.ServiceProvider.GetService<IRepository>();
#nullable disable

    [ObservableProperty]
    ObservableCollection<AddingSQLiteDataModel> dataModel;

    [ObservableProperty]
    int dbCount;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor((nameof(StoreDataCommand)))]
    string userName;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(StoreDataCommand))]
    string randomInformation;

    [RelayCommand(CanExecute = nameof(CodeComplete))]
    async Task StoreData() =>  await StoreInDatabase();
    
    async Task StoreInDatabase()
    {
        await repository.SaveData(new AddingSQLiteDataModel
            { DataName = UserName, DataInformation = RandomInformation });
        DbCount = await repository.Count<AddingSQLiteDataModel>();
        UserName = RandomInformation = string.Empty;
        
        // read the data back in
        var data = await repository.GetList<AddingSQLiteDataModel>();
        DataModel.Clear();
        DataModel = data.ToObservable();
    }

    bool CodeComplete => !string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(RandomInformation);

}