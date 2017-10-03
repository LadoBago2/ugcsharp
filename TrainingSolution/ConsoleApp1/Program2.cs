using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program2
    {
        private delegate int MyOp(int a, int b);
        private static MyOp d;

        static void Main(string[] args)
        {
            d = Add;

            d = delegate (int a, int b) {
                return a + b;
            };

            d = (a, b) => a + b;
            d = (a, b) => {

                return a + b;

            };

            Console.WriteLine(d(1, 2));

            Counter cnt = new Counter();
            cnt.myEvent += handler;
            cnt.myEvent += handler2;

            for (int i = 0; i < 15; i++)
                cnt.Inc();

            Console.ReadLine();
        }

        static void handler(object sender, EventArgs e)
        {

        }
        static void handler2(object sender, EventArgs e)
        {

        }

        static int Add(int a, int b)
        {
            return a + b;
        }
        static int Subtract(int a, int b)
        {
            return a - b;
        }
    }
}
