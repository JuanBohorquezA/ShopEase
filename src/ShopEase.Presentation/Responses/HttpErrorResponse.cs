using Newtonsoft.Json;

namespace ShopEase.Presentation.Responses;

public class HttpErrorResponse
{
    public int statusCode { get; set; }
    public string? description { get; set; }
    public IEnumerable<string>? message { get; set; }
    public string? stackTrace { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}
    