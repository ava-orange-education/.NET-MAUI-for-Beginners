namespace SimpleAnimation.Views.Views;

public partial class CancelAnimation : ContentView
{
    public CancelAnimation()
    {
        InitializeComponent();
        Task.Run(CancelAnimations);
    }

    async Task CancelAnimations()
    {
        await image.RotateTo(360, 60000);
    }

    void Button_OnClicked(object sender, EventArgs e)
    {
        Task.Run(image.CancelAnimations);
    }
}