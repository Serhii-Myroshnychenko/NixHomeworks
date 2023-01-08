using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4Homework4.Models;

namespace Module4Homework4.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client").HasKey(c => c.ClientId);
            builder.Property(c => c.ClientId).HasColumnName("ClientId")
                .ValueGeneratedOnAdd();
            builder.Property(c => c.FirstName).HasColumnName("FirstName")
                .HasMaxLength(50);
            builder.Property(c => c.LastName).HasColumnName("LastName")
                .HasMaxLength(50);
            builder.Property(c => c.Email).HasColumnName("Email")
                .HasMaxLength(50);
            builder.Property(c => c.Organization).HasColumnName("Organization")
                .HasMaxLength(100);
            builder.HasOne(c => c.Project)
                .WithOne(p => p.Client)
                .HasForeignKey<Project>(m => m.ClientId);
        }
    }
}
