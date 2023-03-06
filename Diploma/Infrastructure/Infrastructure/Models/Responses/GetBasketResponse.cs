using Infrastructure.Models.Items;

namespace Infrastructure.Models.Responses
{
    public class GetBasketResponse
    {
        public IEnumerable<CatalogBasketCar> Data { get; set; } = null!;
    }
}
