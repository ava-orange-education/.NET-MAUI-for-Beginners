using SimpleAnimation.Enums;

namespace SimpleAnimation.Views.Views;

public partial class RotateView : ContentView
{
    public RotateView(RotateEnum rotate, bool relative = false)
    {
        InitializeComponent();
        Task.Run(()=>StartRotation(rotate, relative));
    }

    async Task StartRotation(RotateEnum rotate, bool relative)
    {
        if (!relative)
        {
            switch (rotate)
            {
                case RotateEnum.Both:
                    await image.RotateTo(360, 2000); // angle and time for rotation
                    break;
                case RotateEnum.X:
                    await image.RotateXTo(180, 2000);
                    break;
                case RotateEnum.Y:
                    await image.RotateYTo(270, 2000);
                    break;
            }

            image.Rotation = 0;
        }
        else
        {
            await image.RelRotateTo(360, 2000);
        }
    }
}