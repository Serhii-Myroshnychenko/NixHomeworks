using Basket.Host.Models.Items;

namespace Basket.Host.Models.Responses
{
    public class GetBasketResponse
    {
        public IEnumerable<CatalogBasketCar> Data { get; set; } = null!;
    }
}
