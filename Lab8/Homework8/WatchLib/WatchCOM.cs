using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WatchLib
{
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class WatchCOM
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
        private extern static void GetLocalTime(out SYSTEMTIME lpSystemTime);

        private string getPaddedStringValue(short val)
        {
            return (val > 9) ? ("" + val) : ("0" + val);
        }

        public string getTime()
        {
            SYSTEMTIME localTime;
            GetLocalTime(out localTime);

            string hours = getPaddedStringValue(localTime.wHour);
            string minutes = getPaddedStringValue(localTime.wMinute);
            string seconds = getPaddedStringValue(localTime.wSecond);

            return string.Format("{0}:{1}:{2}", hours, minutes, seconds);
        }
    }
}
