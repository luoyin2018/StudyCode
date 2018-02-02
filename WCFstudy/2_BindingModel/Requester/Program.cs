using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;

// 添加System.ServiceModel和System.Runtime.Serialization程序集的引用
namespace Requester
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //建立自定义的通道栈
                BindingElement[] bindingElements = new BindingElement[2];
                bindingElements[0] = new TextMessageEncodingBindingElement();  //文本编码
                bindingElements[1] = new HttpTransportBindingElement();        //HTTP传输
                CustomBinding binding = new CustomBinding(bindingElements);

                using(Message message = Message.CreateMessage(binding.MessageVersion, "SendMessage","Message Body"))
                {
                    //创建ChannelFactory并打开
                    IChannelFactory<IRequestChannel> factory = binding.BuildChannelFactory<IRequestChannel>(new BindingParameterCollection());
                    factory.Open();

                    //创建IRequestChannel并打开
                    IRequestChannel requestChannel = factory.CreateChannel(new EndpointAddress("http://localhost:9090/RequestReplyService"));
                    requestChannel.Open();

                    Message response = requestChannel.Request(message); //发送消息,  会阻塞线程等待服务端返回消息

                    Console.WriteLine("成功发送信息");

                    //查看返回消息
                    Console.WriteLine("接收到一条返回消息,action为：{0}, body为:{1}", response.Headers.Action, response.GetBody<string>());

                    requestChannel.Close();   //关闭通道 
                    factory.Close();          //关闭工厂
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());   
            }
            finally
            {
                Console.WriteLine("press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
