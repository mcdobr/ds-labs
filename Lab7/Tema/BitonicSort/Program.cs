using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitonicSort
{
    class BitonicSorter
    {
        public const bool ASCENDING = true, DESCENDING = false;

        public void sort(int[] v, bool direction = true)
        {
            Debug.Assert(isPowerOfTwo(v.Length));
            bitonicSort(v, ASCENDING, 0, v.Length - 1);
        }

        private void bitonicSort(int[] v, bool direction, int lo, int hi)
        {
            if (lo == hi)
                return;

            int mid = (lo + hi) / 2;
            bitonicSort(v, ASCENDING, lo, mid);
            bitonicSort(v, DESCENDING, mid + 1, hi);
            bitonicMerge(v, direction, lo, hi);
        }
        
        private void bitonicMerge(int[] v, bool direction, int lo, int hi)
        {
            if (lo == hi)
                return;

            int mid = (lo + hi) / 2;
            bitonicCompare(v, direction, lo, hi);
            bitonicMerge(v, direction, lo, mid);
            bitonicMerge(v, direction, mid + 1, hi);
        }

        private void bitonicCompare(int[] v, bool direction, int lo, int hi)
        {
            int n = hi - lo + 1;
            int dist = n / 2;

            for (int i = lo; i < lo + dist; ++i)
                if ((v[i] > v[i + dist]) == direction)
                    swap(ref v[i], ref v[i + dist]);
        }
        
        private bool isPowerOfTwo(int x)
        {
            return (x != 0) && (x & (x - 1)) == 0;
        }

        private void swap<T>(ref T lhs, ref T rhs)
        {
            T tmp = lhs;
            lhs = rhs;
            rhs = tmp;
        }

        static void Main(string[] args)
        {
            int[] v = new int[] { 3, 7, 4, 8, 6, 2, 5, 1 };
            BitonicSorter bitonicSorter = new BitonicSorter();

            Random rng = new Random();
            v = new int[64];
            for (int i = 0; i < v.Length; ++i)
                v[i] = rng.Next(1 << 10);


            bitonicSorter.sort(v);

           

            Console.WriteLine("[{0}]", string.Join(", ", v));
        }
    }
}
