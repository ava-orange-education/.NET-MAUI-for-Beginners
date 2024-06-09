using SQLiteSypher.Models;
using System.Collections.ObjectModel;

namespace SQLiteSypher.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // initialise the DB data
            await ViewModel.SetupDBData();

            // initialise the viewmodel
            await ViewModel.SetupData();

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
                        routeview.ItemsSource = new ObservableCollection<CollectionModelDTO>();
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

}
