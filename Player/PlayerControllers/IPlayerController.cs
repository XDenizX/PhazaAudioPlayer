using YandexMusicApp.AudioPlayer.Models;

namespace YandexMusicApp.AudioPlayer.PlaybackControllers
{
    public interface IPlayerController
    {
        public enum RepeatMode
        {
            None,
            Track,
            Playlist
        }

        /// <summary>
        /// Playing current track.
        /// </summary>
        public bool IsPlaying { get; }

        /// <summary>
        /// Playing currently track.
        /// </summary>
        public Track Current { get; }

        /// <summary>
        /// Playlist to play.
        /// </summary>
        public Playlist Playlist { get; set; }

        /// <summary>
        /// The action is triggered when current track has reached the end of the stream.
        /// </summary>
        public event Action<Track> TrackEnded;

        /// <summary>
        /// The action is triggered when all tracks in the playlist have ended.
        /// </summary>
        public event Action<Playlist> PlaylistEnded;

        /// <summary>
        /// Repeat mode for the track and playlist.
        /// </summary>
        public RepeatMode Repeat { get; set; }

        /// <summary>
        /// Mix tracks in playlist.
        /// </summary>
        public bool IsShuffling { get; set; }

        /// <summary>
        /// Music volume.
        /// </summary>
        public float Volume { get; set; }

        /// <summary>
        /// Track position.
        /// </summary>
        public float Position { get; set; }

        /// <summary>
        /// Forcibly reloads the stream of the current track and starts playback
        /// </summary>
        public void ForcePlay();

        /// <summary>
        /// Start or continue playing current playlist.
        /// </summary>
        public void StartPlayback();

        /// <summary>
        /// Pause playing current playlist.
        /// </summary>
        public void PausePlayback();

        /// <summary>
        /// Skip to the end.
        /// </summary>
        public void SkipToEnd();

        /// <summary>
        /// Skip to the start.
        /// </summary>
        public void SkipToStart();
    }
}
