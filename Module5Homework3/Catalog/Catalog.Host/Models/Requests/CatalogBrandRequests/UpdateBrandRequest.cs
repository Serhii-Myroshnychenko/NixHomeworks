namespace Catalog.Host.Models.Requests.CatalogRequests
{
    public class UpdateBrandRequest
    {
        public int Id { get; init; }
        public string Brand { get; init; } = null!;
    }
}
