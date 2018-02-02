using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;            //ServiceHost类 NetNamedPipeBinding类属于该名称空间
using System.ServiceModel.Channels;   //Binding类属于该名称空间
using HelloWorldService;
//Step 1: 添加System.ServiceModel引用(这里用的是Console项目）,并引入名称空间
//        添加服务契约程序集的引用

namespace MyServiceHost
{
    /// <summary>
    /// 封装ServiceHost及其构造过程, 注释中相关名词解释见ReadMe.txt文件
    /// </summary>
    class MyServiceHost : IDisposable
    {
        private ServiceHost myHost;

        //可以在配置文件中配置ServiceHost类所需要的参数
        public const string BaseAddress              = "net.pipe://localhost";     // 基地址
        public const string HelloWorldServiceAddress = "HelloWorld";              // 可选地址 

        public static readonly Type ContractType = typeof(IService);              // 服务契约的定义类型
        public static readonly Type ServiceType  = typeof(Service);               // 服务契约的实现类型

        public static readonly Binding HelloWorldBinding = new NetNamedPipeBinding();  // 绑定方式之一

        public MyServiceHost()
        {
            //Step 2: 初始化ServiceHost对象 
            myHost = new ServiceHost(ServiceType, new Uri[] {new Uri(BaseAddress)});

            //Step 3: 添加一个终结点
            myHost.AddServiceEndpoint(ContractType, HelloWorldBinding, HelloWorldServiceAddress);
        }

        //Step 4: 调用ServiceHost实例的Open方法
        public void Open()
        {
            Console.WriteLine("服务启动中...");
            myHost.Open();
            Console.WriteLine("已启动");
        }

        //Step 5: 调用ServiceHost实例的Dispose方法
        public void Dispose()
        {
            if(myHost != null)
            {
                (myHost as IDisposable).Dispose();    // ServiceHost显式实现了IDisposable接口，所以调用其Dispose方法前要先转换
            }
        }
    }
}
