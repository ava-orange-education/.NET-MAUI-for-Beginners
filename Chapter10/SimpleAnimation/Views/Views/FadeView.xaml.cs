namespace SimpleAnimation.Views.Views;

public partial class FadeView : ContentView
{
    public FadeView()
    {
        InitializeComponent();
        Task.Run(StartFade);
    }

    async Task StartFade()
    {
        image.Opacity = 0;
        await image.FadeTo(1, 2500); // 2.5 seconds
    }
}