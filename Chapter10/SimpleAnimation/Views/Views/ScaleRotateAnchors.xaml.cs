namespace SimpleAnimation.Views.Views;

public partial class ScaleRotateAnchors : ContentView
{
    public ScaleRotateAnchors()
    {
        InitializeComponent();

        Task.Run(ScaleRotateImage);
    }

    async Task ScaleRotateImage()
    {
        double radius = Math.Min(absoluteView.Width, absoluteView.Height) / 2;
        image.AnchorY = radius / image.Height;
        await image.RotateTo(360, 2000);
        
    }
}