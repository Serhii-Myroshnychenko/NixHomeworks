using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4Homework6.Models;

namespace Module4Homework6.Configurations
{
    public class SongConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.ToTable("Song").HasKey(s => s.Id);
            builder.Property(s => s.Id).HasColumnName("Id")
                .ValueGeneratedOnAdd();
            builder.Property(s => s.Title).HasColumnName("Title").IsRequired(true);
            builder.Property(s => s.Duration).HasColumnName("Duration").IsRequired(true);
            builder.Property(s => s.ReleasedDate).HasColumnName("ReleasedDate").IsRequired(true);
            builder.Property(s => s.GenreId).HasColumnName("GenreId").IsRequired(false);
            builder.HasOne(s => s.Genre)
                .WithMany(g => g.Songs)
                .HasForeignKey(s => s.GenreId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(s => s.ArtistSongs)
                .WithOne(s => s.Song)
                .HasForeignKey(s => s.SongId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
