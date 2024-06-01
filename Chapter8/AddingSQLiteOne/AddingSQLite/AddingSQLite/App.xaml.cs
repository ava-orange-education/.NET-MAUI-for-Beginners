using AddingSQLite.Database;
using AddingSQLite.Interfaces;
using SQLite;

namespace AddingSQLite;

public partial class App : Application
{
    // SQLite property
    #nullable enable
    IRepository? repository => Startup.ServiceProvider.GetService<IRepository>();
    #nullable disable
    
    // ServiceProvider
    public static IServiceProvider Service { get; set; }
    
    // SQLiteAsyncConnection string
    public static SQLiteAsyncConnection SQLConnection { get; set; }
    
    // Database GUID for secure DB
    static string DBGuid { get; set; } = "abc099d39b6f4c91a5067c27560a844b";
    
    public App()
    {
        Service = Startup.Init();
        InitializeComponent();

        // initialise the SQLite connection
        SetupSQLiteConnection();
        
        // create SQLite repositiory class
        new SqLiteRepository();
        
        MainPage = new AppShell();
    }
    
    void SetupSQLiteConnection()
    {
        var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        path = Path.Combine(path, "addsqlite.db3");

        var options = new SQLiteConnectionString(path, SQLiteOpenFlags.Create | 
                                                       SQLiteOpenFlags.ReadWrite, true, DBGuid);
        try
        {
            App.SQLConnection = new SQLiteAsyncConnection(options);
        }
        catch (Exception ex)
        {
#if DEBUG
            Console.WriteLine($"Connection could  not be made : ex.Message = {ex.Message} - inner = {ex.InnerException?.Message}");
#endif
        }
    }
}