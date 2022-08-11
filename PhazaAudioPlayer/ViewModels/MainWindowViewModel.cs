using System;
using System.Reactive.Linq;
using System.Windows.Controls;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using static PhazaAudioPlayer.ViewModels.SideMenuViewModel;

namespace PhazaAudioPlayer.ViewModels;

public class MainWindowViewModel : ReactiveObject
{
    [Reactive] public UserControl Content { get; set; }

    private readonly SideMenuViewModel _sideMenuViewModel = Kernel.Get<SideMenuViewModel>();

    public MainWindowViewModel()
    {
        var switchObserver = Observable
            .FromEvent<ContentSwitchedHandler, UserControl>(
            addHandler => _sideMenuViewModel.ContentSwitched += addHandler,
            removeHandler => _sideMenuViewModel.ContentSwitched -= removeHandler);

        switchObserver.Subscribe(content => Content = content);
    }
}