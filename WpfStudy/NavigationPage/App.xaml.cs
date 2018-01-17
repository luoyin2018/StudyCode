using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace NavigationPage
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private void App_NavigationFailed(object sender, System.Windows.Navigation.NavigationFailedEventArgs e)
        {
            if(e.Exception is System.Net.WebException)
            {
                MessageBox.Show("站点" + e.Uri.ToString() + "不可达");
                e.Handled = true;    //抑制错误，否则应用程序会中止
            }
        }
    }
}
