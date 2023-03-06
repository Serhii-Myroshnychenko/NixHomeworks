using Infrastructure.Models.Dtos;
using Infrastructure.Models.Items;

namespace Basket.Host.Services.Interfaces;
public interface IBasketService
{
    Task AddItems<T>(string userId, T data);
    Task<BasketDto<CatalogBasketCar>> GetItems(string userId);
}