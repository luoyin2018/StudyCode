using System;
using System.Threading;

namespace AsyncDelegateExample
{
    delegate int SampleDelegate(string data);

    /// <summary>
    /// 未使用回调函数的异步委托调用
    /// </summary>
    class Program1
    {
        static void Main(string[] args)
        {
            SampleDelegate counter = new SampleDelegate(CountCharacters);
            SampleDelegate parser  = new SampleDelegate(Parser);

            IAsyncResult couterResult = counter.BeginInvoke("hello",null,null);          //这里不会堵塞
            IAsyncResult parserResult = parser.BeginInvoke("10",null,null);              //这里不会堵塞

            Console.WriteLine("Main thread continuing");

            Console.WriteLine("Counter returned {0}", counter.EndInvoke(couterResult));  //会在这里堵塞
            Console.WriteLine("Parser returned {0}", parser.EndInvoke(parserResult));    //会在这里堵塞

            Console.WriteLine("Done");
            Console.ReadKey();
        }

        static int CountCharacters(string text)
        {
            Thread.Sleep(2000);
            Console.WriteLine("Counting characters in {0}", text);
            return text.Length;
        }

        static int Parser(string text)
        {
            Thread.Sleep(100);
            Console.WriteLine("Parsing text {0}",text);
            return int.Parse(text);
        }
    }
}
