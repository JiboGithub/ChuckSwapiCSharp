using ChuckSwapiCSharp.Service.Interface;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace ChuckSwapiCSharp.Tests.ApiServiceTests;

public sealed class ChuckControllerTest
{
    private Mock<IChuckService> _chuckServiceRepo;
    private ChuckController __chuckController;

    public ChuckControllerTest()
    {
        _chuckServiceRepo = new Mock<IChuckService>();

        __chuckController = new ChuckController(
            _chuckServiceRepo.Object);
    }


    [Fact]
    public void JokesExist() 
    {

        var arr = new string[] { "baby jokes", "dad jokes", "test jokes" };

        _chuckServiceRepo.Setup(x => x.GetJokesCategories("").Result)
            .Returns(JsonConvert.SerializeObject(arr));

        //act
        var _chuckCategoriesResult = __chuckController.GetJokesCategories();

        //assert
        Assert.NotNull(_chuckCategoriesResult);
        Assert.True(arr.Length > 1);
    }

}
