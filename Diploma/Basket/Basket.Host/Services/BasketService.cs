using Basket.Host.Models.Dtos;
using Basket.Host.Models.Items;
using Basket.Host.Services.Interfaces;

namespace Basket.Host.Services;

public class BasketService : IBasketService
{
    private readonly ICacheService _cacheService;

    public BasketService(ICacheService cacheService)
    {
        _cacheService = cacheService;
    }

    public async Task AddItems<T>(string userId, T data)
    {
        await _cacheService.AddOrUpdateAsync(userId, data);
    }

    public async Task<BasketDto<CatalogBasketCar>> GetItems(string userId)
    {
        var result = await _cacheService.GetAsync<List<CatalogBasketCar>>(userId);
        if(result == null)
        {
            result = new List<CatalogBasketCar>();
        }
        return new BasketDto<CatalogBasketCar>() { Data = result };
    }
}