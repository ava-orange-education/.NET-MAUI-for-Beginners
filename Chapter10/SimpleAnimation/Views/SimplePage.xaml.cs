using System.Collections.ObjectModel;
using SimpleAnimation.Enums;
using SimpleAnimation.Views.Views;

namespace SimpleAnimation.Views;

public partial class SimplePage : ContentPage
{
    public ObservableCollection<string> Options { get; set; }
    
    public SimplePage()
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
            "Rotation (X and Y)", "Rotation (X)", "Rotation (Y)", "Rotate Relative",
            "ScaleTo (X and Y)", "ScaleTo (X)", "ScaleTo (Y)", "ScaleTo Relative",
            "Scale and Rotate Achored",
            "TranslateTo (X and Y)", "TranslateTo (X)", "TranslateTo (Y)",
            "Fade",
            "Cancel Animation"
        ];
    }
    
    private void Picker_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = ((Picker)sender).SelectedItem;
        switch (picker)
        {
            case 0:
                selectedView = new RotateView(RotateEnum.Both);
                break;
            case 1:
                selectedView =  new RotateView(RotateEnum.X);
                break;
            case 2:
                selectedView =  new RotateView(RotateEnum.Y);
                break;
            case 3:
                selectedView = new RotateView(RotateEnum.Both, true);
                break;
            case 4:
                selectedView = new ScaleView(ScaleEnum.Default);
                break;
            case 5:
                selectedView = new ScaleView(ScaleEnum.ScaleX);
                break;
            case 6:
                selectedView = new ScaleView(ScaleEnum.ScaleY);
                break;
            case 7:
                selectedView = new ScaleView(ScaleEnum.Default, true);
                break;
            case 8:
                selectedView = new ScaleRotateAnchors();
                break;
            case 9:
                selectedView = new TranslateView(TranslateEnum.Default);
                break;
            case 10:
                selectedView = new TranslateView(TranslateEnum.TranslateX);
                break;
            case 11:
                selectedView =  new TranslateView(TranslateEnum.TranslateY);
                break;
            case 12:
                selectedView = new FadeView();
                break;
            case 13:
                selectedView = new CancelAnimation();
                break;
        }
    }
}