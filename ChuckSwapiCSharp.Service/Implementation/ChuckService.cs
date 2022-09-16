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

    public async Task<string?> SearchJokesCategories(string? query = "")
    { 
        string fullPath = string.Empty;

        if (!string.IsNullOrWhiteSpace(query))
        {
            fullPath += _readConfig?.ChuckBaseUrl + ApiPaths.SearchJokes + query;
        }
        else
        {
            fullPath = _readConfig?.ChuckBaseUrl + ApiPaths.ChuckCategoriesEndpoint.GetEnumDescription();
        }

        var response = await _httpClientRequests.GetAsync(_readConfig?.ChuckBaseUrl, fullPath);
        return response;
    } 
    
    
    public async Task<string?> GetRandomJokes(string? query = "")
    {
        string fullPath = _readConfig?.ChuckBaseUrl + ApiPaths.RandomJokes.GetEnumDescription() + query;

        var response = await _httpClientRequests.GetAsync(_readConfig?.ChuckBaseUrl, fullPath);
        return response;
    }
}
