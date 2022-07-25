using PhazaAudioPlayer.Core.Models;

namespace PhazaAudioPlayer.Core.TrackProviders
{
    internal interface ITrackProvider
    {
        public Track GetTrack(string uuid);
    }
}
