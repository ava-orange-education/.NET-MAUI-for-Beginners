using StoringComplexTypes.Database;
using StoringComplexTypes.Interfaces;
using SQLite;

namespace StoringComplexTypes
{
    public partial class App : Application
    {
#nullable enable
        IRepository? repository => Startup.ServiceProvider.GetService<IRepository>();
#nullable disable

        // ServiceProvider
        public static IServiceProvider Service { get; set; }

        // SQLiteAsyncConnection string
        public static SQLiteAsyncConnection SQLConnection { get; set; }

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
        path = Path.Combine(path, "addsqlite.db");

        try
        {
            App.SQLConnection = new SQLiteAsyncConnection(path, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
        }
        catch (Exception ex)
        {
#if DEBUG
            Console.WriteLine($"Connection could  not be made : ex.Message = {ex.Message} - inner = {ex.InnerException?.Message}");
#endif
        }
    }
}
