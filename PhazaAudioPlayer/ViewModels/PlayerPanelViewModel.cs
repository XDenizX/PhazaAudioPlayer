using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows.Media;

namespace PhazaAudioPlayer.ViewModels
{
    public class PlayerPanelViewModel : ReactiveObject
    {
        private readonly MediaPlayer _mediaPlayer = new();

        [Reactive] public TrackViewModel CurrentTrack { get; set; }
        [Reactive] public float Volume { get; set; }
        [Reactive] public double Position { get; set; }
        [Reactive] public bool IsPlaying { get; set; }
        [Reactive] public ObservableCollection<TrackViewModel> Query { get; set; }

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

            PlayCommand = ReactiveCommand.Create<TrackViewModel>(Play);
        }

        private void Play(TrackViewModel track)
        {
            _mediaPlayer.Open(track.Path);
            _mediaPlayer.Play();
        }
    }
}
