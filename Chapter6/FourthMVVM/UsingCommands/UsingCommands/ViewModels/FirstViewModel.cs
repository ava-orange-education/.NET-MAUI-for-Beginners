using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace UsingCommands.ViewModels;

public partial class FirstViewModel : ObservableObject
{
    [ObservableProperty]
    string valueClicked;

    [ObservableProperty]
    string valueNameClicked;

    [ObservableProperty]
    string yourName;

    [RelayCommand]
    void MyRelay() => ValueClicked = "Hello World";

    [RelayCommand]
    void MyRelayCommandProperty(object value) => ValueNameClicked = $"Hello Wolrd {value as string}";
    
}