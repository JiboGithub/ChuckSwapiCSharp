using ChuckSwapiCSharp.Infrastructure.ClientConfig.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace ChuckSwapiCSharp.Infrastructure;

public static class InfrastructureExtension
{
    public static void AddInfrastructureExtension(this IServiceCollection services) => services.AddScoped<IHttpClientRequests, HttpClientRequests>();
}