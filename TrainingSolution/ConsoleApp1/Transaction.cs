using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    partial class Transaction
    {
        internal decimal Commission = 0;

    }

    partial class Transaction
    {
        internal const double MAX_AMOUNT = 100;

        internal static int Field1;

        internal decimal Amouont;
        internal string SenderIban;
        internal string ReceiverIban;
        internal string Ccy;
        internal readonly int ID;

        internal Transaction()
        {
            this.Amouont = 0;
        }
        internal Transaction(int _id)
        {
            this.ID = _id;
        }
        static Transaction()
        {
            Field1 = 5;


        }


        internal static void method1()
        {
            
        }
        public void setID(int _id)
        {
            //this.ID = _id;
            Field1 = 30;
        }

        public override string ToString()
        {
            return string.Format("{0}=>{1} {2}/{3}", SenderIban, ReceiverIban, Amouont, Ccy);
        }

    }
}
