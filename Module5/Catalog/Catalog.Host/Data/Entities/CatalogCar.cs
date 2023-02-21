namespace Catalog.Host.Data.Entities
{
    public class CatalogCar
    {
        public int Id { get; set; }
        public string Model { get; set; } = null!;
        public DateTime Year { get; set; }
        public string Transmission { get; set; } = null!;
        public decimal Price { get; set; }
        public string Description { get; set; } = null!;
        public string PictureFileName { get; set; } = null!;
        public double EngineDisplacement { get; set; }
        public int CatalogManufacturerId { get; set; }
        public CatalogManufacturer CatalogManufacturer { get; set; } = null!;
    }
}
