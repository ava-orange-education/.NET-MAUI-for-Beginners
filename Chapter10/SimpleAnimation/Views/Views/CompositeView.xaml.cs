namespace SimpleAnimation.Views.Views;

public partial class CompositeView : ContentView
{
    public CompositeView(bool compound = false)
    {
        InitializeComponent();
        Task.Run(()=>CompoundAnimation(compound));
    }

    async Task CompoundAnimation(bool compound)
    {
        if (!compound)
        {
            await image.TranslateTo(-100, 0, 1000);    // Move image left
            await image.TranslateTo(-100, -100, 1000); // Move image diagonally up and left
            await image.TranslateTo(100, 100, 2000);   // Move image diagonally down and right
            await image.TranslateTo(0, 100, 1000);     // Move image left
            await image.TranslateTo(0, 0, 1000); 
        }
        else
        {
            image.RotateTo(360, 4000);
            await image.ScaleTo(2, 2000);
            await image.ScaleTo(1, 2000);
        }
    }
}