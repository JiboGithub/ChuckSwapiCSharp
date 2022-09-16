using ChuckSwapiCSharp.Domain.Config;
using ChuckSwapiCSharp.Domain.Enums;
using ChuckSwapiCSharp.Domain.Extensions;
using ChuckSwapiCSharp.Infrastructure.ClientConfig.Helpers;
using ChuckSwapiCSharp.Service.Interface;
using Microsoft.Extensions.Options;

namespace ChuckSwapiCSharp.Service.Implementation;

public sealed class ChuckService : BaseService, IChuckService
{
    public ChuckService(IHttpClientRequests httpClientRequests, IOptions<ReadConfig?> readConfig) : base(httpClientRequests, readConfig) { }

    public async Task<string?> GetJokesCategories(string? query = "")
    {
        string extraPath = string.Empty, fullPath = string.Empty;

        if (!string.IsNullOrWhiteSpace(query))
        {
            extraPath += $"/jokes/search?query={query}";
            fullPath = _readConfig?.ChuckBaseUrl + extraPath;
        }

        else
        {
            fullPath = _readConfig?.ChuckBaseUrl + ApiPaths.ChuckCategoriesEndpoint.GetEnumDescription();
        }

        var response = await _httpClientRequests.GetAsync(_readConfig?.ChuckBaseUrl, fullPath);
        return response;
    }
}
