using Newtonsoft.Json;
using System.Text;

namespace ChuckSwapiCSharp.Infrastructure.ClientConfig.Helpers;

public class HttpClientRequests : IHttpClientRequests
{
    private readonly IHttpClientFactory _httpClientFactory;
    public static string ApiMetaData { get; set; }

    public HttpClientRequests(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<HttpResponseMessage?> PostRequestAsync<T>(string BaseUrl, string EndPoint, T JsonContent)
    {
        var httpClient = _httpClientFactory.CreateClient(BaseUrl);
        httpClient.BaseAddress = new Uri(BaseUrl);

        try
        {
            var jsonResponse = await httpClient.PostAsync(BaseUrl + EndPoint, await FormatContent(JsonContent));
            return jsonResponse;
        }
        catch (Exception)
        {
            throw;
        }

    }

    public async Task<string?> GetAsync(string BaseUrl, string EndPoint)
    {
        var httpClient = _httpClientFactory.CreateClient(BaseUrl);
        httpClient.BaseAddress = new Uri(BaseUrl);

        try
        {
            var jsonResponse = await httpClient.GetAsync(EndPoint);
            return await GetResponse(jsonResponse);
        }
        catch (Exception)
        {
            throw;
        }
    }

    private async static Task<ByteArrayContent> FormatContent<T>(T content)
    {
        var json = JsonConvert.SerializeObject(content, Formatting.None,
            new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

        var buffer = Encoding.UTF8.GetBytes(json);
        var byteContent = new ByteArrayContent(buffer);

        byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

        return await Task.FromResult(byteContent);
    }


    private static async Task<string?> GetResponse(HttpResponseMessage? response)
    {
        if (response.IsSuccessStatusCode)
        {
            return await response?.Content?.ReadAsStringAsync();
        }
        return null;
    }
}

