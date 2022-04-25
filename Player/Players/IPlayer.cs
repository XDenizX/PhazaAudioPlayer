using Player.Models;

namespace Player.Players
{
    public interface IPlayer
    {
        /// <summary>
        /// Текущий проигрываемый объект.
        /// </summary>
        public Track Current { get; }

        /// <summary>
        /// Пытается начать проигрывание потока музыки.
        /// </summary>
        /// <returns>true - если поток успешно запущен.<br/>false - в ином случае.</returns>
        public bool Play();

        /// <summary>
        /// Останавливает поток музыки.
        /// </summary>
        public void Stop();

        /// <summary>
        /// Пытается перейти к следующему треку.
        /// </summary>
        /// <returns>true - в случае успешного перехода.<br/>false - если переход не был выполнен.</returns>
        public bool Next();

        /// <summary>
        /// Пытается перейти к предыдущему треку.
        /// </summary>
        /// <returns>true - в случае успешного перехода.<br/>false - если переход не был выполнен.</returns>
        public bool Previous();
    }
}
