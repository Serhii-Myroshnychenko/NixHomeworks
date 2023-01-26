using Microsoft.Extensions.Options;
using Module5Homework1.Config;
using Module5Homework1.Contracts;
using Module5Homework1.Dtos.Responses;
using Module5Homework1.Models;
using Module5Homework1.Services.Base;

namespace Module5Homework1.Services
{
    public class AuthService : BaseService, IAuthService
    {
        private readonly IInternalHttpClientService _internalHttpClientService;
        private readonly ApiOptions _apiOptions;

        public AuthService(
            IInternalHttpClientService internalHttpClientService,
            IOptions<ApiOptions> options)
        {
            _apiOptions = options.Value;
            _internalHttpClientService = internalHttpClientService;
        }

        public async Task<LoginResult> LoginAsync(string email, string password)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var request = new AuthDto { Email = email, Password = password };

                var response = await _internalHttpClientService.SendAsync<LoginResponse>($"{_apiOptions.Host}/login", HttpMethod.Post, request);
                return new LoginResult
                {
                    Token = response!.Token!
                };
            });
        }

        public async Task<RegisterResult> RegisterAsync(string email, string password)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var request = new AuthDto { Email = email, Password = password };
                var response = await _internalHttpClientService.SendAsync<RegisterResponse>($"{_apiOptions.Host}/register", HttpMethod.Post, request);
                return new RegisterResult
                {
                    Token = response!.Token!
                };
            });
        }
    }
}
