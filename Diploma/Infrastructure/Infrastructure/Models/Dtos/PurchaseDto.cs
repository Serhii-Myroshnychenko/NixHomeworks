namespace Infrastructure.Models.Dtos
{
    public class PurchaseDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public ProductDto Product { get; set; } = null!;
        public int ClientId { get; set; }
        public ClientDto Client { get; set; } = null!;
        public int Quantity { get; set; }
    }
}
