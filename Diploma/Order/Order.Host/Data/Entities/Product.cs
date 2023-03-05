namespace Order.Host.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Model { get; set; } = null!;
        public decimal Price { get; set; }
        public ICollection<Purchase> Purchases { get; set; } = null!;
    }
}
