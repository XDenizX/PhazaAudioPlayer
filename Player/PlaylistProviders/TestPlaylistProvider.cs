using YandexMusicApp.AudioPlayer.Models;

namespace YandexMusicApp.AudioPlayer.PlaylistProviders
{
    public class TestPlaylistProvider : IPlaylistProvider
    {
        public Playlist GetPlaylist(string uuid)
        {
            return new Playlist
            {
                Tracks = new List<Track>
                {
                    new() { Name = $"Tracks/{uuid}/1" }
                }
            };
        }
    }
}
