using PhazaAudioPlayer.Core.Models;

namespace PhazaAudioPlayer.Core.PlaylistProviders
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
