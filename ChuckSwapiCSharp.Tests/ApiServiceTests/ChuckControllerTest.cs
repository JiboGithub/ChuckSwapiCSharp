using ChuckSwapiCSharp.Tests.BaseTests;
using Newtonsoft.Json;
using Xunit;

namespace ChuckSwapiCSharp.Tests.ApiServiceTests;

public sealed class ChuckControllerTest : BaseServiceTest
{

    public ChuckControllerTest() : base() { }


    [Fact]
    public void JokesExist() 
    {

        var arr = new string[] { "baby jokes", "dad jokes", "test jokes" };

        _chuckServiceRepo.Setup(x => x.GetJokesCategories("").Result)
            .Returns(JsonConvert.SerializeObject(arr));

        //act
        var _chuckCategoriesResult = __chuckService.GetJokesCategories();

        //assert
        Assert.NotNull(_chuckCategoriesResult);
        Assert.True(arr.Length > 1);
    }

}
