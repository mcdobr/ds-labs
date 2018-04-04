using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exemplu
{
    class Program
    {

        struct SYSTEMTIME
        {
            public short wYear;
            public short wMonth;
            public short wDayOfWeek;
            public short wDay;
            public short wHour;
            public short wMinute;
            public short wSecond;
            public short wMilliseconds;
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        private extern static void GetSystemTime(ref SYSTEMTIME lpSystemTime);

        static void Main(string[] args)
        {
            SYSTEMTIME sysTime = new SYSTEMTIME();
            while (true)
            {

                GetSystemTime(ref sysTime);

                string hours = (sysTime.wHour > 9) ? sysTime.wHour.ToString() : "0" + sysTime.wHour;
                string minutes = (sysTime.wMinute > 9) ? sysTime.wMinute.ToString() : "0" + sysTime.wMinute;
                string seconds = (sysTime.wSecond > 9) ? sysTime.wSecond.ToString() : "0" + sysTime.wSecond;

                Console.WriteLine("{0}:{1}:{2}", hours, minutes, seconds);
                Thread.Sleep(1000);
            }
        }
    }
}
