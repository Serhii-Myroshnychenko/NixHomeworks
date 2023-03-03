using Basket.Host.Models.Dtos;
using Basket.Host.Models.Items;

namespace Basket.Host.Services.Interfaces;

public interface IBasketService
{
    Task AddItems<T>(string userId, T data);
    Task<BasketDto<CatalogBasketCar>> GetItems(string userId);
}