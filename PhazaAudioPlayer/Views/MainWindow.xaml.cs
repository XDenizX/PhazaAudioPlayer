using PhazaAudioPlayer.Core.PlayerControllers;
using PhazaAudioPlayer.Core.Players;
using PhazaAudioPlayer.Core.PlaylistProviders;
using PhazaAudioPlayer.Core.StreamProviders;
using PhazaAudioPlayer.ViewModels;
using ReactiveUI;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;

namespace PhazaAudioPlayer.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : IViewFor<MainWindowViewModel>
    {
        #region ViewModel
        public MainWindowViewModel? ViewModel 
        { 
            get => DataContext as MainWindowViewModel;
            set => DataContext = value;
        }

        object? IViewFor.ViewModel 
        {
            get => ViewModel;
            set => ViewModel = (MainWindowViewModel) value; 
        }
        #endregion

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {

        }
    }
}