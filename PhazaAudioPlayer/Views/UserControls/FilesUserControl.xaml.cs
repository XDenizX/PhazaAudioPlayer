using PhazaAudioPlayer.ViewModels;
using ReactiveUI;
using System.Windows.Controls;
using System.Windows.Input;

namespace PhazaAudioPlayer.Views.UserControls;

public partial class FilesUserControl : UserControl, IViewFor<FilesUserControlViewModel>
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

    public FilesUserControl()
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
}