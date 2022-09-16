using ChuckSwapiCSharp.Service.Interface;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace ChuckSwapiCSharp.Tests.ApiServiceTests;

public sealed class SwapiControllerTest 
{
    private readonly Mock<ISwapiService> _swapiServiceRepo;
    private readonly SwapiController __swapiController;

    public SwapiControllerTest()
    {
        _swapiServiceRepo = new Mock<ISwapiService>();

        __swapiController = new SwapiController(
            _swapiServiceRepo.Object);
    }

    [Fact]
    public void PeopleExist()  
    {

        var arr = new string[] { "baby jokes", "dad jokes", "test jokes" };

        _swapiServiceRepo.Setup(x => x.GetStarWarsPeople("").Result)
            .Returns(JsonConvert.SerializeObject(arr));

        // 
        var peopleResult = __swapiController.GetStarWarsPeople();

        //assert
        Assert.NotNull(peopleResult); 
        Assert.True(arr.Length > 1);
    }

}
