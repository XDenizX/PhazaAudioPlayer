using PhazaAudioPlayer.Core.Models;
using PhazaAudioPlayer.Core.TrackProviders;

namespace PhazaAudioPlayer.Core.PlaylistProviders
{
    public class TestPlaylistProvider : IPlaylistProvider
    {
        private ITrackProvider _trackProvider = new TestTrackProvider();
        public Playlist GetPlaylist(string uuid)
        {
            return new Playlist
            {
                Tracks = new List<Track>
                {
                    _trackProvider.GetTrack("https://s117iva.storage.yandex.net/get-mp3/172e2ae89ff8b7e40182fd9de55751b0/0005e48ee83d05b3/rmusic/U2FsdGVkX1_x2iocrf6X9x-JXvjhojvwBeDhbOa5zFkL3GCu3wN_zBDzCnsDAKvrK-WgrHWDrby_SQLVTEp5CctYKeFFYnaVIE-FTec-Bow/5037de16d59d63fb649ff64b2be0975073b9c7f0611cf774bbb9a4ea91865e19/28699")
                }
            };
        }
    }
}
