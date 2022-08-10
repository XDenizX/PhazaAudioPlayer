using PhazaAudioPlayer.ViewModels;
using ReactiveUI;
using System.Windows.Controls;
using System.Windows.Input;

namespace PhazaAudioPlayer.Views.Contents;

public partial class UserFilesContent : UserControl, IViewFor<FilesUserControlViewModel>
{
    #region ViewModel
    public FilesUserControlViewModel? ViewModel
    { 
        get => DataContext as FilesUserControlViewModel;
        set => DataContext = value;
    }

    object? IViewFor.ViewModel 
    { 
        get => ViewModel;
        set => ViewModel = (FilesUserControlViewModel) value;
    }
    #endregion

    public UserFilesContent()
    {
        InitializeComponent();
    }

    public void RemoveTrack(object target, ExecutedRoutedEventArgs e)
    {
        if (e.Parameter is not TrackViewModel track)
        {
            return;
        }

        ViewModel?.UserTracks.Remove(track);
    }

    private void PlayTrack(object sender, ExecutedRoutedEventArgs e)
    {
        ViewModel?.PlayTrackCommand.Execute(e.Parameter);
    }
}