using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace UDPReceiver
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] data= new byte[256];   //缓存区

            int port =55000;
            string localhost = "127.0.0.1";
            IPAddress Ip = IPAddress.Parse(localhost);
            IPEndPoint ipListening = new IPEndPoint(Ip, port);

            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            //TODO: 用来保存发送端信息？？？怎么用?
            IPEndPoint sender = new IPEndPoint(IPAddress.Any,0);
            EndPoint senderRemote = (EndPoint)sender;
            
            s.Bind(ipListening);       //监听的端口

            Console.WriteLine("Receiver Start:");
            Console.WriteLine("----------------------------");
            while(true)
            {
                int count = s.ReceiveFrom(data,ref senderRemote); 
                string msg = Encoding.Default.GetString(data,0,count);

                Console.WriteLine(string.Format("[Message Received]: {0}",msg));
                if(msg == "stop")
                {
                    break;
                }
            }

            s.Close();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
