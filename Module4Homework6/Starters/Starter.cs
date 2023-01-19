using Module4Homework6.Context;
using Module4Homework6.Repositories;

namespace Module4Homework6.Starters
{
    public static class Starter
    {
        public static void Run()
        {
            Repository repository = new ();
            repository.GetNumberOfSongsInEachGenre();
            repository.GetSongsThatHaveGenreAndExistingArtist();
            repository.GetSongTitleArtistNameGenreName();
            repository.GetSongsThatWereWrittenBeforeYoungestPerformerWasBorn();
        }
    }
}
