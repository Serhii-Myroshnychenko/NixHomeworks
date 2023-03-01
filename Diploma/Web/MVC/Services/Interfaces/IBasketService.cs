using MVC.ViewModels;

namespace MVC.Services.Interfaces
{
    public interface IBasketService
    {
        Task AddToBasket(CatalogCar car);
        Task<IEnumerable<CatalogBasketCar>> GetBasketItems();
    }
}
