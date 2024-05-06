using System.Windows.Input;

namespace TapGestureRecognizer;

public partial class MainPage : ContentPage
{
    bool _selected = false;
    bool _otherSelected = false;
    public ICommand LabelTappedCommand { get; set; }

    public MainPage()
    {
        InitializeComponent();
        BindingContext = this;
        LabelTappedCommand = new Command(() =>
        {
            uiLabel2.Text = !_otherSelected ? "Wax on" : "Wax off";
            _otherSelected = !_otherSelected;
        });
    }

    void LabelTapped(object sender, TappedEventArgs e)
    {
        uiLabel.Text = !_selected ? "Hello" : "Goodbye";
        _selected = !_selected;
    }

    void OnTapped()
    {
        uiLabel2.Text = !_otherSelected ? "Wax on" : "Wax off";
        _otherSelected = !_otherSelected;
    }
}