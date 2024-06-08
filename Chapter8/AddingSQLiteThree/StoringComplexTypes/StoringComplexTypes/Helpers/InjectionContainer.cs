using StoringComplexTypes.Database;
using StoringComplexTypes.ViewModels;
using StoringComplexTypes.Interfaces;
using StoringComplexTypes.Services;

namespace StoringComplexTypes.Helpers
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
