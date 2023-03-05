using AutoMapper;
using MVC.Models.Responses;
using MVC.Services.Interfaces;
using MVC.ViewModels;

namespace MVC.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IOptions<AppSettings> _settings;
        private readonly IHttpClientService _httpClient;
        private readonly ILogger<OrderService> _logger;
        public OrderService(
            IMapper mapper,
            IOptions<AppSettings> settings,
            IHttpClientService httpClient,
            ILogger<OrderService> logger)
        {
            _mapper = mapper;
            _settings = settings;
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<IEnumerable<CatalogBasketCar>> GetOrderById()
        {
            var result =  await _httpClient.SendAsync<GroupedEntitiesResponse<CatalogBasketCar>, object>
                ($"{_settings.Value.OrderUrl}/GetOrderBasketByClientId",
                HttpMethod.Post, null);
            return result.Data;
        }

        public async Task PlaceOrder(string firstName, string lastName)
        {
            await _httpClient.SendAsync<object, PlaceOrderRequest>
                ($"{_settings.Value.OrderUrl}/PlaceOrder",
                HttpMethod.Post, new PlaceOrderRequest() { FirstName = firstName, LastName = lastName});
        }
    }
}
