using Player.Models;

namespace Player.StreamProviders
{
    public interface IStreamProvider
    {
        public Stream? LoadStream(Track track);
    }
}
