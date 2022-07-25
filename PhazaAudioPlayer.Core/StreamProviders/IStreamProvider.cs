using PhazaAudioPlayer.Core.Models;

namespace PhazaAudioPlayer.Core.StreamProviders
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
