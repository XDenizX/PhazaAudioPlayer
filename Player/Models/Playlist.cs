namespace YandexMusicApp.AudioPlayer.Models
{
    public class Playlist
    {
        /// <summary>
        /// Список треков
        /// </summary>
        public List<Track> Tracks { get; internal set; }

        internal Playlist()
        { }
    }
}
