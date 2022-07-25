namespace PhazaAudioPlayer.Core.Players
{
    public interface IAudioPlayer
    {
        /// <summary>
        /// Is the stream currently being played.
        /// </summary>
        public bool IsPlaying { get; }

        /// <summary>
        /// The action has reached the end of the stream.
        /// </summary>
        public event Action StreamEnded;

        /// <summary>
        /// Is stream ready for reading and play.
        /// </summary>
        public bool IsReadyToPlay { get; }

        /// <summary>
        /// Set the current stream.
        /// </summary>
        /// <param name="stream"></param>
        public void SetStream(Stream stream);

        /// <summary>
        /// Play or continue current stream.
        /// </summary>
        public void Play();

        /// <summary>
        /// Pause the current stream.
        /// </summary>
        public void Pause();

        /// <summary>
        /// Volume value from 0.0 to 1.0.
        /// </summary>
        public float Volume { get; set; }

        /// <summary>
        /// Stream position from 0.0 to 1.0.
        /// </summary>
        public float Position { get; set; }
    }
}
