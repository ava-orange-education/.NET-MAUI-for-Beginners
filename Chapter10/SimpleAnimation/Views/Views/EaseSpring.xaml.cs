namespace SimpleAnimation.Views.Views;

public partial class EaseSpring : ContentView
{
    public EaseSpring(bool isout = false)
    {
        InitializeComponent();
        
        Task.Run(()=>EasingSpringAnimation(isout));
    }

    async Task EasingSpringAnimation(bool isout)
    {
        await image.RotateTo(270, 2500, !isout ? Easing.SpringOut: Easing.SpringIn);
    }
}