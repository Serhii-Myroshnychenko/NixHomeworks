﻿namespace Catalog.Host.Models.Dtos
{
    public class CatalogCarDto
    {
        public int Id { get; set; }
        public string Model { get; set; } = null!;
        public DateTime Year { get; set; }
        public string Transmission { get; set; } = null!;
        public decimal Price { get; set; }
        public string Description { get; set; } = null!;
        public string PictureUrl { get; set; } = null!;
        public double EngineDisplacement { get; set; }
        public int Quantity { get; set; }
        public CatalogManufacturerDto CatalogManufacturer { get; set; } = null!;
    }
}
