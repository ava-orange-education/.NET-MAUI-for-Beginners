namespace SimpleAnimation.Views.Views;

public partial class EaseLinear : ContentView
{
    public EaseLinear()
    {
        InitializeComponent();
        Task.Run(EasingLinearAnimation);
    }

    async Task EasingLinearAnimation()
    {
        await image.RotateTo(180, 2500, Easing.Linear);
    }
}