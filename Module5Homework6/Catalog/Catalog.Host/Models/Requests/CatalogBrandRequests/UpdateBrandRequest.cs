namespace Catalog.Host.Models.Requests.CatalogBrandRequests
{
    public class UpdateBrandRequest
    {
        public int Id { get; init; }
        public string Brand { get; init; } = null!;
    }
}
