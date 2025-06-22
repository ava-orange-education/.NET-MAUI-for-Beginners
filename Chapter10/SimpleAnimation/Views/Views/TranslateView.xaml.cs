using SimpleAnimation.Enums;

namespace SimpleAnimation.Views.Views;

public partial class TranslateView : ContentView
{
    public TranslateView(TranslateEnum translate)
    {
        InitializeComponent();
        
        Task.Run(()=>TranslateImage(translate));
    }

    async Task TranslateImage(TranslateEnum translate)
    {
        switch (translate)
        {
            case TranslateEnum.Default:
                await image.TranslateTo(-100, -100, 1000); // x, y=y, time
                break;
            case TranslateEnum.TranslateX:
                await image.TranslateTo(-200, 0, 1500);
                break;
            case TranslateEnum.TranslateY:
                await image.TranslateTo(0, 200, 1500);
                break;
        }
    }
}