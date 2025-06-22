using SimpleAnimation.Enums;

namespace SimpleAnimation.Views.Views;

public partial class EaseSin : ContentView
{
    public EaseSin(InOutEnum inout)
    {
        InitializeComponent();

        Task.Run(() => EasingSinAnimation(inout));
    }

    async Task EasingSinAnimation(InOutEnum inoiut)
    {
        switch (inoiut)
        {
            case InOutEnum.In:
                await image.ScaleTo(1.4, 2500, Easing.SinIn);
                break;
            case InOutEnum.Out:
                await image.ScaleTo(1.4, 2500, Easing.SinOut);
                break;
            case InOutEnum.InOut:
                await image.ScaleTo(1.4, 2500, Easing.SinInOut);
                break;
        }
    }

}