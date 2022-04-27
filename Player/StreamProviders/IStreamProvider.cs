using YandexMusicApp.AudioPlayer.Models;

namespace YandexMusicApp.AudioPlayer.StreamProviders
{
    internal interface IStreamProvider
    {
        /// <summary>
        /// Загружает поток музыки на основе информации о треке.
        /// </summary>
        /// <param name="track">Информация о треке.</param>
        /// <returns>Поток музыки или null (в случае отсутствия трека).</returns>
        public Stream? LoadStream(Track track);
    }
}
