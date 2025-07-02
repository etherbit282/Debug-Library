# Debug Lib

## Explanation
This was coded in C# and is intended to be used in C# projects. This is only a basic debug library but I am going to add more soon!

## How to Add to Your Project

1. Copy the `DebugLib.cs` file (or the entire `DebugLibrary` folder) into your project directory.

2. Add the following line at the top of your C# files where you want to use the library:
```csharp
using DebugLibrary;
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
