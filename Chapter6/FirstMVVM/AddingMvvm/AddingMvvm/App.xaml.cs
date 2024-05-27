namespace AddingMvvm;

public partial class App : Application
{
    // create a property for the ServiceProvider
    public static IServiceProvider Service { get; set; }
    
    public App()
    {
        //call the Service and store in the Service property
        Service = Startup.Init();
        
        InitializeComponent();

        MainPage = new AppShell();
    }
}