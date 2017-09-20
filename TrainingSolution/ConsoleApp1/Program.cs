using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                        Console.WriteLine("Hello c#!");
                        int a=5;
                        Int16 a16 = 32000;
                        short a16_2 = 32000;

                        if (a16 != 1)
                        {
                            a = 3;
                            int b = 0;
                        }

                        Console.WriteLine("{0}, {1}, {2}", a, a16, a16_2);
                        Console.ReadLine();
            */

            Transaction tran1 = new Transaction();
            tran1.Amouont = 5;
            tran1.Ccy = "GEL";
            tran1.ReceiverIban = "GE00BS000000011111";
            tran1.SenderIban = "GE00BS000000022222";

            Transaction tran2 = tran1;
            tran2.Amouont = 6;
            Console.WriteLine("tran2.Amount={0}, tran1.Amount={1}", tran2.Amouont, tran1.Amouont);
            if (1 == 2)
                Console.WriteLine("1 is equal to 2;");
            else
                Console.WriteLine("1 is not equal to 2");


            switch (tran1.Amouont)
            {
                case 5:
                    Console.WriteLine(5);
                    break;
                case 10:
                case 11:
                    Console.WriteLine(11);
                    break;
                default:
                    Console.WriteLine("default");
                    break;
            }

            Console.ReadLine();
        }

        static void foo()
        {
           // a = 4;
        }
    }
}
