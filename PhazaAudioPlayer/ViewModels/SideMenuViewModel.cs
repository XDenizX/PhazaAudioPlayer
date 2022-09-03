using PhazaAudioPlayer.Infrastructure.Interfaces;
using PhazaAudioPlayer.Infrastructure.Providers;
using PhazaAudioPlayer.Views.Contents;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Reactive;
using System.Windows.Controls;

namespace PhazaAudioPlayer.ViewModels;

public class SideMenuViewModel : ReactiveObject
{
    [Reactive] public ReactiveCommand<Type, Unit> SwitchContentCommand { get; set; }

    private readonly IProviderOf<UserControl> _contentProvider = new ContentProvider();

    public UserControl DefaultContent => _contentProvider.Get<MainContent>();

    public UserControl CurrentContent { get; private set; }

    public delegate void ContentSwitchedHandler(UserControl content);
    public event ContentSwitchedHandler ContentSwitched;

    public SideMenuViewModel()
    {
        SwitchContentCommand = ReactiveCommand.Create<Type>(SwitchContent);
    }

    private void SwitchContent(Type contentType)
    {
        if (!contentType.IsAssignableTo(typeof(UserControl)))
        {
            return;
        }

        CurrentContent = _contentProvider.Get(contentType);
        ContentSwitched?.Invoke(CurrentContent);
    }
}
