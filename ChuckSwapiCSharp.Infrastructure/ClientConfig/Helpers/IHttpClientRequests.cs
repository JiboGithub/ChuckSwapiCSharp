namespace ChuckSwapiCSharp.Infrastructure.ClientConfig.Helpers;

public interface IHttpClientRequests
{
    Task<HttpResponseMessage?> PostRequestAsync<T>(string BaseUrl, string EndPoint, T JsonContent);
    Task<string?> GetAsync(string BaseUrl, string EndPoint);
}
