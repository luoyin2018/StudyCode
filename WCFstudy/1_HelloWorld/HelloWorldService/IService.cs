using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
//Step 1 : 引入System.ServiceModel名称空间(如果是Class Library项目类型，需要添加System.ServiceModel引用)
namespace HelloWorldService
{

    //Step 2: 使用ServiceContract特性来定义服务契约
    [ServiceContract]
    interface IService
    {
        //Step3: 使用OperationContract特性来定义服务操作(一个服务契约由一组服务操作构成）
        [OperationContract]
        string HelloWorld(string name);  // 服务操作
    }
}
