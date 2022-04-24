using NAudio.Wave;
using Player.Models;
using Player.StreamProviders;

namespace Player.Players
{
    public class Player : IPlayer
    {
        public Track Current => _tracks[_currentIndex];

        private int _currentIndex;
        private readonly List<Track> _tracks;

        private readonly List<IStreamProvider> _streamProviders;

        public Player()
        {
            _currentIndex = 0;
            _tracks = new List<Track>();
            _streamProviders = new List<IStreamProvider>()
            {
                new LocalStorageStreamProvider(),
                new UrlStreamProvider()
            };
        }

        private Stream? GetTrackStream()
        {
            Stream? stream = null;
            foreach (IStreamProvider streamProvider in _streamProviders)
            {
                stream = streamProvider.LoadStream(Current);
            }

            return stream;
        }

        public bool Play()
        {
            Stream? stream = GetTrackStream();
            if (stream == null)
            {
                return false;
            }

            WaveStream waveStream = new WaveFileReader(stream);
            WaveOutEvent waveOutEvent = new WaveOutEvent();

            waveOutEvent.Init(waveStream);
            waveOutEvent.Play();

            return true;
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public bool Next()
        {
            throw new NotImplementedException();
        }

        public bool Previous()
        {
            throw new NotImplementedException();
        }
    }
}