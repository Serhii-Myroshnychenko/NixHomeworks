using Newtonsoft.Json;

namespace Module4Homework1.Dtos.Responses;
public class ErrorTextDto
{
    [JsonProperty("error")]
    public string? ErrorBody { get; set; }
}
