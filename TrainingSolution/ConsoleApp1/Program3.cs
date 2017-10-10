using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program3
    {
        static void Main(string[] args)
        {
            #region Arrays
            int[] a = new int[5];

            a[0] = 1;
            a[1] = -5;
            a[2] = 6;
            a[3] = 7;
            a[4] = 10;

            Console.Write("shemoitanet elementebis raodenoba: ");
            int n = int.Parse(Console.ReadLine());
            a = new int[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write("shemoitanet elementi #{0}: ", i);
                a[i] = Convert.ToInt32(Console.ReadLine());
            }
            if (n > 0)
            {
                int max = a[0];
                for (int i = 1; i < n; i++)
                {
                    if (a[i] > max)
                        max = a[i];
                }

                Console.WriteLine("maximaluri elementia: {0}", max);
            }
            #endregion
            #region Generics
            SortHelper<int> sa_int = new SortHelper<int>(new int[] { 10, 12, 0, -2, 3, 4 }, (e1, e2) => e1 < e2 ? -1 : (e1 > e2 ? 1 : 0));
            sa_int.Sort();
            for (int i = 0; i < sa_int.A.Length; i++)
            {
                Console.Write("{0}{1}", (i > 0 ? "," : ""), sa_int.A[i]);
            }
            Console.WriteLine();
            SortHelper<string> sa_string = new SortHelper<string>(new string[] { "M", "B", "A", "R" }, (e1, e2) => StringComparer.InvariantCulture.Compare(e1, e2));
            sa_string.Sort();
            for (int i = 0; i < sa_string.A.Length; i++)
            {
                Console.Write("{0}{1}", (i > 0 ? "," : ""), sa_string.A[i]);
            }
            #endregion

            Console.ReadLine();
        }
    }

    public class SortHelper<TArray>
    {
        public TArray[] A { private set; get; }
        private Func<TArray, TArray, int> _Comparer;
        #region SortHelper.Constructor
        public SortHelper(TArray[] a, Func<TArray, TArray, int> comparer)
        {
            A = a;
            _Comparer = comparer;
        }
        #endregion
        #region SortHelper.Sort - Bubble sort agorithm
        public void Sort()
        {
            for (int i = 0; i < A.Length; i++)
            {
                for (int j = 0; j < A.Length - 1; j++)
                {
                    if (_Comparer(A[j], A[j + 1]) == 1)
                    {
                        TArray t = A[j];
                        A[j] = A[j + 1];
                        A[j + 1] = t;
                    }
                }
            }
        }
        #endregion
    }
}
