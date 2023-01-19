using Microsoft.EntityFrameworkCore;
using Module4Homework6.Models;

namespace Module4Homework6.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>().HasData(
                new Artist
                {
                    Id = 1,
                    Name = "Snoop Dogg",
                    DateOfBirth = new DateTime(1998,12,11),
                    Phone = "+380761234567",
                    Email = "snoop@gmail.com",
                    InstagramUrl = "https://www.instagram.com/snoopdogg/"
                },
                new Artist
                {
                    Id = 2,
                    Name = "Lil Nas X",
                    DateOfBirth = new DateTime(2000, 05, 05),
                    Phone = "+3804567812567",
                    Email = "lil@gmail.com",
                    InstagramUrl = "https://www.instagram.com/lilnasxunlimited/"
                },
                new Artist
                {
                    Id = 3,
                    Name = "Katy Perry",
                    DateOfBirth = new DateTime(1988, 12, 22),
                    Phone = "+3807891234456",
                    Email = "katy@gmail.com",
                    InstagramUrl = "https://www.instagram.com/katyperry/"
                },
                new Artist
                {
                    Id = 4,
                    Name = "Rihanna",
                    DateOfBirth = new DateTime(1995, 08, 17),
                    Phone = "+3807895678123",
                    Email = "rihanna@gmail.com",
                    InstagramUrl = "https://www.instagram.com/badgalriri/"
                },
                new Artist
                {
                    Id = 5,
                    Name = "Billie Eilish",
                    DateOfBirth = new DateTime(1997, 12, 22),
                    Phone = "+3805674523456",
                    Email = "billie@gmail.com",
                    InstagramUrl = "https://www.instagram.com/billieeilish/"
                }
            );
            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Title = "Pop" },
                new Genre { Id = 2, Title = "Rap"},
                new Genre { Id = 3, Title = "Rock"},
                new Genre { Id = 4, Title = "Jazz" },
                new Genre { Id = 5, Title = "Classical" }
            );
            modelBuilder.Entity<Song>().HasData(
                new Song
                {
                    Id = 1,
                    Title = "Beautiful",
                    Duration = new DateTime(2000, 8, 15, 0, 2, 30),
                    ReleasedDate = new DateTime(2018,05,12),
                    GenreId = 1
                },
                new Song
                {
                    Id = 2,
                    Title = "Old Town Road",
                    Duration = new DateTime(2000, 8, 15, 0, 3, 50),
                    ReleasedDate = new DateTime(2020, 05, 12),
                    GenreId = 2
                },
                new Song
                {
                    Id = 3,
                    Title = "Dark Hourse",
                    Duration = new DateTime(2000, 8, 15, 0, 1, 40),
                    ReleasedDate = new DateTime(2021, 11, 15),
                    GenreId = 3
                },
                new Song
                {
                    Id = 4,
                    Title = "Diamonds",
                    Duration = new DateTime(2000, 8, 15, 0, 2, 25),
                    ReleasedDate = new DateTime(2020, 12, 08),
                    GenreId = 4
                },
                new Song
                {
                    Id = 5,
                    Title = "Lovely",
                    Duration = new DateTime(2000, 8, 15, 0, 3, 22),
                    ReleasedDate = new DateTime(2022, 05, 13),
                    GenreId = 5
                }
            );
            modelBuilder.Entity<ArtistSong>().HasData(
                new ArtistSong { ArtistId = 1, SongId = 1 },
                new ArtistSong { ArtistId = 2, SongId = 2 },
                new ArtistSong { ArtistId = 3, SongId = 3 },
                new ArtistSong { ArtistId = 4, SongId = 4 },
                new ArtistSong { ArtistId = 5, SongId = 5 }
            );
        }
    }
}
