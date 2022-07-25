using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using YandexMusicApp.AudioPlayer.PlayerControllers;
using YandexMusicApp.AudioPlayer.Players;
using YandexMusicApp.AudioPlayer.PlaylistProviders;
using YandexMusicApp.AudioPlayer.StreamProviders;

namespace PhazaAudioPlayer.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Click");

            StreamFactory streamFactory = new StreamFactory();
            streamFactory.RegisterProviders(new List<IStreamProvider>
        {
            new MemoryStreamProvider(),
            new LocalStorageStreamProvider(),
            new HttpStreamProvider(),
        });

            NAudioPlayer nAudioPlayer = new NAudioPlayer();
            PlayerController player = new PlayerController(nAudioPlayer, streamFactory);

            TestPlaylistProvider playlistProvider = new TestPlaylistProvider();

            player.Playlist = playlistProvider.GetPlaylist("_");
            player.StartPlayback();
        }
    }
}