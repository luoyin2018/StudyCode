using System;
using System.ServiceModel;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //Step 3: 通过代理调用服务,因为ClientBase<T>实现了IDisposable接口，所以放在using语句块中
            using(HelloWorldProxy proxy = new HelloWorldProxy())
            {
                //20180202添加：获得通信相关的状态机对象，并添加处理事件
                ICommunicationObject communicationObject = (ICommunicationObject)proxy;

                communicationObject.Opened += (sender,e)=>Console.WriteLine("状态机开启！");
                communicationObject.Closed += (sender,e)=>Console.WriteLine("状态机关闭！");

                Console.WriteLine(proxy.HelloWorld("WCF"));
            }

            Console.WriteLine("press any key to exit...");
            Console.Read();
        }

    }
}
