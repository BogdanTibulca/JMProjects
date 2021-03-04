using System;

namespace JSONFormat
{
    public class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please enter a path to a text file!");
                return;
            }

            string jsonText = System.IO.File.ReadAllText(args[0]);

            var value = new Value();
            var result = value.Match(jsonText);

            Console.WriteLine(result.Success() && result.RemainingText() == "");
        }
    }
}