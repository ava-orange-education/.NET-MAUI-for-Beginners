namespace CheckAndRadio;

public partial class MainPage : ContentPage
{
    bool _isChecked = false;

    public bool IsChecked
    {
        get => _isChecked;
        set => _isChecked = value;
    }

    bool _radio1Selected = true;

    public bool Radio1Selected
    {
        get => _radio1Selected;
        set => _radio1Selected = value;
    }

    bool _radio2Selected = false;

    public bool Radio2Selected
    {
        get => _radio2Selected;
        set => _radio2Selected = value;
    }

    public MainPage()
    {
        InitializeComponent();
        BindingContext = this;
    }

    void CheckBox_OnCheckedChanged(object? sender, CheckedChangedEventArgs e)
    {
        IsChecked = !IsChecked;
        uiLabel.Text = IsChecked ? "Uncheck the checkbox" : "Click the checkbox";
    }

    void RadioButton_OnCheckedChanged(object? sender, CheckedChangedEventArgs e)
    {
        var radioButton = ((RadioButton)sender).ClassId;

        if (radioButton.Contains("Radio"))
        {
            switch (radioButton)
            {
                case "Radio1":
                    Radio1Selected = !Radio1Selected;
                    break;
                case "Radio2":
                    Radio2Selected = !Radio2Selected;
                    break;
            }
        }
        else
        {
            var item = "";
            switch (radioButton)
            {
                case "Grp1":
                    item = "1";
                    break;
                case "Grp2":
                    item = "2";
                    break;
                case "Grp3":
                    item = "3";
                    break;
            }

            if (uiLabel2 != null)
                uiLabel2.Text = $"Option {item} selected";
        }
    }
}