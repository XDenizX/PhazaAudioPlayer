using PhazaAudioPlayer.Core.Models;

namespace PhazaAudioPlayer.Core.StreamProviders
{
    public class StreamFactory
    {
        private List<IStreamProvider> _registeredProviders = new();

        public void RegisterProviders(IEnumerable<IStreamProvider> providers)
        {
            if (_registeredProviders.Count > 0)
            {
                throw new Exception($"Stream providers already registered. Clear it before new registration: {nameof(ClearProviders)}()");
            }

            foreach (IStreamProvider provider in providers)
            {
                _registeredProviders.Add(provider);
            }
        }

        public void ClearProviders()
        {
            _registeredProviders.Clear();
        }

        public Stream? Load(Track track)
        {
            int i;
            Stream? loadedStream = null;

            for (i = 0; i < _registeredProviders.Count; i++)
            {
                IStreamProvider provider = _registeredProviders[i];
                loadedStream = provider.GetLoadingStream(track);

                if (loadedStream != null)
                {
                    break;
                }
            }

            if (loadedStream != null)
            {
                for (; i > 0; i--)
                {
                    loadedStream = _registeredProviders[i - 1].Cache(track, loadedStream);
                }
            }

            return loadedStream;
        }
    }
}
