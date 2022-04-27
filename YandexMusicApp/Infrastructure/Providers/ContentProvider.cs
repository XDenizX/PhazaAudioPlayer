using System;
using System.Windows.Controls;

namespace YandexMusicApp.Infrastructure.Providers;

public class ContentProvider : BaseProvider<UserControl>
{
    public override UserControl Get(Type objectType)
    {
        if (!_storage.ContainsKey(objectType))
        {
            var instance = objectType
                .GetConstructor(Array.Empty<Type>())?
                .Invoke(null) as UserControl;
            
            Register(instance);
        }
        
        return base.Get(objectType);
    }
}