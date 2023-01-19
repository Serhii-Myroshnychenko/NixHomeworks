using System.ComponentModel.DataAnnotations;

namespace Module4Homework6.Models
{
    public class ArtistSong
    {
        public int ArtistId { get; set; }
        public int SongId { get; set; }
        public virtual Artist Artist { get; set; }
        public virtual Song Song { get; set; }
    }
}
