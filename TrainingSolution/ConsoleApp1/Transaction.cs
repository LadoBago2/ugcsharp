using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Transaction
    {
        internal double Amouont;
        internal string SenderIban;
        internal string ReceiverIban;
        internal string Ccy;

        internal Transaction()
        {
            this.Amouont = 0;
        }
    }
}
