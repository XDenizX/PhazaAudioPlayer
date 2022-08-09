namespace PhazaAudioPlayer.Infrastructure.Interfaces
{
    public interface IAudioService
    {
        void Play();
        void Pause();
        void Stop();
        bool IsPlaying { get; }
    }
}
