using System;
using System.Runtime.InteropServices;

namespace DebugLibrary
{
    public static class DebugLib
    {
        public enum LogLevel
        {
            Info,
            Warning,
            Error
        }

        public static LogLevel CurrentLevel { get; set; } = LogLevel.Info;

        private static bool _consoleAllocated = false;

        [DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        public static void EnableConsole()
        {
            if (_consoleAllocated)
                return;

            AllocConsole();
            _consoleAllocated = true;
        }

        public static void Log(string message, LogLevel level = LogLevel.Info)
        {
            if (level < CurrentLevel)
                return;

            if (!_consoleAllocated)
            {
                // console not allocated yet so log nothing
                return;
            }

            var originalColor = Console.ForegroundColor;

            switch (level)
            {
                case LogLevel.Info:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;

                case LogLevel.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;

                case LogLevel.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }

            Console.WriteLine($"[{level}] {message}");

            Console.ForegroundColor = originalColor;
        }
    }
}
