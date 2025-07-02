# Debug Lib

## Explanation
This was coded in C# and is intended to be used in C# project. This is only a basic debug library but I am going to add more soon!

## Usage

1. Call `DebugLib.EnableConsole()` once at the start of your program to open a console window.

2. Use `DebugLib.Log("message", LogLevel)` to print messages with different levels:
- `LogLevel.Info` (default)
- `LogLevel.Warning`
- `LogLevel.Error`

```csharp
using DebugLibrary;

class Program
{
    static void Main()
    {
        DebugLib.EnableConsole();

        DebugLib.CurrentLevel = DebugLib.LogLevel.Info;

        DebugLib.Log("This is an info message.");            // Info (blue)
        DebugLib.Log("This is a warning!", DebugLib.LogLevel.Warning);  // Warning (yellow)
        DebugLib.Log("This is an error!", DebugLib.LogLevel.Error);     // Error (red)
    }
}
vbnet
Copy
Edit


