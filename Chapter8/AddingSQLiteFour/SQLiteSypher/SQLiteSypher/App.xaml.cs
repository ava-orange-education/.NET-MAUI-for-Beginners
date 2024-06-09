using SQLite;
using SQLiteSypher.Database;
using SQLiteSypher.Interfaces;

namespace SQLiteSypher
{
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
        // to create a new GUID, use https://www.guidgenerator.com/ and unset the hyphens tickbox
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

            // db3 signifies a secure database
            path = Path.Combine(path, "addsqlite.db3");

            // Params for the connection string
            // path to the database
            // creation flags
            // use ticks (true or false)
            // DB secure string (the longer and more complex, the better)

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
}
