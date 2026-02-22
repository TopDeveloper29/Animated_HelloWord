
namespace HelloWord_Animated;

/// <summary>
/// Provides the main entry point for the application.
/// </summary>
/// <remarks>This class contains the application's Main method, which is invoked when the program starts. It is
/// intended to be used as the entry point for a console application.</remarks>
public class Program
{
    /// <summary>
    /// Serves as the entry point for the application.
    /// </summary>
    /// <remarks>This method hides the console cursor and starts an infinite animation loop. The method does
    /// not return and is intended to be run as the main entry point of a console application.</remarks>
    /// <param name="args">An array of command-line arguments supplied to the application.</param>
    public static void Main(string[] args)
    {
        // Hide the cursor to improve the visual effect of the animation
        Console.CursorVisible = false;

        // Display the initial animation text in the console before starting the animation loop
        ConsoleColored.WriteLine(ConsoleAnimation.AnimationText, ConsoleColor.Cyan);

        // Start the animation loop, which will continuously write the animated text to the console
        while (true)
        {
            // Call the Write method of the Animation class to display the animated text
            var Animation = (ConsoleAnimation.FromInt<ConsoleAnimation.AnimationType>(Random.Shared.Next(0, 4)));
            ConsoleAnimation.Write(Animation);
        }
    }
}