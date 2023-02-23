using Basket.Host.Models;
using Basket.Host.Services.Interfaces;
using MVC;

namespace Basket.Host.Services
{
    public class CatalogItemService : ICatalogItemService
    {
        private readonly IOptions<AppSettings> _settings;
        private readonly IHttpClientService _httpClient;
        private readonly ILogger<CatalogItemService> _logger;
        public CatalogItemService(IHttpClientService httpClient, ILogger<CatalogItemService> logger, IOptions<AppSettings> settings)
        {
            _httpClient = httpClient;
            _logger = logger;
            _settings = settings;
        }
        public async Task<CatalogItemDto> AddCatalogItemAsync(string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName)
        {
            return await _httpClient.SendAsync<CatalogItemDto,CreateCatalogItemRequest>
            ($"{_settings.Value.CatalogUrl}/Add", HttpMethod.Post, new CreateCatalogItemRequest() { Name = name, Description = description, Price = price, AvailableStock = availableStock, CatalogBrandId = catalogBrandId, CatalogTypeId = catalogTypeId, PictureFileName = pictureFileName});
        }
    }
}
