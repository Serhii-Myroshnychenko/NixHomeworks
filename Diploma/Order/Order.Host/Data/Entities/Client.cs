namespace Order.Host.Data.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public ICollection<Purchase> Purchases { get; set; } = null!;
    }
}
