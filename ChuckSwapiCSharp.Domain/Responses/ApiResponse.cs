using System.Dynamic;

namespace ChuckSwapiCSharp.Domain.Responses;

public class ApiResponse
{
    public string MetaData { get; set; }
    public ExpandoObject? Data { get; set; }

    public ApiResponse(string metadata, ExpandoObject? data)
    {
        MetaData = metadata;
        Data = data;
    }
}
