namespace ImageImageButton;

public partial class MainPage : ContentPage
{
    bool _selected = false;
    public MainPage()
    {
        InitializeComponent();
    }

    void ImageButton_OnClicked(object? sender, EventArgs e)
    {
        uiLabel.Text = !_selected ? "Hello!" : "";
        _selected = !_selected;
    }
}