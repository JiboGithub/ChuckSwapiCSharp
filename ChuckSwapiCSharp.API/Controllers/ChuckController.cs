using ChuckSwapiCSharp.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;

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
        var getJokesResponse = await _chuckService.GetJokesCategories();
        return getJokesResponse is null ? NotFound() : Ok(JsonConvert.DeserializeObject<string[]>(getJokesResponse));
    }

}
