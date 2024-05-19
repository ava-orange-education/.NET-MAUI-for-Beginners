using Microsoft.Maui.Layouts;

namespace AbsLayout_Proportional;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        // see Chapter 3 for an explanation of how these figures work
        Rect[] fractionalRects =
        {
            new Rect(0.05, 0.1, 0.90, 0.1),    // outer top
            new Rect(0.05, 0.8, 0.90, 0.1),    // outer bottom
            new Rect(0.05, 0.1, 0.05, 0.8),    // outer left
            new Rect(0.90, 0.1, 0.05, 0.8),    // outer right

            new Rect(0.15, 0.3, 0.70, 0.1),    // inner top
            new Rect(0.15, 0.6, 0.70, 0.1),    // inner bottom
            new Rect(0.15, 0.3, 0.05, 0.4),    // inner left
            new Rect(0.80, 0.3, 0.05, 0.4),    // inner right
        };

        foreach(var fractionalRect in fractionalRects)
        {
            var layoutBounds = new Rect
            {
                // Proportional coordinate calculations
                X = fractionalRect.X / (1 - fractionalRect.Width),
                Y = fractionalRect.Y / (1 - fractionalRect.Height),
                Width = fractionalRect.Width,
                Height = fractionalRect.Height
            };

            var boxView = new BoxView
            {
                Color = Colors.DarkBlue
            };

            var layout = new AbsoluteLayout { boxView };
            layout.SetLayoutBounds(boxView, layoutBounds);
            layout.SetLayoutFlags(boxView, AbsoluteLayoutFlags.All);
            
            absoluteLayout.Add(layout);
        }
    }

    void OnContentViewSizeChanged(object sender, EventArgs args)
    {
        ContentView contentView = (ContentView)sender;

        // Figure has an aspect ratio of 2:1
        double height = Math.Min(contentView.Width / 2, contentView.Height);
        absoluteLayout.WidthRequest = 2 * height;
        absoluteLayout.HeightRequest = height;
    }
}