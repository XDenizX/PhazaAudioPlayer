using System;
using System.Windows.Controls;
using System.Windows.Input;
using HandyControl.Tools.Command;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using YandexMusicApp.Infrastructure.Interfaces;
using YandexMusicApp.Infrastructure.Providers;
using YandexMusicApp.Views.UserControls;

namespace YandexMusicApp.ViewModels;

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