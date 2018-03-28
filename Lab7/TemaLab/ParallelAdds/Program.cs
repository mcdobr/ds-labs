using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelAdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] v = new int[1000];
            List<Thread> threads = new List<Thread>();

            Random rng = new Random();
            for (int i = 0; i < v.Length; ++i)
                v[i] = rng.Next(0xFFFF);

            while (v.Length > 1)
            {
                int[] next = new int[v.Length / 2];
                
                for (int i = 0; i < next.Length; ++i)
                {
                    threads.Add(new Thread(() => addElements(v, i * 2, next)));
                    Console.WriteLine(i * 2);
                }

                foreach (Thread thr in threads)
                    thr.Start();

                foreach (Thread thr in threads)
                    thr.Join();


                // folosesc o bariera

                v = next;
            }

            //ThreadPool.QueueUserWorkItem(new ParameterizedThreadStart(v));
        }


        static void addElements(int[] v, int idx, int[] next)
        {
            int sum = v[idx] + v[idx + 1];
            next[idx / 2] = sum;
        }

    }
}
