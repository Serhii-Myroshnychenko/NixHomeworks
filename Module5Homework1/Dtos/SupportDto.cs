using Newtonsoft.Json;

namespace Module5Homework1.Dtos.Responses;

public class SupportDto
{
    [JsonProperty("url")]
    public string Url { get; set; } = null!;

    [JsonProperty("text")]
    public string Text { get; set; } = null!;
}