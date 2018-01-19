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
            Console.WriteLine("[EmbededResourceFile]");
            ReadEmbededResourceFile();

            Console.WriteLine("[ResourceFile]");
            ReadResourceFile();
        }

        private void ReadEmbededResourceFile()
        {
            //方式一: 生成操作为：嵌入的资源  的文件读取
            //   需要注意: 资源文件的索引路径,即GetManifestResourceStream的参数
            // !!本方式不依赖WPF相关的库
            Assembly asm = Assembly.GetExecutingAssembly();
            Stream stream = asm.GetManifestResourceStream("UseResources.嵌入的资源.embeddatafile.dat");
            StreamReader sr = new StreamReader(stream);

            Console.WriteLine(sr.ReadToEnd());
            sr.Close();
        }

        private void ReadResourceFile()
        {
            //方式二：生成操作为：Resource 的文件读取
            //    注意Uri的索引方式,与方式一是不同的

            System.Windows.Resources.StreamResourceInfo sri = Application.GetResourceStream(
                new Uri("资源/datafile.dat",UriKind.Relative));

            //Console.WriteLine(sri.ContentType);   //只有bmp格式会返回image/bmp吗?
            StreamReader sr = new StreamReader(sri.Stream);
            Console.WriteLine(sr.ReadToEnd());
            sr.Close();

            ////第二种方法 未调通
            //Assembly asm = Assembly.GetExecutingAssembly();   
            //string resourcename = asm.GetName().Name + ".g";   //指定资源名称 ???有问题

            //System.Resources.ResourceManager rm = new System.Resources.ResourceManager(resourcename,asm);
            //using (System.Resources.ResourceSet set = rm.GetResourceSet(System.Globalization.CultureInfo.CurrentCulture, true, true))
            //{
            //    UnmanagedMemoryStream ums = set.GetObject("datafile.dat", true) as UnmanagedMemoryStream;
            //    sr = new StreamReader(ums);
            //    Console.WriteLine(sr.ReadToEnd());
            //    sr.Close();
            //}
        }
    }

}
