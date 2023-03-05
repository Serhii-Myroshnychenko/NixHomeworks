using Order.Host.Data.Entities;

namespace Order.Host.Data.EntityConfigurations;
public class ProductEntityTypeConfiguration
    : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .UseHiLo("order_products_hilo")
            .IsRequired();

        builder.Property(p => p.Model)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(p => p.Price)
            .IsRequired();
    }
}
