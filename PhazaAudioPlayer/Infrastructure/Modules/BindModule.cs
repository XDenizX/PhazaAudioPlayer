using Ninject.Modules;
using PhazaAudioPlayer.Core.Players;
using PhazaAudioPlayer.Services;

namespace PhazaAudioPlayer.Infrastructure.Modules
{
    public class BindModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAudioPlayer>().To<NAudioPlayer>().InTransientScope();
            Bind<PlaybackService>().ToSelf().InSingletonScope();
        }
    }
}
