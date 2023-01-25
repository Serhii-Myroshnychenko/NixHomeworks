using Microsoft.Extensions.Options;
using Module4Homework1.Config;
using Module4Homework1.Contracts;
using Module4Homework1.Dtos.Responses;
using Module4Homework1.Models;
using Module4Homework1.Services.Base;

namespace Module4Homework1.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IInternalHttpClientService _internalHttpClientService;
        private readonly ApiOptions _apiOptions;

        public UserService(
            IInternalHttpClientService internalHttpClientService,
            IOptions<ApiOptions> options)
        {
            _apiOptions = options.Value;
            _internalHttpClientService = internalHttpClientService;
        }
        public async Task<Employee> CreateUserAsync(string name, string job)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var request = new EmployeeDto { Name = name, Job = job };
                var response =
                    await _internalHttpClientService.SendAsync<EmployeeDto>($"{_apiOptions.Host}/users", HttpMethod.Post, request);

                if (response != null)
                {
                    return new Employee
                    {
                        CreatedAt = response.CreatedAt,
                        Job = response.Job,
                        Id = response.Id,
                        Name = response.Name,
                        UpdatedAt = response.UpdatedAt
                    };
                }

                return null!;
            });
        }

        public async Task<VoidResult> DeleteUserAsync(int id)
        {
            return await ExecuteSafeAsync<VoidResult>(async () =>
            {
                await _internalHttpClientService.SendAsync($"{_apiOptions.Host}/users/{id}", HttpMethod.Delete);
                return null!;
            });
        }

        public async Task<CollectionData<User>> GetListOfUsersByDelayAsync(int delay)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var response =
                    await _internalHttpClientService.SendAsync<PagingResponse<UserDto[]>>($"{_apiOptions.Host}/users?delay={delay}", HttpMethod.Get);

                if (response!.Data != null)
                {
                    return new CollectionData<User>()
                    {
                        Data = response.Data.Select(s => new User
                        {
                            Email = s.Email,
                            FirstName = s.FirstName,
                            Id = s.Id,
                            LastName = s.LastName,
                            UrlAvatar = s.UrlAvatar
                        }).ToList()
                    };
                }

                return null!;
            });
        }

        public async Task<CollectionData<User>> GetListOfUsersByPageAsync(int page)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var response =
                    await _internalHttpClientService.SendAsync<PagingResponse<UserDto[]>>($"{_apiOptions.Host}/users?page={page}", HttpMethod.Get);

                if (response!.Data != null)
                {
                    return new CollectionData<User>()
                    {
                        Data = response.Data.Select(s => new User
                        {
                            Email = s.Email,
                            FirstName = s.FirstName,
                            Id = s.Id,
                            LastName = s.LastName,
                            UrlAvatar = s.UrlAvatar
                        }).ToList()
                    };
                }

                return null!;
            });
        }

        public async Task<User> GetSingleUserAsync(int id)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var response =
                    await _internalHttpClientService.SendAsync<PagingResponse<UserDto>>($"{_apiOptions.Host}/users/{id}", HttpMethod.Get);

                if (response!.Data != null)
                {
                    return new User
                    {
                        Email = response.Data.Email,
                        FirstName = response.Data.FirstName,
                        Id = response.Data.Id,
                        LastName = response.Data.LastName,
                        UrlAvatar = response.Data.UrlAvatar
                    };
                }

                return null!;
            });
        }

        public async Task<Employee> UpdateUserAsync(int id ,string name, string job)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var request = new EmployeeDto { Name = name, Job = job };
                var response =
                    await _internalHttpClientService.SendAsync<EmployeeDto>($"{_apiOptions.Host}/users/{id}", HttpMethod.Put, request);

                if (response != null)
                {
                    return new Employee
                    {
                        CreatedAt = response.CreatedAt,
                        Job = response.Job,
                        Id = response.Id,
                        Name = response.Name,
                        UpdatedAt = response.UpdatedAt
                    };
                }

                return null!;
            });
        }
    }
}
