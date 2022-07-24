using YandexMusicApp.AudioPlayer.Models;

namespace YandexMusicApp.AudioPlayer.StreamProviders
{
    public interface IStreamProvider
    {
        /// <summary>
        /// Копирует данные из потока в свое быстродоступное хранилище.
        /// </summary>
        /// <param name="track">Информация о треке</param>
        /// <param name="stream">Поток трека</param>
        /// <returns>Поток в быстродоступном хранилище</returns>
        public Stream? Cache(Track track, Stream stream);

        /// <summary>
        /// Получает поток трека.
        /// </summary>
        /// <param name="track">Информация о треке</param>
        /// <returns>Поток трека</returns>
        public Stream? GetLoadingStream(Track track);
    }
}
