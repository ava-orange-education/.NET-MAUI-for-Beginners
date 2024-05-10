using System.ComponentModel;

namespace SliderStepperSwitch;

public partial class MainPage : ContentPage, INotifyPropertyChanged
{
    double slideValue;
    int stepValue;

    public bool IsToggleOn { get; set; } = false;

    public double SlideValue
    {
        get => slideValue;
        set { slideValue = value; OnPropertyChanged(); }
    }

    public int StepValue
    {
        get => stepValue;
        set { stepValue = value; OnPropertyChanged(); }
    }

    public MainPage()
    {
        InitializeComponent();
        SlideValue = 0;
        StepValue = 0;
        BindingContext = this;
    }

    void Slider_OnDragCompleted(object? sender, EventArgs e)
    {
        SlideValue = ((Slider)sender).Value;
    }

    void Stepper_OnValueChanged(object? sender, ValueChangedEventArgs e)
    {
        StepValue = Convert.ToInt32(e.NewValue);
    }

    void Switch_OnToggled(object? sender, ToggledEventArgs e)
    {
        IsToggleOn = e.Value;
        uiLabel.Text = IsToggleOn ? "On" : "Off";
    }
}