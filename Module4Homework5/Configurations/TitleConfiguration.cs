using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4Homework5.Models;

namespace Module4Homework5.Configurations
{
    public class TitleConfiguration : IEntityTypeConfiguration<Title>
    {
        public void Configure(EntityTypeBuilder<Title> builder)
        {
            builder.ToTable("Title").HasKey(t => t.TitleId);
            builder.Property(t => t.TitleId).HasColumnName("TitleId")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.Name).HasColumnName("Name")
                .HasMaxLength(50);
            builder.HasMany(t => t.Employees)
                .WithOne(e => e.Title)
                .HasForeignKey(e => e.TitleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
