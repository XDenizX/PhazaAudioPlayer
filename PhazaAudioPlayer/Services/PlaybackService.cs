using PhazaAudioPlayer.Core.Players;

namespace PhazaAudioPlayer.Services
{
    public class PlaybackService
    {
        private readonly IAudioPlayer _audioPlayer = Kernel.Get<IAudioPlayer>();

        public PlaybackService()
        {

        }
    }
}
