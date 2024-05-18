using System.Collections.ObjectModel;
using System.ComponentModel;
using CollectionView_Templated.Helpers;
using CollectionView_Templated.Models;
using CollectionView_Templated.Views;

namespace CollectionView_Templated;

public partial class MainPage : ContentPage, INotifyPropertyChanged
{
    ObservableCollection<CollectionModel>? routeInformation;
    readonly ObservableCollection<CollectionModel>? unsorted;
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
    
    public int option { get; set; } = 4;

    List<string>? orderByOptions;

    public List<string>? OrderByOptions
    {
        get => orderByOptions;
        set => orderByOptions = value; 
    }
    
    public MainPage()
    {
        InitializeComponent();
        
        // get the data from a different class=
        RouteInformation = new GenerateCollectionData().CreateBackingData();

        // do it again as we need a copy of the unsorted list
        unsorted = new GenerateCollectionData().CreateBackingData();
        
        OrderByOptions = new List<string>{"Operator", "Route Number", "Frequency", 
            "Not Sunday", "Reset sort"};
        
        // set the binding context
        BindingContext = this;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        PropertyChanged += PropertyHasChanged;
    }

    void Picker_OnSelectedIndexChanged(object? sender, EventArgs e)
    {
        var picked = ((Picker)sender)?.SelectedIndex;
        picker.Title = "";
        option = (int)picked;
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
    
    void ItemSelected_Clicked(object? sender, SelectionChangedEventArgs e)
    {
        var template = ((CollectionView)sender).ItemTemplate;

        var frame = (CollectionTemplateView)template.LoadTemplate();
        if (frame != null)
        {
            var theframe = frame.Content;
            if (theframe.BackgroundColor is null)
            {
                MainThread.BeginInvokeOnMainThread(() => theframe.BackgroundColor = Colors.Beige);
            }
        }
    }
}