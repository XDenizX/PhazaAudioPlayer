using System;

namespace YandexMusicApp.Infrastructure.Interfaces;

public interface IProviderOf<T>
{
    void Register(T objectToRegister);
    void Unregister(T objectToUnregister);

    T Get(Type objectType);
    TObject Get<TObject>() where TObject : T;
}