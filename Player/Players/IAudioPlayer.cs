using YandexMusicApp.AudioPlayer.Models;

namespace YandexMusicApp.AudioPlayer.Players
{
    public interface IAudioPlayer
    {
        public enum RepeatMode
        {
            None,
            Track,
            Playlist
        }

        /// <summary>
        /// Текущий трек.
        /// </summary>
        public Track Current { get; }

        /// <summary>
        /// Проигрываемый плейлист
        /// </summary>
        public Playlist Playlist { get; set; }

        /// <summary>
        /// Проигрывается ли текущий трек.
        /// </summary>
        public bool IsPlaying { get; }

        /// <summary>
        /// Режим повтора
        /// </summary>
        public RepeatMode Repeat{ get; set; }

        /// <summary>
        /// Перемешивать треки
        /// </summary>
        public bool IsShuffling { get; set; }

        /// <summary>
        /// Событие конца проигрывания трека
        /// </summary>
        public event Action<Track> TrackEnded;

        /// <summary>
        /// Событие конца проигрываемого плейлиста
        /// </summary>
        public event Action<Playlist> PlaylistEnded;
        public event Action<Playlist> PlaylistRoundEnded;

        /// <summary>
        /// Начинает проигрывание потока музыки.
        /// </summary>
        public void Play();

        /// <summary>
        /// Приостанавливает поток музыки. Указатель чтения потока музыки не перемещается.
        /// </summary>
        public void Pause();


        /// <summary>
        /// Пытается перейти к следующему треку.
        /// </summary>
        /// <returns>true - в случае успешного перехода.<br/>false - если переход не был выполнен.</returns>
        public void Next();

        /// <summary>
        /// Пытается перейти к предыдущему треку.
        /// </summary>
        /// <returns>true - в случае успешного перехода.<br/>false - если переход не был выполнен.</returns>
        public void Previous();

        /// <summary>
        /// Значение громкости от 0.0 до 1.0.
        /// </summary>
        public float Volume { get; set; }

        /// <summary>
        /// Значение позиции проигрываемого трека от 0.0 до 1.0.
        /// </summary>
        public float Position { get; set; }
    }
}
