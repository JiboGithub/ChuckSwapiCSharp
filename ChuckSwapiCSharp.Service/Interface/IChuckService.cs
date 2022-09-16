namespace ChuckSwapiCSharp.Service.Interface;

public interface IChuckService
{
    Task<string?> GetJokesCategories(string? query = "");
}
