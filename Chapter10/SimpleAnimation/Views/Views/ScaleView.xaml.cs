using SimpleAnimation.Enums;

namespace SimpleAnimation.Views.Views;

public partial class ScaleView : ContentView
{
    public ScaleView(ScaleEnum scale, bool relative = false)
    {
        InitializeComponent();
        Task.Run(()=>ScaleImage(scale, relative));
    }

    async Task ScaleImage(ScaleEnum scale, bool relative)
    {
        switch (scale)
        {
            case ScaleEnum.Default:
                if (!relative)
                {
                    await image.ScaleTo(2, 2000); // size to scale to, time period ms
                }
                else
                {
                    await image.RelScaleTo(2, 2000); // size relative to original size
                }
                break;
            case ScaleEnum.ScaleX:
                await image.ScaleYTo(2, 2000, Easing.Default); // size to scale to, time period ms
                break;
            case ScaleEnum.ScaleY:
                await image.ScaleXTo(2, 2000, Easing.Default); // size to scale to, time period ms
                break;
        }
    }
}