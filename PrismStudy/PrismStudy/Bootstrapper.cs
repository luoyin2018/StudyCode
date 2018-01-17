using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Unity;
using Prism.Modularity;
using Microsoft.Practices.Unity;
using PrismStudy.Views;

namespace PrismStudy
{
    //Step 1:Nuget下载包Prism.WPF和Prism.Unity.Wpf,实现自己的Bootstrpper
    class Bootstrapper:UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }
        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
           
        }
    }
}
