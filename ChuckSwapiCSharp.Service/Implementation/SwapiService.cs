using ChuckSwapiCSharp.Domain.Config;
using ChuckSwapiCSharp.Domain.Enums;
using ChuckSwapiCSharp.Domain.Extensions;
using ChuckSwapiCSharp.Infrastructure.ClientConfig.Helpers;
using ChuckSwapiCSharp.Service.Interface;
using Microsoft.Extensions.Options;

namespace ChuckSwapiCSharp.Service.Implementation;

public sealed class SwapiService : BaseService, ISwapiService
{
    public SwapiService(IHttpClientRequests httpClientRequests, IOptions<ReadConfig?> readConfig) : base(httpClientRequests, readConfig) { }

    public async Task<string?> GetStarWarsPeople(string? query = "")
    {
        string extraPath = string.Empty;

        if (!string.IsNullOrWhiteSpace(query))
        {
            extraPath += $"/?search={query}";
        }

        var response = await _httpClientRequests.GetAsync(_readConfig.SwapiBaseUrl, ApiPaths.SwapiPeopleEndpoint.GetEnumDescription() + extraPath);
        return response;
    }

}
