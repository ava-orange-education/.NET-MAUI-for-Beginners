namespace SimpleAnimation.Views.Views;

public partial class EaseBounce : ContentView
{
    public EaseBounce(bool isout = false)
    {
        InitializeComponent();
        
        Task.Run(()=>EasingBounceAnimation(isout));
    }

    async Task EasingBounceAnimation(bool isout)
    {
        await image.ScaleTo(2, 2500, !isout ? Easing.BounceOut: Easing.BounceIn);
    }
}