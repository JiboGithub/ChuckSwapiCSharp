namespace ChuckSwapiCSharp.Service.Interface;

public interface ISwapiService
{
    Task<string?> GetStarWarsPeople(string? query = "");
}

