using ChuckSwapiCSharp.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System.Dynamic;

[ApiController]
public class ChuckController : ControllerBase
{
    private readonly IChuckService _chuckService;

    public ChuckController(IChuckService chuckService)
    {
        _chuckService = chuckService;
    }

    [HttpGet, Route("chuck/categories")]
    [SwaggerOperation(Summary = "Get Chuck Norris Joke Categories", Description = "API to Get Chuck Norris Joke Categories")]
    [SwaggerResponse(200, "Data returned", typeof(OkResult))]
    [SwaggerResponse(404, "No records", typeof(NotFoundResult))]
    public async Task<IActionResult> GetJokesCategories()
    {
        var getJokesResponse = await _chuckService.SearchJokesCategories();
        return getJokesResponse is null ? NotFound() : Ok(JsonConvert.DeserializeObject<string[]>(getJokesResponse));
    }


    [HttpGet, Route("jokes/random")]
    [SwaggerOperation(Summary = "Get Random Jokes", Description = "API to Get Random Jokes")]
    [SwaggerResponse(200, "Data returned", typeof(OkResult))]
    [SwaggerResponse(404, "No records", typeof(NotFoundResult))]
    public async Task<IActionResult> GetRandomJokes(string category = "")
    {
        var getJokesResponse = await _chuckService.GetRandomJokes(category);
        return getJokesResponse is null ? NotFound() : Ok(JsonConvert.DeserializeObject<ExpandoObject>(getJokesResponse));
    }

}
