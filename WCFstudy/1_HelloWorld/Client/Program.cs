using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //Step 3: 通过代理调用服务,因为ClientBase<T>实现了IDisposable接口，所以放在using语句块中
            using(HelloWorldProxy proxy = new HelloWorldProxy())
            {
                Console.WriteLine(proxy.HelloWorld("WCF"));
                Console.WriteLine("press any key to exit...");
                Console.Read();
            }
        }
    }
}
