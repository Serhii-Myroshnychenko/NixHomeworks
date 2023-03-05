using Order.Host.Data.Entities;

namespace Order.Host.Data.EntityConfigurations;

public class PurchaseEntityTypeConfiguration
    : IEntityTypeConfiguration<Purchase>
{
    public void Configure(EntityTypeBuilder<Purchase> builder)
    {
        builder.ToTable("Purchases");

        builder.HasKey(o => o.Id);

        builder.Property(o => o.Id)
            .IsRequired();

        builder.Property(o => o.ClientId)
            .IsRequired();

        builder.Property(o => o.ProductId)
            .IsRequired();

        builder.Property(o => o.Quantity)
            .IsRequired();

        builder.HasOne(o => o.Client)
            .WithMany(c => c.Purchases)
            .HasForeignKey(o => o.ClientId);

        builder.HasOne(o => o.Product)
            .WithMany(p => p.Purchases)
            .HasForeignKey(o => o.ProductId);
    }
}