using System.ComponentModel;

namespace ChuckSwapiCSharp.Domain.Enums;

public enum ApiPaths
{
    [Description("jokes/categories")]
    ChuckCategoriesEndpoint = 0,

    [Description("api/people")]
    SwapiPeopleEndpoint = 1,
    
    [Description("/jokes/search?query=")]
    SearchJokes = 2, 

    [Description("/api/people/?search=")]
    SearchPeople = 3, 
    
    [Description("/jokes/random/?category=")] 
    RandomJokes = 4, 
}
