using Ninject.Modules;
using PhazaAudioPlayer.ViewModels;

namespace PhazaAudioPlayer.Infrastructure.Modules;

internal class ViewModelsBindModule : NinjectModule
{
    public override void Load()
    {
        Bind<SideMenuViewModel>().ToSelf().InSingletonScope();
        Bind<PlayerPanelViewModel>().ToSelf().InSingletonScope();
    }
}
