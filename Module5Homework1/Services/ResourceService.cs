using Microsoft.Extensions.Options;
using Module5Homework1.Config;
using Module5Homework1.Contracts;
using Module5Homework1.Dtos.Responses;
using Module5Homework1.Models;
using Module5Homework1.Services.Base;

namespace Module5Homework1.Services
{
    public class ResourceService : BaseService, IResourceService
    {
        private readonly IInternalHttpClientService _internalHttpClientService;
        private readonly ApiOptions _apiOptions;

        public ResourceService(
            IInternalHttpClientService internalHttpClientService,
            IOptions<ApiOptions> options)
        {
            _apiOptions = options.Value;
            _internalHttpClientService = internalHttpClientService;
        }

        public async Task<CollectionData<Resource>> GetListOfResourcesAsync()
        {
            return await ExecuteSafeAsync(async () =>
            {
                var response =
                    await _internalHttpClientService.SendAsync<PagingResponse<ResourceDto[]>>($"{_apiOptions.Host}/unknown", HttpMethod.Get);

                if (response!.Data != null)
                {
                    return new CollectionData<Resource>()
                    {
                        Data = response.Data.Select(s => new Resource
                        {
                            Color = s.Color,
                            Name = s.Name,
                            Id = s.Id,
                            PantoneValue = s.PantoneValue,
                            Year = s.Year
                        }).ToList()
                    };
                }

                return null!;
            });
        }

        public async Task<Resource> GetSingleResourceAsync(int id)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var response =
                    await _internalHttpClientService.SendAsync<PagingResponse<ResourceDto>>($"{_apiOptions.Host}/unknown/{id}", HttpMethod.Get);

                if (response!.Data != null)
                {
                    return new Resource
                    {
                        Color = response.Data.Color,
                        Name = response.Data.Name,
                        Id = response.Data.Id,
                        PantoneValue = response.Data.PantoneValue,
                        Year = response.Data.Year
                    };
                }

                return null!;
            });
        }
    }
}
