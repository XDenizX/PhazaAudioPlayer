using HandyControl.Tools.Command;
using PhazaAudioPlayer.Infrastructure.Interfaces;
using PhazaAudioPlayer.Infrastructure.Providers;
using PhazaAudioPlayer.Views.UserControls;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace PhazaAudioPlayer.ViewModels;

public class MainWindowViewModel : ReactiveObject
{
    [Reactive] public UserControl Content { get; set; }
    [Reactive] public ICommand SwitchContentCommand { get; set; }

    private readonly IProviderOf<UserControl> _contentProvider;

    public MainWindowViewModel()
    {
        _contentProvider = new ContentProvider();

        Content = _contentProvider.Get<MainUserControl>();
        SwitchContentCommand = new RelayCommand(SwitchContent);
    }

    private void SwitchContent(object args)
    {
        if (args is not Type contentType)
        {
            return;
        }

        if (contentType.IsAssignableTo(typeof(UserControl)))
        {
            Content = _contentProvider.Get(contentType);
        }
    }
}