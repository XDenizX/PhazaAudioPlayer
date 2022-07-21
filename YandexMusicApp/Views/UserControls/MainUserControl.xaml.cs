using System.Windows.Controls;
using System.Windows.Input;

namespace YandexMusicApp.Views.UserControls;

public partial class MainUserControl : UserControl
{
    public MainUserControl()
    {
        InitializeComponent();

        CoverView.PreviewMouseWheel += CoverView_PreviewMouseWheel;
    }

    private void CoverView_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
    {
        ScrollViewer.ScrollToVerticalOffsetWithAnimation(ScrollViewer.VerticalOffset - e.Delta * 1.5f, 300);
    }
}