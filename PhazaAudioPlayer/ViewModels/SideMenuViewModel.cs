using PhazaAudioPlayer.Infrastructure.Interfaces;
using PhazaAudioPlayer.Infrastructure.Providers;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Reactive;
using System.Windows.Controls;

namespace PhazaAudioPlayer.ViewModels
{
    public class SideMenuViewModel : ReactiveObject
    {
        [Reactive] public ReactiveCommand<object, Unit> SwitchContentCommand { get; set; }

        private readonly IProviderOf<UserControl> _contentProvider = new ContentProvider();

        public UserControl CurrentContent { get; private set; }

        public delegate void ContentSwitchedHandler(UserControl content);
        public event ContentSwitchedHandler ContentSwitched; 

        public SideMenuViewModel()
        {
            SwitchContentCommand = ReactiveCommand
                .Create<object>(content => SwitchContent(content));
        }

        private void SwitchContent(object args)
        {
            if (args is not Type contentType)
            {
                return;
            }

            if (contentType.IsAssignableTo(typeof(UserControl)))
            {
                CurrentContent = _contentProvider.Get(contentType);
                ContentSwitched?.Invoke(CurrentContent);
            }
        }
    }
}
