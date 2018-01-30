using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            //Step 6: 启动宿主
            using(MyServiceHost host = new MyServiceHost())
            {
                host.Open();                                        // 注意：这里Open是不堵塞的
                Console.WriteLine("Press any key to exit...");
                Console.Read();
            }
        }
    }
}
