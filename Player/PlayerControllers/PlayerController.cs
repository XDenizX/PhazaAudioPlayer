using YandexMusicApp.AudioPlayer.Models;
using YandexMusicApp.AudioPlayer.Players;
using YandexMusicApp.AudioPlayer.StreamProviders;

namespace YandexMusicApp.AudioPlayer.PlayerControllers
{
    public class PlayerController : IPlayerController, IDisposable
    {
        public bool IsPlaying => _player.IsPlaying;
        public Track Current => Playlist.Tracks[_currentTrackIndex];

        private Playlist _playlist;

        public Playlist Playlist
        {
            get => _playlist;
            set
            {
                _currentTrackIndex = 0;
                _playlist = value;
            }
        }

        public event Action<Track>? TrackEnded;
        public event Action<Playlist>? PlaylistEnded;

        public RepeatMode Repeat { get; set; }
        public bool IsShuffling { get; set; }

        public float Volume
        {
            get => _player.Volume;
            set => _player.Volume = value;
        }

        public float Position
        {
            get => _player.Position;
            set => _player.Position = value;
        }

        private const float SkipToEndOffset = 0.03f;

        private IAudioPlayer _player;
        private int _currentTrackIndex;

        private StreamFactory _streamFactory;

        public PlayerController(IAudioPlayer player, StreamFactory streamFactory)
        {
            _streamFactory = streamFactory;

            _player = player;
            _player.StreamEnded += OnPlayerStreamEnded;
        }

        private void OnPlayerStreamEnded()
        {
            TrackEnded?.Invoke(Current);

            if (Repeat == RepeatMode.Track)
            {
                _player.Position = 0.0f;
                _player.Play();
            }
            else
            {
                Next();
            }
        }

        private void PrepareStream(Track track)
        {
            _player.SetStream(_streamFactory.Load(track));
        }

        private void Next()
        {
            if (_currentTrackIndex >= Playlist.Tracks.Count - 1)
            {
                if (Repeat == RepeatMode.Playlist)
                {
                    _currentTrackIndex = 0;
                }

                PlaylistEnded?.Invoke(Playlist);
            }
            else
            {
                _currentTrackIndex++;
            }

            PrepareStream(Current);
            _player.Play();
        }

        private void Previous()
        {
            if (_currentTrackIndex > 0)
            {
                _currentTrackIndex--;
            }

            PrepareStream(Current);
            _player.Play();
        }

        public void StartPlayback()
        {
            if (!_player.IsReadyToPlay)
            {
                PrepareStream(Current);
            }

            _player.Play();
        }

        public void ForcePlay()
        {
            PrepareStream(Current);
            _player.Play();
        }

        public void PausePlayback()
        {
            _player.Pause();
        }

        public void SkipToEnd()
        {
            Next();
        }

        public void SkipToStart()
        {
            if (_player.Position < SkipToEndOffset)
            {
                Previous();
            }
            else
            {
                _player.Position = 0.0f;
            }
        }

        public void Dispose()
        {
            _player.StreamEnded -= OnPlayerStreamEnded;
        }
    }
}
