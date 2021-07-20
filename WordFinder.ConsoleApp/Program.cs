using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace WordFinder.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var stopWatch = new Stopwatch();
                                
                IWordFinder finder = new WordFinder(Inputs.Matrix, new MemoryConfiguration());
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("> Given the following matrix:");
                Console.WriteLine();
                Console.WriteLine(string.Join("\n", Inputs.Matrix));
                Console.WriteLine();

                var wordStream = new[] {"chill", "cold", "cold", "wind", "snow"};
                
                Console.Write($"...Searching for words: ");
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine(string.Join(", ", wordStream));
                
                stopWatch.Start();
        
                var words = finder
                    .Find(wordStream);
                
                stopWatch.Stop();
        
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();
                Console.Write($"> Results found (sorted by relevance): ");
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine(string.Join(", ", words));
                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"> Elapsed time: {stopWatch.Elapsed.Milliseconds} (ms)");
            }
            catch (Exception e)
            {
                Console.Error.WriteLine($"An error ocurred: {e.Message}");
            }
        }
    }
}
