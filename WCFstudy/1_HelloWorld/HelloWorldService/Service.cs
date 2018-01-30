using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldService
{
    //Step 4: 实现服务契约(WCF中实现服务契约和类实现接口的概念是对应的
    public class Service : IService
    {
        public string HelloWorld(string name)
        {
            return name + " 说： Hello World!";
        }
    }

    //Step 5:编译就得到了HelloWorld的服务契约程序集，该服务需要寄宿到某个特定的程序之中才可以访问
}
