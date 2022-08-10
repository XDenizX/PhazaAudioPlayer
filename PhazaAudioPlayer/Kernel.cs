using Ninject;
using PhazaAudioPlayer.Infrastructure.Modules;

namespace PhazaAudioPlayer
{
    public static class Kernel
    {
        private static IKernel _kernel;

        public static T Get<T>()
        {
            if (_kernel == null)
            {
                _kernel = new StandardKernel(new BindModule());
            }

            return _kernel.Get<T>();
        }
    }
}
