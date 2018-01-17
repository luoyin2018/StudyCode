using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Globalization;
using Prism.Mvvm;


namespace PrismStudy
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //HACK  改写Prism默认的ViewModelLocator定位View相关的ViewModel行为.使得View和ViewModel可以放在同一个文件夹下（实际是需要在同一个命名空间中)
            //参考：http://brianlagunas.com/getting-started-prisms-new-viewmodellocator/
            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(viewType =>
               {
                   var viewName = viewType.FullName;
                   var viewAssemblyName = viewType.Assembly.FullName;
                   var viewModelName = String.Format(CultureInfo.InvariantCulture, "{0}ViewModel,{1}", viewName, viewAssemblyName);
                   return Type.GetType(viewModelName);
               }
            );

            //Step 2:去除App.xaml中的启动窗口，在App的Startup事件中添加Bootstrapper类实例的生成，并调用其Run方法
            var bootstrapper = new Bootstrapper();
            bootstrapper.Run();
        }
    }
}
