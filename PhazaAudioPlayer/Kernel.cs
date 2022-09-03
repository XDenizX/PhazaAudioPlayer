using Ninject;
using PhazaAudioPlayer.Infrastructure.Modules;

namespace PhazaAudioPlayer;

public static class Kernel
{
    private static IKernel _kernel;

    public static T Get<T>()
    {
        _kernel ??= new StandardKernel(new ViewModelsBindModule());

        return _kernel.Get<T>();
    }
}
