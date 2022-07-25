using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Reactive.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PhazaAudioPlayer.ViewModels;

public class PlaylistViewModel : ReactiveObject
{
    [Reactive] public string ImageUrl { get; init; }
    [Reactive] public string Name { get; init; }
    [Reactive] public string Artist { get; set; }

    public extern ImageSource ImageSource { [ObservableAsProperty] get; }

    public PlaylistViewModel()
    {
        ImageUrl = string.Empty;

        this.WhenAnyValue(x => x.ImageUrl)
            .Where(x => !string.IsNullOrEmpty(x))
            .Select(GetImageSource)
            .ToPropertyEx(this, x => x.ImageSource);
    }

    private ImageSource GetImageSource(string url)
    {
        return new BitmapImage(new Uri(url, UriKind.Absolute));
    }
}