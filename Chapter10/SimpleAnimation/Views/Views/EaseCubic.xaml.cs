using SimpleAnimation.Enums;

namespace SimpleAnimation.Views.Views;

public partial class EaseCubic : ContentView
{
    public EaseCubic(InOutEnum inoiut)
    {
        InitializeComponent();
        
        Task.Run(()=>EasingCubicAnimation(inoiut));
    }

    async Task EasingCubicAnimation(InOutEnum inoiut)
    {
        switch (inoiut)
        {
            case InOutEnum.In:
                await image.ScaleTo(2, 2500, Easing.CubicOut);
                break;
            case InOutEnum.Out:
                await image.ScaleTo(2, 2500, Easing.CubicOut);
                break;
            case InOutEnum.InOut:
                await image.ScaleTo(2, 2500, Easing.CubicOut);
                break;
        }
    }
}