using ChuckSwapiCSharp.Domain.Config;

namespace ChuckSwapiCSharp.API.Extensions;

public static class MiddlewareExtension
{
    public static void RegisterDependencies(this IServiceCollection services, IConfiguration config)
    {
        services.AddHttpClient();
        services.Configure<ReadConfig>(config.GetSection("ReadConfig"));
    }
}
