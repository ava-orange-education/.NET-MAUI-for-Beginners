using ReadPDF.Interfaces;
using ReadPDF.Services;
using ReadPDF.ViewModels;

namespace ReadPDF.Helpers;

public static class InjectionContainer
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        var i = new ServiceCollection()
            .AddTransient<PDFReaderViewModel>()
            .AddSingleton<IListAssets, ListResAssets>()
            .AddSingleton<IFormFilename, CreatePlatformUrl>();
            
        services = i;
        return services;
    }
}