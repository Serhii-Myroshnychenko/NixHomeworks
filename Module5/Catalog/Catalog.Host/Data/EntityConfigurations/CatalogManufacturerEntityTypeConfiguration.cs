﻿using Catalog.Host.Data.Entities;

namespace Catalog.Host.Data.EntityConfigurations;
public class CatalogManufacturerEntityTypeConfiguration
    : IEntityTypeConfiguration<CatalogManufacturer>
{
    public void Configure(EntityTypeBuilder<CatalogManufacturer> builder)
    {
        builder.ToTable("CatalogManufacturer");

        builder.HasKey(cm => cm.Id);

        builder.Property(cm => cm.Id)
            .UseHiLo("catalog_manufacturer_hilo")
            .IsRequired();

        builder.Property(cm => cm.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(cm => cm.FoundationYear)
            .IsRequired();

        builder.Property(cm => cm.HeadquartersLocation)
            .IsRequired()
            .HasMaxLength(150);
    }
}
