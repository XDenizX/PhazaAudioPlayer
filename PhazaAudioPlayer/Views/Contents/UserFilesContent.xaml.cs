using PhazaAudioPlayer.ViewModels;
using ReactiveUI;
using System.Windows.Controls;
using System.Windows.Input;

namespace PhazaAudioPlayer.Views.Contents;

public partial class UserFilesContent : UserControl, IViewFor<UserFilesContentViewModel>
{
    #region ViewModel
    public UserFilesContentViewModel? ViewModel
    { 
        get => DataContext as UserFilesContentViewModel;
        set => DataContext = value;
    }

    object? IViewFor.ViewModel 
    { 
        get => ViewModel;
        set => ViewModel = (UserFilesContentViewModel) value;
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