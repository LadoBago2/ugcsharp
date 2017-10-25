using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program5
    {
        static void Main(string[] args)
        {
            Action<string, double> cout = new Action<string, double>((s, d) => Console.WriteLine("{0}'s summary area = {1:0.0000}", s, d));

            ShapeContainer<Circle> circlesContainer = new ShapeContainer<Circle>();
            circlesContainer.AddShape(new Circle(r: 3));
            circlesContainer.AddShape(new Circle(r: 4));
            circlesContainer.AddShape(new Circle(r: 5.6D));
            circlesContainer.AddShape(new Circle(r: 12.01D));
            cout("circleContainer", circlesContainer.GetSummaryArea());
            ShapeContainer<Rectangle> rectanglesContainer = new ShapeContainer<Rectangle>();
            rectanglesContainer.AddShape(new Rectangle(h: 2, l: 3));
            rectanglesContainer.AddShape(new Rectangle(h: 4, l: 5));
            rectanglesContainer.AddShape(new Rectangle(h: 1, l: 20));
            cout("rectanglesContainer", rectanglesContainer.GetSummaryArea());
            Console.ReadLine();
        }
    }

    interface IShape
    {
        #region IShape.GetArea
        double GetArea();
        #endregion
    }
    class Circle : IShape
    {
        #region Circle.R
        /// <summary>
        /// Radius of circle
        /// </summary>
        public double R { get; set; }
        #endregion

        #region Circle.Constructor
        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="r">Radius of the circle. Must be non-negative.</param>
        public Circle(double r)
        {
            if (r < 0)
                throw new ArgumentException("Must be equal or greather to 0", "r");
            this.R = r;
        }
        #endregion

        #region IShape.GetArea
        /// <summary>
        /// Calculates area of the circle
        /// </summary>
        /// <returns></returns>
        public double GetArea()
        {
            return Math.Pow(R, 2) * Math.PI;
        }
        #endregion
    }
    class Rectangle : IShape
    {
        #region Rectangle.H
        /// <summary>
        /// Height of the rectangle
        /// </summary>
        public double H { get; set; }
        #endregion
        #region Rectangle.L
        /// <summary>
        /// Length of the rectangle
        /// </summary>
        public double L { get; set; }
        #endregion

        #region Rectangle.Constructor
        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="h">Height of the Rectangle. Must be non-negative.</param>
        /// <param name="l">Length of the Rectangle. Must be non-negative.</param>
        public Rectangle(double h, double l)
        {
            if (l < 0)
                throw new ArgumentException("Must be equal or greather to 0", "l");
            if (h < 0)
                throw new ArgumentException("Must be equal or greather to 0", "h");

            this.H = h;
            this.L = l;
        }
        #endregion

        #region IShape.GetArea
        /// <summary>
        /// Calculates area of the rectangle
        /// </summary>
        /// <returns></returns>
        public double GetArea()
        {
            return L * H;
        }
        #endregion
    }
    class ShapeContainer<TShape> where TShape : IShape
    {
        #region ShapeContainer.ShapeList
        private List<TShape> ShapeList { get; set; }
        #endregion

        #region ShapeContainer.Constructor
        public ShapeContainer()
        {
            this.ShapeList = new List<TShape>();
        }
        #endregion

        #region ShapeContainer.AddShape
        /// <summary>
        /// Add new shape to the container
        /// </summary>
        /// <param name="item">Instance of TShape</param>
        public void AddShape(TShape item)
        {
            this.ShapeList.Add(item);
        }
        #endregion
        #region ShapeContainer.GetSummaryArea
        /// <summary>
        /// Calculates summary area.
        /// </summary>
        /// <returns>Summary area of all shapes.</returns>
        public double GetSummaryArea()
        {
            double sum = 0;

            foreach (TShape item in this.ShapeList)
                sum += item.GetArea();

            return sum;
        }
        #endregion
    }
}
