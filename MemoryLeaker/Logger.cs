using System;
using System.Collections.Generic;
using System.Text;

namespace MemoryLeaker
{
    internal static class Logger
    {
        public static bool IsEnabled { get; set; }

        public static void WriteLine(string message)
        {
            if(IsEnabled)
            {
                Console.WriteLine(message);
            }
        }
    }
}
