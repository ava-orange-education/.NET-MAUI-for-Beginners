using System.Collections.ObjectModel;
using SimpleAnimation.Views.Views;

namespace SimpleAnimation.Views;

public partial class CompoundPage : ContentPage
{
    public ObservableCollection<string> Options { get; set; }
    
    public CompoundPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        SetupCollection();
    }

    void SetupCollection()
    {
        Options =
        [
            "Compound Animation",
            "Composite Animation"
        ];
    }
    
    void Picker_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        var selection = ((Picker)sender).SelectedIndex;
        selectedView = new CompositeView(selection != 0);
    }
}