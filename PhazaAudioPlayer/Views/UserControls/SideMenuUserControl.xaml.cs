using PhazaAudioPlayer.ViewModels;
using System.Windows.Controls;

namespace PhazaAudioPlayer.Views.UserControls
{
    /// <summary>
    /// Логика взаимодействия для SideMenuUserControl.xaml
    /// </summary>
    public partial class SideMenuUserControl : UserControl
    {
        public SideMenuUserControl()
        {
            InitializeComponent();

            DataContext = Kernel.Get<SideMenuViewModel>();
        }
    }
}
