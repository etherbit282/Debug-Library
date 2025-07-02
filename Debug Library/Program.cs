namespace DebugLibrary
{
    public static class DebugLib
    {
        public enum LogLevel { Info, Warning, Error }

        public static LogLevel CurrentLevel { get; set; } = LogLevel.Info;

        public static void Log(string message, LogLevel level = LogLevel.Info)
        {
            if (level < CurrentLevel) return;

            ConsoleColor originalColor = Console.ForegroundColor;

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
