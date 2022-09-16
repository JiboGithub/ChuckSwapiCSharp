namespace ChuckSwapiCSharp.Service.Interface;

public interface IChuckService
{
    Task<string?> SearchJokesCategories(string? query = "");
    Task<string?> GetRandomJokes(string? query = "");
}
