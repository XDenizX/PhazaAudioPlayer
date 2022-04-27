using System;
using System.Collections.Generic;
using YandexMusicApp.Infrastructure.Interfaces;

namespace YandexMusicApp.Infrastructure.Providers;

public abstract class BaseProvider<T> : IProviderOf<T>
{
    protected readonly Dictionary<Type, T> _storage = new();
    
    public virtual void Register(T objectToRegister)
    {
        if (objectToRegister == null)
        {
            throw new ArgumentNullException(nameof(objectToRegister));
        }

        bool wasAdded = _storage.TryAdd(objectToRegister.GetType(), objectToRegister);
        
        if (!wasAdded)
        {
            throw new InvalidOperationException($"\"{objectToRegister.GetType().Name}\" already exists.");
        }
    }

    public virtual void Unregister(T objectToUnregister)
    {
        if (objectToUnregister == null)
        {
            throw new ArgumentNullException(nameof(objectToUnregister));
        }

        _storage.Remove(objectToUnregister.GetType());
    }

    public virtual T Get(Type objectType)
    {
        return _storage[objectType];
    }

    public virtual TObject Get<TObject>() where TObject : T
    {
        return (TObject) Get(typeof(TObject));
    }
}