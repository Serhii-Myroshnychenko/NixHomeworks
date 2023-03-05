namespace Order.Host.Models
{
    public class CatalogBasketCar
    {
        public int Id { get; set; }
        public string Model { get; set; } = null!;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
