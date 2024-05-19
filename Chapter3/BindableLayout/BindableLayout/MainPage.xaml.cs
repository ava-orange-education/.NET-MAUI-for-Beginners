using BindableLayout.Models;

namespace BindableLayout;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new AvatarInfo();
    }

    
}