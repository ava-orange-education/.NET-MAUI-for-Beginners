using System.Collections.ObjectModel;
using AddingMvvm.Models;

namespace AddingMvvm.Views;

public partial class MainPage : ContentPage
{
   public MainPage()
    {
        InitializeComponent();
    }
   
    protected override void OnAppearing()
    {
        base.OnAppearing();

        // initialise the viewmodel
        ViewModel.InitData();
        
        // event registered to intercept when a value has changed
        PropertyChanged += PropertyHasChanged;
    }

    void PropertyHasChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            case "Route":
                if (routeview.ItemsSource != null)
                {
                    routeview.ItemsSource = new ObservableCollection<CollectionModel>();
                    MainThread.BeginInvokeOnMainThread(() => routeview.ItemsSource = ViewModel.RouteInformation);
                }
                break;
        }
    }
    
    void Picker_OnSelectedIndexChanged(object? sender, EventArgs e)
    {
        var picked = ((Picker)sender)?.SelectedIndex;
        picker.Title = "";
        ViewModel.ChangePickedItem((int)picked);
    }
}