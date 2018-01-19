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

namespace NavigationPage
{
    /// <summary>
    /// MainPage.xaml 的交互逻辑
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Hyperlink_click(object sender, RoutedEventArgs e)
        {
            PageFunction<string> pf = new SelectPageFunction();
            pf.Return += Pf_Return;
            NavigationService.Navigate(pf);
        }

        private void Pf_Return(object sender, ReturnEventArgs<string> e)
        {
            if(e == null) return;
            this.SelectedContent.Text = e.Result;
        }
    }
}
