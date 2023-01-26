using Newtonsoft.Json;

namespace Module5Homework1.Dtos.Responses;
public class LoginResponse : ErrorTextDto
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("token")]
    public string? Token { get; set; }
}
