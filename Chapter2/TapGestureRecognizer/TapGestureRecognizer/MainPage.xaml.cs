using System.Windows.Input;

namespace TapGestureRecognizer;

public partial class MainPage : ContentPage
{
    bool _selected = false;
    bool _otherSelected = false;
    bool _imageSelected = false;
    bool _image2Seleted = false;
    public ICommand LabelTappedCommand { get; private set; }
    public ICommand ImageTappedCommand { get; private set; }

    public MainPage()
    {
        InitializeComponent();
        
        LabelTappedCommand = new Command(OnTapped);
        ImageTappedCommand = new Command<object>(OnImageTapped);
        
        BindingContext = this;
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

    void OnImageTapped(object o)
    {
        var st = o as string;
        switch (o)
        {
            case "ImageClicked":
                uiLabel3.Text = !_imageSelected ? "Left Pic" : "Left again";
                _imageSelected = !_imageSelected;
                break;
            case "Image2Clicked":
                image.Background = !_image2Seleted ? Colors.Aquamarine : Colors.Chocolate;
                _image2Seleted = !_image2Seleted;
                break;
        }
    }
}