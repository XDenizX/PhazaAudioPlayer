using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using HandyControl.Tools.Extension;

namespace YandexMusicApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadCoverFlow();
        }

        private void LoadCoverFlow()
        {
            
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Click");
        }
    }
}