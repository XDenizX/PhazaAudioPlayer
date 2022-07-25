using NAudio.Wave;

namespace PhazaAudioPlayer.Core.Players
{
    public class NAudioPlayer : IAudioPlayer, IDisposable
    {
        public bool IsPlaying => _waveOut.PlaybackState == PlaybackState.Playing;
        public bool IsReadyToPlay => _waveStream != null;

        public event Action? StreamEnded;

        public float Volume
        {
            get => _waveOut.Volume;
            set => _waveOut.Volume = Math.Clamp(value, 0.0f, 1.0f);
        }

        public float Position
        {
            get
            {
                if (_waveStream != null)
                {
                    return (float)_waveStream.Position / _waveStream.Length;
                }

                return 0.0f;
            }
            set
            {
                if (_waveStream != null)
                {
                    _waveStream.Position = (long)(_waveStream.Length * Math.Clamp(value, 0.0, 1.0));
                }
            }
        }

        private readonly WaveOutEvent _waveOut;
        private WaveStream? _waveStream;

        private bool _unhandledStop;

        public NAudioPlayer()
        {
            _waveOut = new WaveOutEvent();
            _waveOut.PlaybackStopped += OnPlaybackStopped;
        }

        private void OnPlaybackStopped(object? sender, EventArgs e)
        {
            if (_unhandledStop)
            {
                _unhandledStop = false;
                return;
            }

            StreamEnded?.Invoke();
        }

        private void CallUnhandledStop()
        {
            _unhandledStop = true;
            _waveOut.Stop();
        }

        public void SetStream(Stream stream)
        {
            if (_waveOut.PlaybackState != PlaybackState.Stopped)
            {
                CallUnhandledStop();
            }

            _waveStream?.Close();

            _waveStream = new StreamMediaFoundationReader(stream);
            _waveOut.Init(_waveStream);
        }

        public void Play()
        {
            _waveOut.Play();
        }

        public void Pause()
        {
            _waveOut.Pause();
        }

        public void Dispose()
        {
            _waveOut.PlaybackStopped -= OnPlaybackStopped;

            _waveOut.Dispose();
            _waveStream?.Dispose();
        }
    }
}