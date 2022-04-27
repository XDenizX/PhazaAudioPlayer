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
                    new() { Name = $"{uuid}_1" },
                    new() { Name = $"{uuid}_2" }
                }
            };
        }
    }
}
