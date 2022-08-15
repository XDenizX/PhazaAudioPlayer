using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows.Media;
using ReactiveMarbles.ObservableEvents;

namespace PhazaAudioPlayer.ViewModels
{
    public class PlayerPanelViewModel : ReactiveObject
    {
        private readonly MediaPlayer _mediaPlayer = new();

        [Reactive] public TrackViewModel CurrentTrack { get; set; }
        [Reactive] public float Volume { get; set; } = 50;
        [Reactive] public double Position { get; set; }
        [Reactive] public bool IsPlaying { get; set; }
        [Reactive] public bool IsMuted { get; set; }
        [Reactive] public ObservableCollection<TrackViewModel> Query { get; set; }
        [Reactive] public double Duration { get; set; }

        [Reactive] public ReactiveCommand<TrackViewModel, Unit> PlayCommand { get; set; }

        public PlayerPanelViewModel()
        {
            var volumeSubscribe = this
                .WhenAnyValue(x => x.Volume)
                .Select(x => x / 100)
                .Subscribe(volume => _mediaPlayer.Volume = volume);

            var timerObservable = Observable
                .Timer(DateTimeOffset.Now, TimeSpan.FromSeconds(1), RxApp.MainThreadScheduler);

            var positionRefreshSubscribe = timerObservable
                .Subscribe(x => Position = _mediaPlayer.Position.TotalSeconds);

            var positionSubscribe = this
                .WhenAnyValue(x => x.Position)
                .Subscribe(x => _mediaPlayer.Position = TimeSpan.FromSeconds(x));

            var mediaOpenObservable = _mediaPlayer.Events().MediaOpened;

            var mediaOpenSubscribe = mediaOpenObservable
                .Subscribe(x =>
                {
                    if (_mediaPlayer.NaturalDuration.HasTimeSpan)
                    {
                        Duration = _mediaPlayer.NaturalDuration.TimeSpan.TotalSeconds;
                    }
                });

            var isMutedObservable = this
                .WhenAnyValue(x => x.IsMuted)
                .Subscribe(isMuted => _mediaPlayer.IsMuted = isMuted);

            PlayCommand = ReactiveCommand.Create<TrackViewModel>(Play);
        }

        private void Play(TrackViewModel track)
        {
            _mediaPlayer.Open(track.Path);
            _mediaPlayer.Play();
        }
    }
}
