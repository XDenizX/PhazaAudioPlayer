using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using DynamicData;
using HandyControl.Controls;
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
        try
        {
            string[] files = Directory.GetFiles(@"C:\Users\deniz\Desktop\AlbumImages");

            Playlists.AddRange(files.Select(filepath => new PlaylistViewModel
            {
                ImageUrl = filepath,
                Name = Path.GetFileNameWithoutExtension(filepath),
                Artist = "Tventin Carantino"
            }));
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
        }
    }
}