using PhazaAudioPlayer.Core.Models;

namespace PhazaAudioPlayer.Core.PlaylistProviders
{
    internal interface IPlaylistProvider
    {
        Playlist GetPlaylist(string uuid);
    }
}
