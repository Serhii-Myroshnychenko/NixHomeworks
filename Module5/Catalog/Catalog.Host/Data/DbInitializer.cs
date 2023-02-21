using Catalog.Host.Data.Entities;

namespace Catalog.Host.Data;

public static class DbInitializer
{
    public static async Task Initialize(ApplicationDbContext context)
    {
        await context.Database.EnsureCreatedAsync();

        if (!context.CatalogManufacturers.Any())
        {
            await context.CatalogManufacturers.AddRangeAsync(GetPreconfiguredCatalogManufacturers());

            await context.SaveChangesAsync();
        }

        if (!context.CatalogCars.Any())
        {
            await context.CatalogCars.AddRangeAsync(GetPreconfiguredCatalogCars());

            await context.SaveChangesAsync();
        }
    }

    private static IEnumerable<CatalogManufacturer> GetPreconfiguredCatalogManufacturers()
    {
        return new List<CatalogManufacturer>()
        {
            new CatalogManufacturer() { Name = "BMW", FoundationYear = new DateTime(1932, 12, 11), HeadquartersLocation = "Berlin" },
            new CatalogManufacturer() { Name = "Mercedes", FoundationYear = new DateTime(1944, 11, 11), HeadquartersLocation = "Stuttgart" },
            new CatalogManufacturer() { Name = "Audi", FoundationYear = new DateTime(1922, 5, 22), HeadquartersLocation = "Kyiv" },
            new CatalogManufacturer() { Name = "Volkswagen", FoundationYear = new DateTime(1922, 7, 21), HeadquartersLocation = "Berlin" },
            new CatalogManufacturer() { Name = "Porsche", FoundationYear = new DateTime(1912, 3, 17), HeadquartersLocation = "Stuttgart" }
        };
    }

    private static IEnumerable<CatalogCar> GetPreconfiguredCatalogCars()
    {
        return new List<CatalogCar>()
        {
            new CatalogCar() { Model = "X5", Year = new DateTime(2022, 11, 22), Transmission = "Auto", Price = 102000M, Description = "It`s a very fast car", PictureFileName = "1.png", EngineDisplacement = 3.0, CatalogManufacturerId = 1 },
            new CatalogCar() { Model = "X6", Year = new DateTime(2022, 10, 11), Transmission = "Auto", Price = 120000M, Description = "It`s a very fast car", PictureFileName = "2.png", EngineDisplacement = 5.0, CatalogManufacturerId = 1 },
            new CatalogCar() { Model = "A6", Year = new DateTime(2022, 11, 22), Transmission = "Auto", Price = 98000M, Description = "It`s a very fast car", PictureFileName = "3.png", EngineDisplacement = 3.0, CatalogManufacturerId = 3 },
            new CatalogCar() { Model = "A7", Year = new DateTime(2022, 11, 22), Transmission = "Auto", Price = 123000M, Description = "It`s a very fast car", PictureFileName = "4.png", EngineDisplacement = 3.5, CatalogManufacturerId = 3 },
            new CatalogCar() { Model = "C63 AMG", Year = new DateTime(2022, 11, 22), Transmission = "Auto", Price = 200000M, Description = "It`s a very fast car", PictureFileName = "5.png", EngineDisplacement = 5.5, CatalogManufacturerId = 2 },
        };
    }
}