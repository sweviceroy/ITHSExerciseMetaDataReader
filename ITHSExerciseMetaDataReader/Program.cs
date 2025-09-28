using System;
using System.IO;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Hex dump demo (Q to quit)");

            string imagesDir = Path.Combine(Directory.GetCurrentDirectory(), "images");
            if (!Directory.Exists(imagesDir))
            {
                Console.WriteLine("No 'images' folder found!");
                return;
            }

            string[] files = Directory.GetFiles(imagesDir);
            if (files.Length == 0)
            {
                Console.WriteLine("No files in 'images' folder.");
                return;
            }

            string file = files[1];
            Console.WriteLine($"Reading file: {Path.GetFileName(file)}\n");

            byte[] data = File.ReadAllBytes(file);

            for (int i = 0; i < data.Length; i++)
            {
                Console.Write($"{data[i]:X2} ");
                if ((i + 1) % 16 == 0)
                    Console.WriteLine();
            }

            Console.WriteLine("\n\nPress Q to quit, any other key to refresh...");
            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Q) break;
        }
    }
}
