using DynamicData;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace PhazaAudioPlayer.ViewModels;

public class MainUserControlViewModel : ReactiveObject
{
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