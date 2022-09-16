namespace ChuckSwapiCSharp.Service.Interface;

public interface ISwapiService
{
    Task<string?> GetStarWarsPeople(string? query = "");
    Task<string?> SearchStarWarsPeople(string? query = "");
}

