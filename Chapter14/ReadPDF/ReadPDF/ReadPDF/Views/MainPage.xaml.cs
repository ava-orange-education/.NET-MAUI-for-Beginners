using System.ComponentModel;

namespace ReadPDF.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        
        ViewModel.Setup();
        
        ViewModel.PropertyChanged += ViewModelOnPropertyChanged;
    }

    void ViewModelOnPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "SelectedRoute")
        {
            MainThread.InvokeOnMainThreadAsync(() => pdfview.Source = ViewModel.SelectedRoute);
        }
    }

    void Picker_OnSelectedIndexChanged(object? sender, EventArgs e)
    {
        ViewModel.ChooseTimetableCommand.Execute(picker.SelectedIndex);
    }
}