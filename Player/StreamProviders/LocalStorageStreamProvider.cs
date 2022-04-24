using Player.Models;

namespace Player.StreamProviders
{
    public class LocalStorageStreamProvider : IStreamProvider
    {
        public Stream? LoadStream(Track track)
        {
            track.Name = "test";
            throw new NotImplementedException();
        }
    }
}
