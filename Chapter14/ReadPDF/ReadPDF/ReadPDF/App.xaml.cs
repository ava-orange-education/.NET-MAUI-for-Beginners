namespace ReadPDF;

public partial class App : Application
{
    public static IServiceProvider Service { get; set; }
    
    public App()
    {
        Service = Startup.Init();
        
        InitializeComponent();

        MainPage = new AppShell();
    }
}