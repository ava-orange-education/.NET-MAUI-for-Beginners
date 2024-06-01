using CommunityToolkit.Mvvm.Messaging;
using UsingMessages.ViewModels;

namespace UsingMessages.Helpers
{
    public static class InjectionContainer
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            var i = new ServiceCollection();
            i.AddSingleton<IMessenger>(WeakReferenceMessenger.Default)
                .AddTransient<FirstViewModel>()
                .AddScoped<SecondViewModel>();
            
            services = i;
            return services;
        }
    }
}
