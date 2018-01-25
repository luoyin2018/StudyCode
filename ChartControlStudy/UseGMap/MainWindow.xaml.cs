using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GMap.NET; 
using GMap.NET.MapProviders;

namespace UseGMap
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Map.CacheLocation = Environment.CurrentDirectory;
            this.Map.MapProvider   = BaiduMapProvider.Instance;
            this.Map.Manager.Mode  = AccessMode.ServerAndCache;
            this.Map.MinZoom       = 1;
            this.Map.MaxZoom       = 23;
            this.Map.Zoom          = 15;
            this.Map.ShowCenter    = false;
            this.Map.Position      = new PointLatLng(21,67.88);
        }
    }
}
