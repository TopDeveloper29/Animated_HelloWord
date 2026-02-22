# HelloWorld Animated
![Recording2026-02-21192258-ezgif com-video-to-gif-converter](https://github.com/user-attachments/assets/e6c4e1a7-66c5-45a5-bafc-85f75be2b075)

## What It Does

Renders an ASCII **"Hello World!"** using `FiggleFonts.Larry3d` and
animates it in the console with:

-  Per-character coloring
-  Four directional animation effects:
    -   Left → Right
    -   Right → Left
    -   Top → Bottom
    -   Bottom → Top

Colors automatically cycle after each animation pass, creating a dynamic
visual effect.

------------------------------------------------------------------------

##  How It Works

-   **`Program.cs`**
    -   Hides the console cursor
    -   Starts and maintains the animation loop
    -   Calls `ConsoleAnimation.Write(...)` continuously
-   **`ConsoleAnimation.cs`**
    -   Write chars to create the ASCII text created using Figgle
    -   Animates the output line-by-line or column-by-column
    -   Handles directional rendering logic (Left/Right/Top/Bottom)
-   **`ConsoleColored.cs`**
    -   Writes text with foreground/background colors
    -   Safely restores previous console colors after writing
