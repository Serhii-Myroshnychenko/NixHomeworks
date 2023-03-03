using MVC.ViewModels;

namespace MVC.Services.Interfaces
{
    public interface IBasketService
    {
        Task AddToBasket(CatalogCar car);
        Task RemoveFromBasket(CatalogBasketCar car);
        Task UpdateBasket(IEnumerable<CatalogBasketCar> cars);
        Task<IEnumerable<CatalogBasketCar>> GetBasketItems();
    }
}
