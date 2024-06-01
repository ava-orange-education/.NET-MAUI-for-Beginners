using UsingCommands.ViewModels;

namespace UsingCommands.Helpers
{
    public static class InjectionContainer
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            var i = new ServiceCollection();
            i.AddTransient<FirstViewModel>();
            
            services = i;
            return services;
        }
    }
}
