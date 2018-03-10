using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public class SimpleMath : MarshalByRefObject
    {
        public SimpleMath()
        {
            Console.WriteLine("SimpleMath ctor called");
        }

        public int Add(int n1, int n2)
        {
            Console.WriteLine("SimpleMath.Add({0}, {1})", n1, n2);
            return n1 + n2;
        }
        public int Subtract(int n1, int n2)
        {
            Console.WriteLine("SimpleMath.Subtract({0}, {1})", n1, n2);
            return n1 - n2;
        }

        /* I considered that the function wants a new array that is sorted
         * so to keep the array immutable even though the 
         * complexity is worse (but that is not the point of the program)
         */
        public T[] Sort<T>(T[] array/*, IComparer<T> comparer*/)
        {
            Console.WriteLine("SimpleMath.Sort()");
            
            /* Fancy way of copying the array */
            T[] result = array.ToArray();

            Array.Sort(result);
            return result;
        }

        public int IndexOf<T>(T[] array, T val)
        {
            Console.WriteLine("SimpleMath.IndexOf()");
            /* I could also make a wrapper for a binary search method */
            return Array.IndexOf<T>(array, val);
        }

        public T[] RemoveElement<T>(T[] array, T val)
        {
            Console.WriteLine("SimpleMath.RemoveElement()");
            int pos = IndexOf<T>(array, val);
            if (pos == -1)
                return array.ToArray();
            else
            {
                T[] res = new T[array.Length - 1];
                for (int i = 0; i < pos; ++i)
                    res[i] = array[i];
                for (int i = pos + 1; i < array.Length; ++i)
                    res[i - 1] = array[i];

                return res;
            }
        }

    }
}
