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
using System.Reflection;
using System.IO;

namespace UseResources
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //方式一: 嵌入文本资源的读取 
            //   有两点需要注意:
            //      1)文件的生成操作选：嵌入的资源
            //      2)资源文件的索引路径,即GetManifestResourceStream的参数
            //
            // !!本方式不依赖WPF相关的库
            Assembly asm = Assembly.GetExecutingAssembly();
            Stream stream = asm.GetManifestResourceStream("UseResources.嵌入的资源.embeddatafile.dat");
            StreamReader sr = new StreamReader(stream);

            Console.WriteLine(sr.ReadToEnd());
            sr.Close();
        }
    }
}
