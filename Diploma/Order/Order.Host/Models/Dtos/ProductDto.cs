namespace Order.Host.Models.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Model { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
