using Newtonsoft.Json;

namespace Module5Homework1.Dtos.Responses;
public class ErrorTextDto
{
    [JsonProperty("error")]
    public string? ErrorBody { get; set; }
}
