using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace PhazaAudioPlayer.ViewModels;

public class TrackViewModel : ReactiveObject
{
    [Reactive] public Uri Path { get; set; }
    [Reactive] public string Name { get; set; }
    [Reactive] public string Artist { get; set; }
    [Reactive] public bool IsPlaying { get; set; }
    [Reactive] public bool IsLiked { get; set; }
    [Reactive] public Uri ImageUri { get; set; }
    [Reactive] public ImageSource Image { get; private set; }

    public TrackViewModel()
    {
        var imageUriObserver = this.WhenAnyValue(x => x.ImageUri)
            .WhereNotNull()
            .Subscribe(uri => Image = new BitmapImage(uri));
    }
}