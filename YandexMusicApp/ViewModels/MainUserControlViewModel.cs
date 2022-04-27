using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using DynamicData;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace YandexMusicApp.ViewModels;

public class MainUserControlViewModel : ReactiveObject
{
    // TODO: Replace in single class.
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
    
    [Reactive] public ObservableCollection<PlaylistViewModel> Playlists { get; set; }

    public MainUserControlViewModel()
    {
        Playlists = new ObservableCollection<PlaylistViewModel>();
        LoadPlaylists();
    }

    private void LoadPlaylists()
    {
        string[] files = Directory.GetFiles(@"C:\Users\deniz\Desktop\AlbumImages");
        
        Playlists.AddRange(files.Select(filepath => new PlaylistViewModel
        {
            ImageUrl = filepath,
            Name = Path.GetFileNameWithoutExtension(filepath),
            Artist = "Tventin Carantino"
        }));
    }
}