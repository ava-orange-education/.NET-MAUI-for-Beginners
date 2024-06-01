namespace UsingMessages.Views;

public partial class FirstPage : ContentPage
{
    public FirstPage()
    {
        InitializeComponent();
    }

    void Button_OnClicked(object? sender, EventArgs e) => ViewModel.MoveToSecondView();
}