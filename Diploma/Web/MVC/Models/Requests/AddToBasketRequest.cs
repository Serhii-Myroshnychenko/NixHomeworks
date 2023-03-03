using MVC.ViewModels;

namespace MVC.Models.Requests
{
    public class AddToBasketRequest
    {
        [Required]
        public List<CatalogBasketCar> Data { get; set; } = null!;
    }
}
