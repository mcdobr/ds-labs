using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
 * La fel de bine în loc de Task.Factory.StartNew puteam să creez câte un thread nou
 * cu expresii lambda și în loc să dau taskA.wait() să dau thread1.join() 
 */
namespace BitonicSort
{
    class BitonicSorter
    {
        private static int nrElements = 65536;

        public const bool ASCENDING = true, DESCENDING = false;

        public void sort(int[] v, bool direction = true)
        {
            Debug.Assert(isPowerOfTwo(v.Length));
            bitonicSort(v, ASCENDING, 0, v.Length - 1);
        }

        private void bitonicSort(int[] v, bool direction, int lo, int hi)
        {
            Console.WriteLine("Started bitonicSort(lo={0}, hi={1}) on Thread{2}", lo, hi, Thread.CurrentThread.ManagedThreadId);

            if (lo == hi)
                return;

            int mid = (lo + hi) / 2;
            Task sortLeft = Task.Factory.StartNew(() => bitonicSort(v, ASCENDING, lo, mid));
            Task sortRight = Task.Factory.StartNew(() => bitonicSort(v, DESCENDING, mid + 1, hi));

            sortLeft.Wait();
            sortRight.Wait();

            bitonicMerge(v, direction, lo, hi);

            Console.WriteLine("Ended bitonicSort(lo={0}, hi={1}) on Thread{2}", lo, hi, Thread.CurrentThread.ManagedThreadId);
        }
        
        private void bitonicMerge(int[] v, bool direction, int lo, int hi)
        {
            Console.WriteLine("Started bitonicMerge(lo={0}, hi={1}) on Thread{2}", lo, hi, Thread.CurrentThread.ManagedThreadId);

            if (lo == hi)
                return;

            int mid = (lo + hi) / 2;
            bitonicCompare(v, direction, lo, hi);

            Task mergeLeft = Task.Factory.StartNew(() => bitonicMerge(v, direction, lo, mid));
            Task mergeRight = Task.Factory.StartNew(() => bitonicMerge(v, direction, mid + 1, hi));

            mergeLeft.Wait();
            mergeRight.Wait();

            Console.WriteLine("Ended bitonicMerge(lo={0}, hi={1}) on Thread{2}", lo, hi, Thread.CurrentThread.ManagedThreadId);
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
            //Random rng = new Random();
            int[] v = new int[nrElements];
            for (int i = 0; i < v.Length; ++i)
                //v[i] = rng.Next(1 << 10);
                v[i] = nrElements - i;

            BitonicSorter bitonicSorter = new BitonicSorter();
            bitonicSorter.sort(v);
            
            Console.WriteLine("[{0}]", string.Join(", ", v));
        }
    }
}
