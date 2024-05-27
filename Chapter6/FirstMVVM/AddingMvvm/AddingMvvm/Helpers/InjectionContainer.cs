namespace AddingMvvm.Helpers
{
    public static class InjectionContainer
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            var i = new ServiceCollection();

            services = i;

            return services;
        }

        [Obsolete]
        public static IServiceCollection ConfigureViewModels(this IServiceCollection services)
        {
            return services;
        }
    }
}
