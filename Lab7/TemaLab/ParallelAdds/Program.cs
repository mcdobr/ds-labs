using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelAdds
{
    class Program
    {
        private static readonly StreamWriter streamWriter = new StreamWriter(new MemoryStream());

        static void Main(string[] args)
        {
            int[] v = new int[1000];
            List<Thread> threads = new List<Thread>();

            Random rng = new Random();
            for (int i = 0; i < v.Length; ++i)
                v[i] = rng.Next(0xFFFF);
            Console.WriteLine(v.Sum());

            int iter = 0;
            while (v.Length > 1)
            {
                ++iter;
                int[] next = new int[v.Length / 2 + v.Length % 2];
                for (int i = 0; i < next.Length; ++i)
                {
                    int idx = i * 2;
                    threads.Add(new Thread(() => addElements(v, next, idx, iter)));
                }

                foreach (Thread thr in threads)
                    thr.Start();

                foreach (Thread thr in threads)
                    thr.Join();

                threads.Clear();
                v = next;
            }

            FileStream fileStream = new FileStream("./output.out", FileMode.Create, FileAccess.Write);

            streamWriter.Flush();
            streamWriter.BaseStream.Seek(0, SeekOrigin.Begin);
            streamWriter.BaseStream.CopyTo(fileStream);
        }

        static void addElements(int[] v, int[] next, int idx, int iter)
        {
            int sum = v[idx] + ((idx + 1 < v.Length) ? v[idx + 1] : 0);
            next[idx / 2] = sum;

            lock (streamWriter)
            {
                streamWriter.WriteLine("Iterația {0} : v[{1}] + v[{2}] = {3}", iter, idx, idx + 1, next[idx / 2]);
            }
        }
    }
}
