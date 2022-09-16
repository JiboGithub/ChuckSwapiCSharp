using ChuckSwapiCSharp.Domain.Config;
using ChuckSwapiCSharp.Domain.Enums;
using ChuckSwapiCSharp.Domain.Extensions;
using ChuckSwapiCSharp.Domain.Responses;
using ChuckSwapiCSharp.Service.Interface;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Dynamic;

namespace ChuckSwapiCSharp.Service.Implementation;

public sealed class SearchService : ISearchService
{
    private readonly IChuckService __chukService;
    private readonly ISwapiService _swapiService;
    private readonly ReadConfig _readConfig;


    public SearchService(IChuckService chukService, ISwapiService swapiService, IOptions<ReadConfig> readConfig)
    {
        __chukService = chukService;
        _swapiService = swapiService;
        _readConfig = readConfig.Value;
    }

    public async Task<IList<ApiResponse>> Search(string? QueryParam = "")
    {
        IList<ApiResponse> result = new List<ApiResponse>();

        //await all api calls
        var tasks = await Task.WhenAll(
            new[] {
             __chukService.SearchJokesCategories(QueryParam),
             _swapiService.SearchStarWarsPeople(QueryParam)
            });

        int count = 0;

        //Get which endpoint api belongs to
        string firstCalledApi = _readConfig.ChuckBaseUrl + ApiPaths.ChuckCategoriesEndpoint.GetEnumDescription();
        string secondCalledApi = _readConfig.SwapiBaseUrl + ApiPaths.SwapiPeopleEndpoint.GetEnumDescription();

        foreach (var task in tasks)
        {
            count++;
            if (task is not null)
            {
                var metadata = count == 1 ? firstCalledApi : count == 2 ? secondCalledApi : string.Empty;
                result.Add(new ApiResponse(metadata, JsonConvert.DeserializeObject<ExpandoObject>(task)));
            }
        }

        return result;
    }




}
