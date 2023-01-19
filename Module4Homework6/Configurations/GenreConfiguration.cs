using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4Homework6.Models;

namespace Module4Homework6.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genre").HasKey(g => g.Id);
            builder.Property(g => g.Id).HasColumnName("Id")
                .ValueGeneratedOnAdd();
            builder.Property(g => g.Title).HasColumnName("Title").IsRequired(true);
            builder.HasMany(g => g.Songs)
                .WithOne(s => s.Genre)
                .HasForeignKey(s => s.GenreId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
