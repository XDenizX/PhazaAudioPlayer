using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using DynamicData;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace YandexMusicApp.ViewModels;

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
    }
}