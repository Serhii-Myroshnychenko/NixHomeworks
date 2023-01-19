namespace Module4Homework6.Contracts
{
    public interface IRepository
    {
        void GetSongTitleArtistNameGenreName();
        void GetSongsThatHaveGenreAndExistingArtist();
        void GetNumberOfSongsInEachGenre();
        void GetSongsThatWereWrittenBeforeYoungestPerformerWasBorn();
    }
}
