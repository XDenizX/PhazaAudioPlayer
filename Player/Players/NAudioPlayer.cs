using NAudio.Wave;
using YandexMusicApp.AudioPlayer.Models;
using YandexMusicApp.AudioPlayer.StreamProviders;

namespace YandexMusicApp.AudioPlayer.Players
{
    public class NAudioPlayer : IAudioPlayer
    {
        public Track Current => Playlist.Tracks[_currentIndex];
        private int _currentIndex;

        private Playlist _playlist;
        public Playlist Playlist
        {
            get => _playlist;
            set
            {
                _currentIndex = 0;
                _playlist = value;
            }
        }
        public bool IsPlaying => _waveOut.PlaybackState == PlaybackState.Playing;

        public IAudioPlayer.RepeatMode Repeat { get; set; }
        public bool IsShuffling { get; set; }

        public event Action<Track>? TrackEnded;
        public event Action<Playlist>? PlaylistEnded;
        public event Action<Playlist>? PlaylistRoundEnded;
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
                    return (float) _waveStream.Position / _waveStream.Length;
                }

                return 0.0f;
            }
            set
            {
                if (_waveStream != null)
                {
                    _waveStream.Position = (long) (_waveStream.Length * Math.Clamp(value, 0.0, 1.0));
                }
            }
        }

        private readonly List<IStreamProvider> _streamProviders;

        private readonly WaveOutEvent _waveOut;
        private WaveStream? _waveStream;

        private bool _fakeStop;
        private bool _playlistEnded;

        public NAudioPlayer()
        {
            _streamProviders = new List<IStreamProvider>
            {
                new LocalStorageStreamProvider()
            };

            _waveOut = new WaveOutEvent();
            _waveOut.PlaybackStopped += OnPlaybackStopped;
        }

        private void OnPlaybackStopped(object? sender, EventArgs e)
        {
            if (_fakeStop)
            {
                _fakeStop = false;
                return;
            }

            TrackEnded?.Invoke(Current);

            if (Repeat == IAudioPlayer.RepeatMode.Track)
            {
                if (_waveStream != null)
                {
                    Rewind();
                    _waveOut.Play();
                }
            }
            else
            {
                Next();
                if (!(_playlistEnded && Repeat == IAudioPlayer.RepeatMode.None))
                {
                    Play();
                }
            }
        }

        private Stream? GetTrackStream()
        {
            Stream? stream = null;

            foreach (IStreamProvider streamProvider in _streamProviders)
            {
                stream = streamProvider.LoadStream(Current);
            }

            return stream;
        }

        private void FakeStop()
        {
            _fakeStop = true;
            _waveOut.Stop();
        }

        private void UpdateSteam()
        {
            if (_waveOut.PlaybackState != PlaybackState.Stopped)
            {
                FakeStop();
            }
            
            _waveStream?.Close();

            Stream? stream = GetTrackStream();

            if (stream == null)
            {
                throw new NullReferenceException("Can't get audio stream");
            }

            _waveStream = new StreamMediaFoundationReader(stream);
            _waveOut.Init(_waveStream);
        }

        public void Play()
        {
            if (_waveOut.PlaybackState != PlaybackState.Paused)
            {
                UpdateSteam();
            }

            _playlistEnded = false;
            _waveOut.Play();
        }

        public void Pause()
        {
            _waveOut.Pause();
        }

        public void Next()
        {
            if (IsShuffling)
            {
                _currentIndex = Shuffle();
            }
            else
            {
                if (_currentIndex < Playlist.Tracks.Count - 1)
                {
                    _currentIndex++;
                }
                else
                {
                    if (Repeat == IAudioPlayer.RepeatMode.Playlist)
                    {
                        _currentIndex = 0;
                        PlaylistRoundEnded?.Invoke(Playlist);
                    }

                    _playlistEnded = true;
                    PlaylistEnded?.Invoke(Playlist);
                }
            }
        }

        private void Rewind()
        {
            if (_waveStream != null)
            {
                _waveStream.Position = 0;
            }
        }

        public void Previous()
        {
            if (Position < 0.03f)
            {
                if (_currentIndex > 0)
                {
                    _currentIndex--;
                }
            }
            else
            {
                Rewind();
            }
        }

        protected virtual int Shuffle()
        {
            return Random.Shared.Next(Playlist.Tracks.Count);
        }
    }
}