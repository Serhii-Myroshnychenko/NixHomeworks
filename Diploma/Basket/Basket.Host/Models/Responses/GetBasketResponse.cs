using Basket.Host.Models.Items;

namespace Basket.Host.Models.Responses
{
    public class GetBasketResponse
    {
        public IEnumerable<CatalogCar> Data { get; set; } = null!;
    }
}
