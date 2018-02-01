using System;
using System.Threading;
using System.Runtime.Remoting.Messaging;   //AsynResult类所在空间

namespace AsyncDelegateExample
{
    //主进程完全没有堵塞
    class Program2
    {
        static void Main(string[] args)
        {
            SampleDelegate counter = new SampleDelegate(CountCharacters);
            SampleDelegate parser  = new SampleDelegate(Parser);

            AsyncCallback callback  = new AsyncCallback(DisplayResult);    //回调函数  !!!!!!!!!!

            counter.BeginInvoke("hello",callback,"Counter returned {0}");  
            parser.BeginInvoke("10",callback, "Parser returned {0}");

            Console.WriteLine("Main thread continuing");

            //Thread.Sleep(3000);
            Console.WriteLine("Done");
            Console.ReadKey();
        }

        //在回调函数中儿取
        static void DisplayResult(IAsyncResult result)
        {
            string format = (string)result.AsyncState;    // 就是BeginInvoke的第三个参数
            AsyncResult delegateResult = (AsyncResult)result;     //传入的result总是一个AsyncResult实例，可用于获取原来的委托实例，从而可以调用EndInvoke
            SampleDelegate delegateInstance = (SampleDelegate)delegateResult.AsyncDelegate; 
            Console.WriteLine(format, delegateInstance.EndInvoke(result));    //异步委托要调用EndInvoke有两个目的：1）获取近回值 2)防止内存泄漏
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
