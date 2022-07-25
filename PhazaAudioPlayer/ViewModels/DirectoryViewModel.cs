using ReactiveUI.Fody.Helpers;

namespace PhazaAudioPlayer.ViewModels;

public class DirectoryViewModel
{
    [Reactive] public string Path { get; set; }
    [Reactive] public string Name { get; set; }
}