using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
// 首先添加System.ServiceModel和System.Runtime.Serialization程序集的引用
namespace Responser
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //建立和发送端相同的通道栈
                BindingElement[] bindingElements = new BindingElement[2];
                bindingElements[0] = new TextMessageEncodingBindingElement();
                bindingElements[1] = new HttpTransportBindingElement();
                CustomBinding binding = new CustomBinding(bindingElements);

                //建立ChannelListener
                IChannelListener<IReplyChannel> listener = binding.BuildChannelListener<IReplyChannel>(
                                                                new Uri("http://localhost:9090/RequestReplyService"),
                                                                new BindingParameterCollection());
                listener.Open();       //打开监听

                //创建IReplyChannel
                IReplyChannel replyChannel = listener.AcceptChannel();
                replyChannel.Open();   //打开通道

                Console.WriteLine("开始接收消息");

                //接收并打印消息
                RequestContext requestContext = replyChannel.ReceiveRequest();     //会堵塞在这里

                Console.WriteLine("接收到一条消息, action为{0}, body为{1}",
                                                requestContext.RequestMessage.Headers.Action,
                                                requestContext.RequestMessage.GetBody<string>());

                //创建返回消息
                Message response = Message.CreateMessage(binding.MessageVersion, "response", "response body");

                //发送返回消息
                requestContext.Reply(response);

                requestContext.Close();
                replyChannel.Close();
                listener.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
