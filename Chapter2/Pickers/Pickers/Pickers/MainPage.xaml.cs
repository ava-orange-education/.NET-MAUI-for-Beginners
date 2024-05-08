using System.Collections.ObjectModel;

namespace Pickers;

public partial class MainPage : ContentPage
{
    TimeSpan uITime;
    public TimeSpan UITime
    {
        get => uITime;
        set => uITime = value;
    }

    ObservableCollection<string> pickerSource;
    public ObservableCollection<string> PickerSource
    {
        get => pickerSource;
        set => pickerSource = value;
    }

    public MainPage()
    {
        InitializeComponent();
        UITime = DateTime.Now.TimeOfDay;
        PickerSource = new ObservableCollection<string>
        { 
            "Red", "Yellow", "Pink", "Green", "Orange", "Purple", "Blue"
        };
        BindingContext = this;
    }

    void DatePicker_OnDateSelected(object? sender, DateChangedEventArgs e)
    {
        uiLabel.Text = $"Date picked {e.NewDate.ToLongDateString()}";
    }

    void TimePicker_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (uiLabel2  != null)
            uiLabel2.Text = $"Time picked {timePicker.Time}";
    }

    void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (uiLabel3 != null)
            uiLabel3.Text = $"Item selected {PickerSource[picker.SelectedIndex]}";
    }
}