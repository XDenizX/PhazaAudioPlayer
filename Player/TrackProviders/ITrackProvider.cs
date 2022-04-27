using YandexMusicApp.AudioPlayer.Models;

namespace YandexMusicApp.AudioPlayer.TrackProviders
{
    internal interface ITrackProvider
    {
        public Track GetTrack(string uuid);
    }
}
