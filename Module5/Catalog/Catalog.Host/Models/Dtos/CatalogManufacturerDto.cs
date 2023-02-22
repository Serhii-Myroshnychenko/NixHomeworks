namespace Catalog.Host.Models.Dtos
{
    public class CatalogManufacturerDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime FoundationYear { get; set; }
        public string HeadquartersLocation { get; set; } = null!;
    }
}
