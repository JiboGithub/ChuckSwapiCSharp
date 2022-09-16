using ChuckSwapiCSharp.Domain.Responses;

namespace ChuckSwapiCSharp.Service.Interface;

public interface ISearchService
{
    Task<IList<ApiResponse>> Search(string? QueryParam);
}

