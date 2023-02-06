namespace Catalog.Host.Models.Requests.CatalogTypeRequests
{
    public class UpdateCatalogTypeRequest
    {
        public int Id { get; init; }
        public string Type { get; init; } = null!;
    }
}
