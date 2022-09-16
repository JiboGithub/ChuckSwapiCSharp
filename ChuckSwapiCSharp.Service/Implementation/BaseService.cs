using ChuckSwapiCSharp.Domain.Config;
using ChuckSwapiCSharp.Infrastructure.ClientConfig.Helpers;
using Microsoft.Extensions.Options;

namespace ChuckSwapiCSharp.Service.Implementation;

public class BaseService
{
    protected readonly IHttpClientRequests _httpClientRequests;
    protected readonly ReadConfig? _readConfig;

    public BaseService(IHttpClientRequests httpClientRequests, IOptions<ReadConfig?> readConfig)
    {
        _httpClientRequests = httpClientRequests;
        _readConfig = readConfig?.Value;
    }
}
