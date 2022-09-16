using System.ComponentModel;

namespace ChuckSwapiCSharp.Domain.Enums;

public enum ApiPaths
{
    [Description("jokes/categories")]
    ChuckCategoriesEndpoint = 0,

    [Description("api/people")]
    SwapiPeopleEndpoint = 1,
}
