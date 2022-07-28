using PhazaAudioPlayer.ViewModels;
using ReactiveUI;

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
}