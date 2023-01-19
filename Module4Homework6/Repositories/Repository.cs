using Microsoft.EntityFrameworkCore;
using Module4Homework6.Context;
using Module4Homework6.Contracts;

namespace Module4Homework6.Repositories
{
    public class Repository : IRepository
    {
        private readonly ApplicationContext _context;
        public Repository()
        {
            _context = new ();
        }
        public void GetNumberOfSongsInEachGenre()
        {
            var query = from songs in _context.Songs
                        where songs.ReleasedDate < 
                        ( from artist in _context.Artists
                        select artist ).Min(s => s.DateOfBirth)
                        select songs;

            Console.WriteLine(query.ToQueryString() + Environment.NewLine);
        }

        public void GetSongsThatHaveGenreAndExistingArtist()
        {
            var query = from songs in _context.Songs
                        join genres in _context.Genres
                        on songs.GenreId equals genres.Id
                        join artSongs in _context.ArtistSongs
                        on songs.Id equals artSongs.SongId
                        select new
                        {
                            songs.Id,
                            songs.Title,
                            songs.Duration,
                            songs.ReleasedDate,
                            songs.GenreId
                        };

            Console.WriteLine(query.ToQueryString() + Environment.NewLine);
        }

        public void GetSongsThatWereWrittenBeforeYoungestPerformerWasBorn()
        {
            var query = from genres in _context.Genres
                        select new
                        {
                            genres.Title,
                            Count = (from songs in _context.Songs
                                     where songs.GenreId == genres.Id
                                     select songs
                                     ).Count()
                        };

            Console.WriteLine(query.ToQueryString() + Environment.NewLine);
        }

        public void GetSongTitleArtistNameGenreName()
        {
            var query = from songs in _context.Songs
                        join artSongs in _context.ArtistSongs
                        on songs.Id equals artSongs.SongId
                        join artists in _context.Artists
                        on artSongs.ArtistId equals artists.Id
                        join genres in _context.Genres
                        on songs.GenreId equals genres.Id into gj
                        from genr in gj.DefaultIfEmpty()
                        select new
                        {
                            SongTitle = songs.Title,
                            artists.Name,
                            GenreTitle = genr.Title
                        };

            Console.WriteLine(query.ToQueryString() + Environment.NewLine);
        }
    }
}
