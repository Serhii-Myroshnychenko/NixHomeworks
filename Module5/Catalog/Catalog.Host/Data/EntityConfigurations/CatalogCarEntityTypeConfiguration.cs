using Catalog.Host.Data.Entities;

namespace Catalog.Host.Data.EntityConfigurations;

public class CatalogCarEntityTypeConfiguration
    : IEntityTypeConfiguration<CatalogCar>
{
    public void Configure(EntityTypeBuilder<CatalogCar> builder)
    {
        builder.ToTable("Catalog");

        builder.Property(cc => cc.Id)
            .UseHiLo("catalog_hilo")
            .IsRequired();

        builder.Property(cc => cc.Model)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(cc => cc.Year)
            .IsRequired();

        builder.Property(cc => cc.Transmission)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(cc => cc.Price)
            .IsRequired();

        builder.Property(cc => cc.Description)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(cc => cc.PictureFileName)
            .IsRequired();

        builder.Property(cc => cc.EngineDisplacement)
            .IsRequired();

        builder.HasOne(cc => cc.CatalogManufacturer)
            .WithMany(cm => cm.CatalogCars)
            .HasForeignKey(cc => cc.CatalogManufacturerId);
    }
}