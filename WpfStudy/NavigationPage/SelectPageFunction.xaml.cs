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
    // PageFunction使用过程：
    // step1: 新建一个PageFunction页面，并根据返回值类型设置TargetArgument属性
    // step2: 调用OnReturn方法来返回对象
    // step3: 在主页面中编码创建PageFunction页面实例，并添加对PageFunction的return事件的侦听
    // step4: 在响应事件代码中获取PageFunction的返回值

    /// <summary>
    /// SelectPageFunction.xaml 的交互逻辑
    /// </summary>
    public partial class SelectPageFunction : PageFunction<String>
    {
        public SelectPageFunction()
        {
            InitializeComponent();
        }

        private void btnOk_click(object sender, RoutedEventArgs e)
        {
            ListBoxItem lbt = listbox.SelectedItem as ListBoxItem;
            if(lbt!=null)
            { 
                string content = lbt.Content.ToString();
                OnReturn(new ReturnEventArgs<string>(content));
            }
            else
            {
                OnReturn(null);
            }
        }

        private void btnCancel_click(object sender, RoutedEventArgs e)
        {
            OnReturn(null);
        }
    }
}
