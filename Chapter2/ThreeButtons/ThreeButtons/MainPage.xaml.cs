namespace ThreeButtons;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    void Button_OnClicked(object? sender, EventArgs e)
    {
        // get the ClassId from the button pressed
        var button = ((Button)sender).ClassId;
        // change the label
        var num = "";
        switch (button)
        {
            case "button1":
                num = "1";
                break;
            case "button2":
                num = "2";
                break;
            case "button3":
                num = "3";
                break;
        }

        uiLabel.Text = $"Button {num} pressed";
    }
}