using Module5Homework1.Models;

namespace Module5Homework1.Contracts
{
    public interface IAuthService
    {
        Task<RegisterResult> RegisterAsync(string email, string password);
        Task<LoginResult> LoginAsync(string email, string password);
    }
}
