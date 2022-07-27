using ReactiveUI.Fody.Helpers;

namespace PhazaAudioPlayer.ViewModels;

public class TrackViewModel
{
    [Reactive] public string Path { get; set; }
    [Reactive] public string Name { get; set; }
}