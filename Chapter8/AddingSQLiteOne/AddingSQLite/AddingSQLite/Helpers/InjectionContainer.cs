using CommunityToolkit.Mvvm.Messaging;
using AddingSQLite.Database;
using AddingSQLite.ViewModels;
using AddingSQLite.Interfaces;

namespace AddingSQLite.Helpers
{
    public static class InjectionContainer
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            var i = new ServiceCollection();

            i.AddSingleton<IMessenger>(WeakReferenceMessenger.Default).
            AddSingleton<IRepository, SqLiteRepository>().
            AddTransient<FirstViewModel>();

            services = i;

            return services;
        }
    }
}
