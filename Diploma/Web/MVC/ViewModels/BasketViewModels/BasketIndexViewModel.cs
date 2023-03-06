using Infrastructure.Models.Items;

namespace MVC.ViewModels.BasketViewModels
{
    public class BasketIndexViewModel
    {
        public IEnumerable<CatalogBasketCar> CatalogBasketCars { get; set; }
        public decimal Total { get; set; }
    }
}
