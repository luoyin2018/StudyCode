using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Client
{
    //Step 1: 服务元数据的导入
    //（包括：服务提供的终结点，每个终结点的地址、绑定和契约)
    //通常是用元数据获取来得到服务的元数据，一般两种方法：HTTP-GET方法和元数据终结点法

    // 硬编码服务契约  !!!!!实际中不这么用
    [ServiceContract]
    interface IService
    {
        [OperationContract]
        string HelloWorld(string name);
    }

    //Step 2: 定义访问服务的代理类型,这里用HelloWorldProxy封装了ClientBase<T>的构造过程
    class HelloWorldProxy : ClientBase<IService>, IService
    {
        // 硬编码定义绑定 !!!!实际中不这么用
        public static readonly Binding HelloWorldBinding = new NetNamedPipeBinding();

        // 硬编码定义地址 !!!!实际中不这么用
        public static readonly EndpointAddress HelloWorldAddress = new EndpointAddress(new Uri("net.pipe://localhost/HelloWorld"));

        public HelloWorldProxy():base(HelloWorldBinding,HelloWorldAddress) { }

        public string HelloWorld(string name)
        {
            return Channel.HelloWorld(name);   // Channel是通道，通道可视为一组协议栈
        }
    }
}
