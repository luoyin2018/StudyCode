using System;
using System.Windows;

namespace UseInteractiveDataDisplay
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rd = new Random();
        double[] x = {0,1,2,3,4,5,6,7,8,9};
        double[] NormY = new double[10];
        double[] y = new double[10];
        int index = 1;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double countEachTime = 50;
            for(int ii= 0;ii<countEachTime;ii++)
            {
                double rdValue = rd.NextDouble();
                int zone = (int)(rdValue*10.0);
                if(zone==10) zone--;
                y[zone] += 1.0;                 //y中存储落入每个区间的随机数个数
            }

            for(int ii=0; ii<y.Length; ii++)
            {
                NormY[ii] = y[ii] / (index *countEachTime);   // 将y中计数归一化
                
            }
            index++;

            //TODO: 这里应该使用绑定，让图形自动更新
            barChart.PlotBars(x,NormY);

        }
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
