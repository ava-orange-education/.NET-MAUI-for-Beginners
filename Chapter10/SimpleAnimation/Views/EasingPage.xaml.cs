using System.Collections.ObjectModel;
using SimpleAnimation.Enums;
using SimpleAnimation.Views.Views;

namespace SimpleAnimation.Views;

public partial class EasingPage : ContentPage
{
    public ObservableCollection<string> Options { get; set; }
    
    public EasingPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        SetupOptions();
    }

    void SetupOptions()
    {
        Options = ["Bounce In", "Bounce Out",
            "Cubic In", "Cubic Out", "Cubic InOut",
            "Linear", 
            "Sin In", "Sin Out", "Sin InOut", 
            "Spring In", "Spring Out"];
    }
    
    void Picker_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = ((Picker)sender).SelectedIndex;
        switch (picker)
        {
            case 0:
                selectedView = new EaseBounce(true);
                break;
            case 1:
                selectedView = new EaseBounce();
                break;
            case 2:
                selectedView = new EaseCubic(InOutEnum.In);
                break;
            case 3:
                selectedView = new EaseCubic(InOutEnum.Out);
                break;
            case 4:
                selectedView = new EaseCubic(InOutEnum.InOut);
                break;
            case 5:
                selectedView =  new EaseLinear();
                break;
            case 6:
                selectedView = new EaseSin(InOutEnum.In);
                break;
            case 7:
               selectedView = new EaseSin(InOutEnum.Out);
                break;
            case 8:
                selectedView =  new EaseSin(InOutEnum.InOut);
                break;
            case 9:
                selectedView = new EaseSpring(true);
                break;
            case 10:
                selectedView =  new EaseSpring();
                break;
        }
    }
}