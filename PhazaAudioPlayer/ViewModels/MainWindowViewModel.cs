using System;
using System.Reactive.Linq;
using System.Windows.Controls;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using ReactiveMarbles.ObservableEvents;
using static PhazaAudioPlayer.ViewModels.SideMenuViewModel;

namespace PhazaAudioPlayer.ViewModels;

public class MainWindowViewModel : ReactiveObject
{
    [Reactive] public UserControl Content { get; set; }

    private readonly SideMenuViewModel _sideMenuViewModel = Kernel.Get<SideMenuViewModel>();

    public MainWindowViewModel()
    {
        Content = _sideMenuViewModel.DefaultContent;

        var switchObservable = _sideMenuViewModel.Events().ContentSwitched;

        switchObservable.Subscribe(content => Content = content);
    }
}