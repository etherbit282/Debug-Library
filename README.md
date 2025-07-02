# Debug Lib

## Explanation
This library is coded in C# and intended for use in C# projects. It provides basic debug logging to the console with different log levels. File logging support has also been added!

## How to Add to Your Project

1. Copy the `DebugLib.cs`, `FileHandler.cs`, or the entire `DebugLibrary` folder into your project directory.

2. Add this line at the top of your C# files where you want to use the library:

```csharp
using DebugLibrary;
class Program
{
    static void Main()
    {
        DebugLib.EnableConsole();           // Enables the console window for output
        FileHandler.EnableLogging();        // Enables logging to Logs/log.txt file

        DebugLib.CurrentLevel = DebugLib.LogLevel.Info;

        DebugLib.Log("This is an info message.");                          // Info (blue)
        DebugLib.Log("This is a warning!", DebugLib.LogLevel.Warning);     // Warning (yellow)
        DebugLib.Log("This is an error!", DebugLib.LogLevel.Error);        // Error (red)

        FileHandler.Close();               // Close file logging properly when done
    }
}
```
