
using ChuckSwapiCSharp.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

[ApiController]
public class SearchController : ControllerBase
{
    private readonly ISearchService _searchService;

    public SearchController(ISearchService searchService)
    {
        _searchService = searchService;
    }

    [HttpGet, Route("search")]
    [SwaggerOperation(Summary = "Search and Filter Chuck Norris Joke Categories and StarWars People",
        Description = "Search and Filter Chuck Norris Joke Categories and StarWars People")]
    [SwaggerResponse(200, "Data returned", typeof(OkResult))]
    [SwaggerResponse(404, "No records", typeof(NotFoundResult))]
    public async Task<IActionResult> SearchAPIs([FromQuery] string? query)
    {
        var getApiResponse = await _searchService.Search(query);
        return getApiResponse is null ? NotFound() : Ok(getApiResponse);
    }
}
