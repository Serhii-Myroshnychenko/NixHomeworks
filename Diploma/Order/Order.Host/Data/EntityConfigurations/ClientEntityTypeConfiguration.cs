using Order.Host.Data.Entities;

namespace Order.Host.Data.EntityConfigurations
{
    public class ClientEntityTypeConfiguration
    : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Clients");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .IsRequired();

            builder.Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(150);
        }
    }
}
