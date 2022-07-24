using YandexMusicApp.AudioPlayer.Models;

namespace YandexMusicApp.AudioPlayer.StreamProviders
{
    public class HttpStreamProvider : IStreamProvider
    {
        public Stream? Cache(Track track, Stream stream)
        {
            // Реализации кеширования для HTTP нет.
            return null;
        }

        public Stream? GetLoadingStream(Track track)
        {
            string trackUrl = GetTrackUrl(track);
            HttpClient httpClient = new HttpClient();

            Task<Stream> getStreamTask = httpClient.GetStreamAsync(trackUrl);
            getStreamTask.Wait();

            return getStreamTask.Result;
        }

        private string GetTrackUrl(Track track)
        {
            return track.Uuid;
        }
    }
}
