using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWord_Animated;

/// <summary>
/// Provides static methods for writing colored text to the console with customizable foreground and background colors.
/// </summary>
/// <remarks>The ColorConsole class enables writing text to the console using specified colors, temporarily
/// overriding the current console color settings for each write operation. Colors are reset to their previous values
/// after each call.</remarks>
internal class ConsoleColored
{
    /// <summary>
    /// Writes the specified value to the console using the given foreground and background colors, then resets the
    /// console colors to their previous values.
    /// </summary>
    /// <remarks>This method temporarily changes the console's foreground and background colors for the
    /// duration of the write operation. After writing, the console colors are reset to their previous settings.</remarks>
    /// <param name="value">The value to write to the console. If the value is null, nothing is written.</param>
    /// <param name="ForegroundColor">The color to use for the text foreground. Defaults to ConsoleColor.White.</param>
    /// <param name="BackgroundColor">The color to use for the text background. Defaults to ConsoleColor.Black.</param>
    public static void Write(object value, ConsoleColor ForegroundColor = ConsoleColor.White, ConsoleColor BackgroundColor = ConsoleColor.Black)
    {
        Console.ForegroundColor = ForegroundColor;
        Console.BackgroundColor = BackgroundColor;
        Console.Write(value);
        Console.ResetColor();
    }

    /// <summary>
    /// Writes the specified value to the console, followed by the current line terminator, using the specified
    /// foreground and background colors.
    /// </summary>
    /// <remarks>After writing the value, the method appends a line terminator and resets the console colors
    /// to their previous values.</remarks>
    /// <param name="value">The value to write to the console. If null, only the line terminator is written.</param>
    /// <param name="ForegroundColor">The color to use for the text foreground. Defaults to ConsoleColor.White.</param>
    /// <param name="BackgroundColor">The color to use for the text background. Defaults to ConsoleColor.Black.</param>
    public static void WriteLine(object? value = null, ConsoleColor ForegroundColor = ConsoleColor.White, ConsoleColor BackgroundColor = ConsoleColor.Black)
    {
        Write(value, ForegroundColor, BackgroundColor);
        Console.WriteLine();
    }
}
