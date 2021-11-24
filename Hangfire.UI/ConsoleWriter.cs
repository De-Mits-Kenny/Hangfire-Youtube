using System;
using System.Collections.Generic;

namespace Hangfire.UI
{
    public static class ConsoleWriter
    {
        public static void WriteTitle(string text, ConsoleColor? color = null)
        {
            WriteText(text, color);
            WriteText(string.Empty.PadRight(text.Length, '-'), color);
        }

        public static void WriteText(string text = null, ConsoleColor? color = null, bool writeNewLine = true)
        {
            if (color != null)
            {
                Console.ForegroundColor = color.Value;
            }

            if (writeNewLine)
            {
                Console.WriteLine(text);
            }
            else
            {
                Console.Write(text);
            }
            Console.ResetColor();
        }
    }
}