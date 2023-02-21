using Catalog.Host.Data.Entities;
using Catalog.Host.Data.EntityConfigurations;

namespace Catalog.Host.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<CatalogCar> CatalogCars { get; set; } = null!;
    public DbSet<CatalogManufacturer> CatalogManufacturers { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new CatalogManufacturerEntityTypeConfiguration());
        builder.ApplyConfiguration(new CatalogCarEntityTypeConfiguration());
    }
}
