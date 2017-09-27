using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    struct Coordinates
    {
        public float x;
        public float y;

        public Coordinates(float _x, float _y)
        {
            this.x = _x;
            this.y = _y;
        }

        public double GetDistanceFrom(Coordinates c)
        {
            return Math.Sqrt(Math.Pow(c.x - this.x, 2) + Math.Pow(c.y - this.y, 2));
        }
        public void GetDistanceFrom(Coordinates c, out double distance)
        {
            if (c.x > 0)
                distance = Math.Sqrt(Math.Pow(c.x - this.x, 2) + Math.Pow(c.y - this.y, 2));
            else
                distance = 0;
            return;
        }

    }
}
