using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace UDPSender
{
    class Program
    {
        //这里服务端用于持续向某一端口发送数据
        static void Main(string[] args)
        {
            string localhost = "127.0.0.1";

            //发送目标地址
            int port =55000;
            IPAddress Ip = IPAddress.Parse(localhost);
            IPEndPoint ipTarget = new IPEndPoint(Ip, port);

            //本地使用端口
            IPAddress IpNow = IPAddress.Parse(localhost);
            IPEndPoint ipSelf = new IPEndPoint(IpNow,65000);

            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);     

            s.Bind(ipSelf);     //这一步并不是必须的,系统会随机分配一个端口

            s.Connect(ipTarget);

            Console.WriteLine("Sender Start:");
            Console.WriteLine("[Use \"quit\" to exit!  Use \"stop\" to close the recevier ]");
            Console.WriteLine("-----------------------------------");

            while(true)
            {
                string userinput = Console.ReadLine();

                if(userinput=="quit")
                {
                    break;
                }
                else
                {
                    s.Send(Encoding.Default.GetBytes(userinput));
                }
            }
            s.Close();
        }
    }
}
