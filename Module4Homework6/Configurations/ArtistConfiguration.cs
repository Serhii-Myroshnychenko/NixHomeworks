using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4Homework6.Models;

namespace Module4Homework6.Configurations
{
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.ToTable("Artist").HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Id")
                .ValueGeneratedOnAdd();
            builder.Property(c => c.Name).HasColumnName("Name").IsRequired(true);
            builder.Property(c => c.DateOfBirth).HasColumnName("DateOfBirth").IsRequired(true);
            builder.Property(c => c.Phone).HasColumnName("Phone").IsRequired(false);
            builder.Property(c => c.Email).HasColumnName("Email").IsRequired(false);
            builder.Property(c => c.InstagramUrl).HasColumnName("InstagramUrl").IsRequired(false);
            builder.HasMany(c => c.ArtistSongs)
                .WithOne(s => s.Artist)
                .HasForeignKey(s => s.ArtistId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
