using ChuckSwapiCSharp.Domain.Config;
using ChuckSwapiCSharp.Infrastructure.ClientConfig.Helpers;
using ChuckSwapiCSharp.Service.Interface;
using Microsoft.Extensions.Options;
using Moq;

namespace ChuckSwapiCSharp.Tests.BaseTests;

public abstract class BaseServiceTest
{
    protected internal Mock<IChuckService> _chuckServiceRepo;
    protected internal ChuckController __chuckService;
    protected readonly Mock<IOptions<ReadConfig>> _readConfig;

    protected internal readonly Mock<IHttpClientRequests> _clientRequests;

    protected internal readonly Mock<IHttpClientFactory> _httpClientFactory;


    public BaseServiceTest() 
    { 

        _clientRequests = new Mock<IHttpClientRequests>();
        _httpClientFactory = new Mock<IHttpClientFactory>();

        _chuckServiceRepo = new Mock<IChuckService>();

        __chuckService = new ChuckController(
            _chuckServiceRepo.Object);

    }
}
