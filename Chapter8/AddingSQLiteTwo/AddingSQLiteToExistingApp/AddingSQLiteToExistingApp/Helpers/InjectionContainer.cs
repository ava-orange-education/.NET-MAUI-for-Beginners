using AddingSQLiteToExistingApp.Database;
using AddingSQLiteToExistingApp.ViewModels;
using AddingSQLiteToExistingApp.Interfaces;
using AddingSQLiteToExistingApp.Services;

namespace AddingSQLite.Helpers
{
    public static class InjectionContainer
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            var i = new ServiceCollection();

            i.AddSingleton<IRepository, SqLiteRepository>().
                AddSingleton<IGenerateData, GenerateCollectionData>().
            AddTransient<FirstViewModel>();

            services = i;

            return services;
        }
    }
}
