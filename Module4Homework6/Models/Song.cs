namespace Module4Homework6.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Duration { get; set; }
        public DateTime ReleasedDate { get; set; }
        public int? GenreId { get;set; }
        public virtual Genre Genre { get; set; }
        public virtual ICollection<ArtistSong> ArtistSongs { get; set; }
    }
}
