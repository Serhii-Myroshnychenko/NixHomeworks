using System.ComponentModel.DataAnnotations;
using Infrastructure.Models.Items;

namespace Infrastructure.Models.Requests
{
    public class AddToBasketRequest
    {
        [Required]
        public List<CatalogBasketCar> Data { get; set; } = null!;
    }
}
