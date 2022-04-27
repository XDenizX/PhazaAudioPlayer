using YandexMusicApp.AudioPlayer.Models;

namespace YandexMusicApp.AudioPlayer.PlaylistProviders
{
    internal interface IPlaylistProvider
    {
        Playlist GetPlaylist(string uuid);
    }
}
