using YandexMusicApp.AudioPlayer.Models;

namespace YandexMusicApp.AudioPlayer.StreamProviders
{
    public class LocalStorageStreamProvider : IStreamProvider
    {
        public Stream? LoadStream(Track track)
        {
            Stream memoryStream = new MemoryStream();
            Stream fileStream = File.Open($"{track.Name}.mp3", FileMode.Open);

            fileStream.CopyTo(memoryStream);
            fileStream.Close();

            return memoryStream;
        }
    }
}
