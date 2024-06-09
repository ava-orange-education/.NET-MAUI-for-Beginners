using SQLiteSypher.Database;
using SQLiteSypher.ViewModels;
using SQLiteSypher.Interfaces;
using SQLiteSypher.Services;

namespace SQLiteSypher.Helpers
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
