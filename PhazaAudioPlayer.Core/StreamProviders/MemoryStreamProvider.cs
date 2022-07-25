using PhazaAudioPlayer.Core.Models;

namespace PhazaAudioPlayer.Core.StreamProviders
{
    public class MemoryStreamProvider : IStreamProvider
    {
        private Dictionary<string, MemoryStream> _streams = new();

        public Stream? Cache(Track track, Stream stream)
        {
            var newMemoryStream = new MemoryStream();
            stream.CopyTo(newMemoryStream);
            stream.Dispose();

            _streams.Add(track.Name, newMemoryStream);

            return newMemoryStream;
        }

        public Stream? GetLoadingStream(Track track)
        {
            if (_streams.TryGetValue(track.Name, out var stream))
            {
                return stream;
            }

            return null;
        }
    }
}
