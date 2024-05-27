using AddingMvvm.Interfaces;
using AddingMvvm.Services;
using AddingMvvm.ViewModels;

namespace AddingMvvm.Helpers
{
    public static class InjectionContainer
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            var i = new ServiceCollection();
            i.AddSingleton<IGenerateData, GenerateCollectionData>()
                .AddTransient<BusViewModel>();
            
            services = i;
            return services;
        }
    }
}
