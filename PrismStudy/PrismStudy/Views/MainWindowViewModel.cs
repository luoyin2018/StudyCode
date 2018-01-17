using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace PrismStudy.Views
{
    class MainWindowViewModel:BindableBase
    {
        string _title = "Hello Prism";
        public string Title
        {
            get { return _title;}
            set { SetProperty(ref _title,value);}
        }
    }
}
