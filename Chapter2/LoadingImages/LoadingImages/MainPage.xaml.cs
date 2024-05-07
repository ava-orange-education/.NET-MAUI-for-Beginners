namespace LoadingImages;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }
    
    async void TapGestureRecognizer_OnTapped(object? sender, TappedEventArgs e)
    {
        try
        {
            var data = "";
            using Stream fileStream = await FileSystem.Current.OpenAppPackageFileAsync("base64_1.txt");
            using StreamReader reader = new StreamReader(fileStream);
            data = reader.ReadToEnd();
            byte[] image = Convert.FromBase64String(data);
            MemoryStream ms = new (image);
            sourceImage.Source = ImageSource.FromStream(() => ms);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            throw;
        }
    }
}