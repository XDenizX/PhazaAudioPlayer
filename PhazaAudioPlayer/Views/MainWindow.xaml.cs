using PhazaAudioPlayer.Core.PlayerControllers;
using PhazaAudioPlayer.Core.Players;
using PhazaAudioPlayer.Core.PlaylistProviders;
using PhazaAudioPlayer.Core.StreamProviders;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;

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