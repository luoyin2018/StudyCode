using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    delegate void PrintHelloWorld();
    class Program
    {
        static void Main(string[] args)
        {
            //静态方法,注意委托没有空构造方法
            //PrintHelloWorld Hello1 = new PrintHelloWorld();       //不对
            //PrintHelloWorld Hello1 = new PrintHelloWorld(null);   //不对
            PrintHelloWorld Hello1 = new PrintHelloWorld(SayHello);

            Program pg = new Program();
            pg.Name = "Instance Method";
            //实例方法
            PrintHelloWorld Hello2 = new PrintHelloWorld(pg.InstanceSayHello);
            
            //委托组合1
            PrintHelloWorld Hello3 = Hello1 + Hello2;

            //委托组合2: 使用+= -=
            Hello1+=Hello2;
            Hello1-=Hello2;
            
            //委托组合3: 直接加方法签名   //!!!!!!!!!!!!!!!!
            Hello1+=SayHello;

            //自定义事件的使用
            TestEvent Test = new TestEvent();
            Test.SelfDefineEvent +=pg.TestEventSelfEventRaised;
            Test.RaiseEvent();

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static void SayHello()
        {
            Console.WriteLine("Static Method: Hello World");
        }
        
         string Name {get;set; }
         void InstanceSayHello()
        {
            Console.WriteLine("{0}: Hello World",Name);
        }
        
        void TestEventSelfEventRaised(string name)
        {
            Console.WriteLine("TestEvent Raised:{0}",name);
        }

    }
}
