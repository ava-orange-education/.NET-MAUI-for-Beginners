namespace LoadingImages;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }
    
    async void TapGestureRecognizer_OnTapped(object? sender, TappedEventArgs e)
    {
        var dir = FileSystem.Current.AppDataDirectory;
        var path = Path.Combine(dir, "image.txt");
        try
        {
            byte[] image = Convert.FromBase64String(path);
            using (MemoryStream ms = new MemoryStream(image))
            {
                sourceImage.Source = ImageSource.FromStream(() => ms);
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            throw;
        }
    }
}