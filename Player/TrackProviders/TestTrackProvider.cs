using YandexMusicApp.AudioPlayer.Models;

namespace YandexMusicApp.AudioPlayer.TrackProviders
{
    public class TestTrackProvider : ITrackProvider
    {
        public Track GetTrack(string uuid)
        {
            return new Track
            {
                Name = "track.mp3",
                Uuid = uuid,
                Artists = new List<Artist>
                {
                    new()
                    {
                        Name = "John Smith"
                    }
                }
            };
        }
    }
}
