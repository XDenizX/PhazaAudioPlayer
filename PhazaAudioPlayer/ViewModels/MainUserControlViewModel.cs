using System.Collections.ObjectModel;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

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
    }
}