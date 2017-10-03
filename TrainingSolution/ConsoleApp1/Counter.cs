using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Counter
    {
        public event EventHandler myEvent;
        private int _Count = 0;

        public void Inc()
        {
            this._Count++;
            if (this._Count > 10)
            {
                OnMyEvent();
            }
        }

        private void OnMyEvent()
        {
            if (myEvent != null)
                myEvent(this, new EventArgs());
        }


    }
}
