using ChuckSwapiCSharp.Service.Implementation;
using ChuckSwapiCSharp.Service.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace ChuckSwapiCSharp.Service;

public static class ServiceExtension
{
    public static void AddServiceExtension(this IServiceCollection services)
    {
        services.AddScoped<IChuckService, ChuckService>();
        services.AddScoped<ISwapiService, SwapiService>();
        services.AddScoped<ISearchService, SearchService>();
    }
}
