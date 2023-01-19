using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4Homework6.Models;

namespace Module4Homework6.Configurations
{
    public class ArtistSongConfiguration : IEntityTypeConfiguration<ArtistSong>
    {
        public void Configure(EntityTypeBuilder<ArtistSong> builder)
        {
            builder.ToTable("ArtistSong").HasKey(ars => new { ars.ArtistId, ars.SongId});
            builder.Property(ars => ars.ArtistId).HasColumnName("ArtistId").IsRequired(true);
            builder.Property(ars => ars.SongId).HasColumnName("SongId").IsRequired(true);
            builder.HasOne(ars => ars.Artist)
                .WithMany(a => a.ArtistSongs)
                .HasForeignKey(ars => ars.ArtistId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(ars => ars.Song)
                .WithMany(a => a.ArtistSongs)
                .HasForeignKey(ars => ars.SongId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
