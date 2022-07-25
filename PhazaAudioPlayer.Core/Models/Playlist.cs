namespace PhazaAudioPlayer.Core.Models
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
