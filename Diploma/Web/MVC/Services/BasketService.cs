using AutoMapper;
using MVC.Services.Interfaces;
using MVC.ViewModels;

namespace MVC.Services
{
    public class BasketService : IBasketService
    {
        private readonly IMapper _mapper;
        private readonly IOptions<AppSettings> _settings;
        private readonly IHttpClientService _httpClient;
        private readonly ILogger<BasketService> _logger;
        public BasketService(
            IMapper mapper,
            IOptions<AppSettings> settings,
            IHttpClientService httpClient,
            ILogger<BasketService> logger)
        {
            _mapper = mapper;
            _settings = settings;
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task AddToBasket(CatalogCar car)
        {
            var items = await GetBasketItems();
            var list = items.ToList();
            list.Add(_mapper.Map<CatalogBasketCar>(car));

            await _httpClient.SendAsync<GroupedEntities<CatalogBasketCar>, GroupedEntities<CatalogBasketCar>>
                ($"{_settings.Value.BasketUrl}/AddCarsToBasket",
                HttpMethod.Post, new GroupedEntities<CatalogBasketCar>() { Data = list });
        }

        public async Task<IEnumerable<CatalogBasketCar>> GetBasketItems()
        {
            var result = await _httpClient.SendAsync<GroupedEntities<CatalogBasketCar>,object>
                ($"{_settings.Value.BasketUrl}/GetBasket",
                HttpMethod.Post, null);
            return result.Data;
        }
    }
}
