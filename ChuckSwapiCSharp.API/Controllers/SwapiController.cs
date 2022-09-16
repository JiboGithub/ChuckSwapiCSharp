
using ChuckSwapiCSharp.Domain.ViewModels;
using ChuckSwapiCSharp.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;

[ApiController]
public class SwapiController : ControllerBase
{
    private readonly ISwapiService _swapiService;

    public SwapiController(ISwapiService swapiService)
    {
        _swapiService = swapiService;
    }

    [HttpGet, Route("swapi/people")]
    [SwaggerOperation(Summary = "Get Star Wars People", Description = "API to Get Star Wars People")]
    [SwaggerResponse(200, "Data returned", typeof(OkResult))]
    [SwaggerResponse(404, "No records", typeof(NotFoundResult))]
    public async Task<IActionResult> GetStarWarsPeople()
    {
        var getPeople = await _swapiService.GetStarWarsPeople();
        return getPeople is null ? NotFound() : Ok(JsonConvert.DeserializeObject<StarWarsPeople>(getPeople));
    }

}
