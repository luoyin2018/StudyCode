using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumerateCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            var tt = new Titles();
            foreach(var str in tt)
            {
                Console.Write(str);
            }

            Console.WriteLine();
            Console.Write("press any key to exit...");
            Console.ReadKey();
        }

        class Titles
        {
            string[] names = {"world","Hello "};

            public IEnumerator<string> GetEnumerator()
            {
                yield return names[1];
                yield return names[0];
            }
        }
    }
}
