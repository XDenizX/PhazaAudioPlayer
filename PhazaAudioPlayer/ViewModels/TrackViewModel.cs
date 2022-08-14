using System;
using System.Windows;
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

    private readonly ResourceDictionary _resources = new();

    public TrackViewModel()
    {
        _resources.Source = new Uri("pack://application:,,,/Resources/Images.xaml");

        var imageUriObservable= this.WhenAnyValue(x => x.ImageUri)
            .Subscribe(uri =>
            {
                try
                {
                    Image = new BitmapImage(uri);
                }
                catch
                {
                    Image = (DrawingImage) _resources["TrackImage"];
                }
            });
    }
}