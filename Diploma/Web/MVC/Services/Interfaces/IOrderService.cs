using MVC.ViewModels;

namespace MVC.Services.Interfaces
{
    public interface IOrderService
    {
        Task PlaceOrder(string firstName, string lastName);
        Task<IEnumerable<CatalogBasketCar>> GetOrderById();
    }
}
