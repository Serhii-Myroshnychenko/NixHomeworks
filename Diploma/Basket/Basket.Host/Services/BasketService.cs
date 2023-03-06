using Basket.Host.Services.Interfaces;
using Infrastructure.Models.Dtos;
using Infrastructure.Models.Items;

namespace Basket.Host.Services;

public class BasketService : IBasketService
{
    private readonly ICacheService _cacheService;
    private readonly ILogger<BasketService> _logger;

    public BasketService(
        ICacheService cacheService,
        ILogger<BasketService> logger)
    {
        _cacheService = cacheService;
        _logger = logger;
    }

    public async Task AddItems<T>(string userId, T data)
    {
        _logger.LogInformation($"AddItems method with the following paramenters: userId = {userId}");
        await _cacheService.AddOrUpdateAsync(userId, data);
    }

    public async Task<BasketDto<CatalogBasketCar>> GetItems(string userId)
    {
        _logger.LogInformation($"GetItems method with the following paramenters: userId = {userId}");
        var result = await _cacheService.GetAsync<List<CatalogBasketCar>>(userId);
        if(result == null)
        {
            result = new List<CatalogBasketCar>();
        }
        return new BasketDto<CatalogBasketCar>() { Data = result };
    }
}