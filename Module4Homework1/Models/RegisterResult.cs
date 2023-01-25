namespace Module4Homework1.Models;
public class RegisterResult : Validation
{
    public int Id { get; set; }
    public string Token { get; set; } = null!;
}
