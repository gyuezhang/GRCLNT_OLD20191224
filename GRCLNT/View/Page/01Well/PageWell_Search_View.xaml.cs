using System.Windows.Controls;
using BruTile.Predefined;
using Mapsui.Layers;

namespace GRCLNT
{
    /// <summary>
    /// PageWell_Search_View.xaml 的交互逻辑
    /// </summary>
    public partial class PageWell_Search_View : UserControl
    {
        public PageWell_Search_View()
        {
            InitializeComponent();
            MyMapControl.Map.Layers.Add(new TileLayer(KnownTileSources.Create()));
        }
    }
}
