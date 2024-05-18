using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CollectionView_Empty;

public partial class MainPage : ContentPage, INotifyPropertyChanged
{

    ObservableCollection<string> emptyCollection;
    public ObservableCollection<string> EmptyCollection
    {
        get => emptyCollection;
        set
        {
            emptyCollection = value;
            OnPropertyChanged("Collection");
        }
    }
    
    public MainPage()
    {
        InitializeComponent();
        EmptyCollection = new ObservableCollection<string>(); // empty collection
        BindingContext = this;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        
        // event registered to intercept when a value has changed
        PropertyChanged += PropertyHasChanged;
    }

    void PropertyHasChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            case "Collection":
                if (empty.ItemsSource != null)
                {
                    empty.ItemsSource = new ObservableCollection<string>();
                    MainThread.BeginInvokeOnMainThread(() => empty.ItemsSource = EmptyCollection);
                }
                break;
        }
    }
    
    void Button_OnClicked(object? sender, EventArgs e)
    {
        EmptyCollection.Add("");
    }
}