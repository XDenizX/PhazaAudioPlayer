using YandexMusicApp.AudioPlayer.Models;

namespace YandexMusicApp.AudioPlayer.StreamProviders
{
    public class LocalStorageStreamProvider : IStreamProvider
    {
        public Stream? Cache(Track track, Stream stream)
        {
            string fileName = GetTrackFileName(track);

            if (File.Exists(fileName))
            {
                return null;
            }

            FileStream fileStream = File.Create(fileName);
            stream.CopyTo(fileStream);
            stream.Dispose();

            return fileStream;
        }

        public Stream? GetLoadingStream(Track track)
        {
            string fileName = GetTrackFileName(track);

            if (File.Exists(fileName))
            {
                return new FileStream(fileName, FileMode.Open);
            }

            return null;
        }

        private string GetTrackFileName(Track track)
        {
            return track.Name;
        }
    }
}
