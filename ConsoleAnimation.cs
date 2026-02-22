using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using Figgle.Fonts;

namespace HelloWord_Animated;

/// <summary>
/// Provides static methods and properties for displaying animated text in the console using various animation
/// directions and color effects.
/// </summary>
internal static class ConsoleAnimation
{

    /// <summary>
    /// Gets or sets the default text used for animation displays.
    /// </summary>
    public static string AnimationText = FiggleFonts.Larry3d.Render("Hello World!");

    // The current position of the cursor in the console, used to determine where to write the next character during the animation.
    private static readonly CursorPositon CursorPosition = new(0,0);

    // The current color index used for the animation. This index is used to determine which color to use when writing characters to the console, and it is updated after each animation cycle to create a changing color effect.
    private static int CurentColor = 1;

    /// <summary>
    /// Writes the animated text to the console, character by character, with a delay between each character to create an animation effect.
    /// </summary>
    public static void Write(AnimationType Animation = AnimationType.RigthToLeft)
    {
        // Depending on the specified animation type, the method will either animate the text from left to right, right to left, top to bottom, or bottom to top. The animation is achieved by writing characters to the console in a specific order and introducing delays between writes to create a visual effect.
        if (Animation == AnimationType.LeftToRight || Animation == AnimationType.RigthToLeft)
        {
            // Split the animation text into lines and determine the maximum width of the lines to know how many columns to animate through
            var lines = AnimationText.Split("\n");
            var maxWidth = lines.Max(l => l.Length);

            // Determine column order depending on the animation type (left-to-right or right-to-left)
            var columnRange = (Animation == AnimationType.LeftToRight) ? Enumerable.Range(0, maxWidth) : Enumerable.Range(0, maxWidth).Reverse();

            // Loop through each column and write characters from that column for all lines, creating a vertical animation effect
            foreach (var col in columnRange)
            {
                // Loop through each line and write the character at the current column if it exists
                for (var row = 0; row < lines.Length; row++)
                {
                    if (col >= lines[row].Length)
                        continue; // Skip if this line is shorter

                    // Set the cursor position to the current column and row
                    CursorPosition.X = col;
                    CursorPosition.Y = row;
                    Console.SetCursorPosition(CursorPosition.X, CursorPosition.Y);

                    // Write the character at the current column with the current color
                    ConsoleColored.Write(lines[row][col], FromInt<ConsoleColor>(CurentColor));

                }

                // Wait for a short delay before writing the next column to create the animation effect
                Thread.Sleep(1);

            }
        }
        else
        {
            var Lines = (Animation == AnimationType.TopToBottom ? AnimationText.Split("\n") : AnimationText.Split("\n").Reverse().ToArray());
            CursorPosition.Y = (Animation == AnimationType.TopToBottom ? 0 : Lines.Length - 1);

            // Loop through each line of the text and write it to the console with the current color
            foreach (var line in Lines)
            {
                // Reset the cursor position to the beginning of the line
                CursorPosition.X = 0;
                Console.SetCursorPosition(CursorPosition.X, CursorPosition.Y);

                // Write each character of the string with the new color
                foreach (var c in line.ToList())
                {
                    // Set the cursor position to the current position and write the character with the current color
                    Console.SetCursorPosition(CursorPosition.X, CursorPosition.Y);
                    ConsoleColored.Write(c, FromInt<ConsoleColor>(CurentColor));


                    // Move the cursor position to the right for the next character
                    CursorPosition.X++;
                }

                // Wait for a short delay before writing the next line to create the animation effect
                Thread.Sleep(20);

                CursorPosition.Y += (Animation == AnimationType.TopToBottom ? 1 : -1);
            }
        }
        // Get the next color for the next time we call this method
        GetNextColor();
    }

    /// <summary>
    /// Advances the current console color to the next available color in the sequence.
    /// </summary>
    /// <remarks>Skips the first color to avoid black Foreground on black background</remarks>
    private static void GetNextColor()
    {
        var ColorCount = Enum.GetNames<ConsoleColor>().Length;
        CurentColor++;
        if (CurentColor >= ColorCount)
            CurentColor = 1;
    }
    public static T FromInt<T>(int intValue) where T : Enum => (T)Enum.ToObject(typeof(T), intValue);

    /// <summary>
    /// Represents a position in a two-dimensional coordinate system using X and Y values.
    /// </summary>
    /// <param name="X">The horizontal coordinate of the position.</param>
    /// <param name="Y">The vertical coordinate of the position.</param>
    private class CursorPositon(int X, int Y)
    {
        public int X { get; set; } = X;
        public int Y { get; set; } = Y;
    }

    /// <summary>
    /// Specifies the direction in which an animation progresses.
    /// </summary>
    /// <remarks>Use this enumeration to indicate the movement direction for visual animations, such as
    /// sliding or transitioning UI elements. Each value represents a distinct directional flow. This type is commonly
    /// used to control animation behavior in user interface components.</remarks>
    public enum AnimationType
    {
        LeftToRight = 0,
        RigthToLeft = 1,
        TopToBottom = 2,
        BottomToTop = 3
    }

}
