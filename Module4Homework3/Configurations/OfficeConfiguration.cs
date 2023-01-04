using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4Homework3.Models;

namespace Module4Homework3.Configurations
{
    public class OfficeConfiguration : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder.ToTable("Office").HasKey(o => o.OfficeId);
            builder.Property(o => o.OfficeId).HasColumnName("OfficeId")
                .ValueGeneratedOnAdd();
            builder.Property(o => o.Title).HasColumnName("Title")
                .HasMaxLength(100);
            builder.Property(o => o.Location).HasColumnName("Location")
                .HasMaxLength(100);
            builder.HasMany(o => o.Employees)
                .WithOne(e => e.Office)
                .HasForeignKey(e => e.OfficeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
