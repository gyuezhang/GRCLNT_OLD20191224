using System.Windows.Controls;

namespace GRCLNT
{
    /// <summary>
    /// PageWell_AddAuto_View.xaml 的交互逻辑
    /// </summary>
    public partial class PageWell_AddAuto_View : UserControl
    {
        public PageWell_AddAuto_View()
        {
            InitializeComponent();
        }


        private void sv_PreviewMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }

        private void lv_SizeChanged(object sender, System.Windows.SizeChangedEventArgs e)
        {
            double d = lv.ActualHeight;
            sv.ScrollToVerticalOffset(d);

        }
    }
}
