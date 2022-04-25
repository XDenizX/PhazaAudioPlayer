using System;
using System.Windows.Controls;
using System.Windows.Input;
using HandyControl.Tools.Command;
using ReactiveUI;
using YandexMusicApp.Infrastructure.Interfaces;
using YandexMusicApp.Infrastructure.Providers;
using YandexMusicApp.Views.UserControls;

namespace YandexMusicApp.ViewModels;

public class MainWindowViewModel : ReactiveObject
{
    private UserControl _content;
    public UserControl Content
    {
        get => _content;
        set => this.RaiseAndSetIfChanged(ref _content, value);
    }

    private ICommand _switchMenuItemCommandCommand;
    public ICommand SwitchMenuItemCommand
    {
        get => _switchMenuItemCommandCommand;
        set => this.RaiseAndSetIfChanged(ref _switchMenuItemCommandCommand, value);
    }

    private readonly IProviderOf<UserControl> _contentProvider;
    
    public MainWindowViewModel()
    {
        _contentProvider = new ContentProvider();
        
        _content = _contentProvider.Get<MainUserControl>();
        _switchMenuItemCommandCommand = new RelayCommand(SwitchMenuItem);
    }

    private void SwitchMenuItem(object args)
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