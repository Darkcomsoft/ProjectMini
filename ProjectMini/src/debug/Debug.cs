using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMini.src.debug
{
    public static class Debug
    {
        private static string finalCaller = "";

        public static void Log(string msg, string caller = "")
        {
            if (caller != string.Empty)
            {
                finalCaller = string.Format("[{0}]", caller);
            }
            else
            {
                finalCaller = "";
            }

            System.Diagnostics.Debug.WriteLine(string.Format("{0} {1}LOG: {2}", GetPrintTime(), finalCaller, msg));
        }

        public static void Warning(string msg, string caller = "")
        {
            if (caller != string.Empty)
            {
                finalCaller = string.Format("[{0}]", caller);
            }
            else
            {
                finalCaller = "";
            }

            System.Diagnostics.Debug.WriteLine(string.Format("{0} {1}Warning: {2}", GetPrintTime(), finalCaller, msg));
        }

        public static void Error(string msg, string caller = "")
        {
            if (caller != string.Empty)
            {
                finalCaller = string.Format("[{0}]", caller);
            }
            else
            {
                finalCaller = "";
            }

            System.Diagnostics.Debug.WriteLine(string.Format("{0} {1}Error: {2}", GetPrintTime(), finalCaller, msg));
        }

        /// <summary>
        /// Show a fail popup(WINDOWS ONLY)
        /// </summary>
        public static void PrintFail(string msg, string caller = "")
        {
            if (caller != string.Empty)
            {
                finalCaller = string.Format("[{0}]", caller);
            }
            else
            {
                finalCaller = "";
            }

            System.Diagnostics.Debug.Fail(string.Format("{0} {1}FAIL: {2}", GetPrintTime(), finalCaller, msg));
        }

        private static string GetPrintTime()
        {
            return string.Format("[{0}:{1}:{2}]", System.DateTime.Now.TimeOfDay.Hours, System.DateTime.Now.TimeOfDay.Minutes, System.DateTime.Now.TimeOfDay.Seconds);
        }

        private static void WriteConsole(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
