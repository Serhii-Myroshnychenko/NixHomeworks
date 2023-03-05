namespace MVC.ViewModels.OrderViewModels
{
    public class OrderViewModel
    {
        public IEnumerable<CatalogBasketCar> CatalogBasketCars { get; set; }
        public decimal Total { get; set; }
    }
}
