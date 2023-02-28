namespace MVC.ViewModels.BasketViewModels
{
    public class BasketIndexViewModel
    {
        public IEnumerable<CatalogCar> CatalogCars { get; set; }
        public decimal Total { get; set; }
    }
}
