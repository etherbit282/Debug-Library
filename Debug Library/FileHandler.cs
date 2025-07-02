using System;
using System.IO;

namespace DebugLibrary
{
    public static class FileHandler
    {
        private static StreamWriter _logWriter;
        private static bool _isLoggingEnabled = false;
        private static readonly object _writeLock = new object();

        public static void EnableLogging()
        {
            if (_isLoggingEnabled)
                return;

            try
            {
                string exeDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string logsDir = Path.Combine(exeDirectory, "Logs");
                Directory.CreateDirectory(logsDir);

                string logFilePath = Path.Combine(logsDir, "log.txt");
                _logWriter = new StreamWriter(logFilePath, true);
                _logWriter.AutoFlush = true;

                _isLoggingEnabled = true;
            }
            catch (Exception ex)
            {
                // if logging setup fails just disable logging 
                _isLoggingEnabled = false;
            }
        }

        public static void LogToFile(string message)
        {
            if (!_isLoggingEnabled)
                return;

            lock (_writeLock)
            {
                try
                {
                    string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    _logWriter.WriteLine($"[{timestamp}] {message}");
                }
                catch
                {
                    // ignore any errors during writing
                }
            }
        }

        public static void Close()
        {
            if (!_isLoggingEnabled)
                return;

            try
            {
                _logWriter.Flush();
                _logWriter.Close();
            }
            catch
            {
                // ignore
            }
            finally
            {
                _logWriter = null;
                _isLoggingEnabled = false;
            }
        }
    }
}
