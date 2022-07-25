namespace PhazaAudioPlayer.Core.Models
{
    public class Track
    {
        /// <summary>
        /// Уникальный идентификатор трека.
        /// </summary>
        public string Uuid { get; internal set; }

        /// <summary>
        /// Имя трека.
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Список исполнителей.
        /// </summary>
        public IEnumerable<Artist> Artists { get; internal set; }

        internal Track()
        { }
    }
}
