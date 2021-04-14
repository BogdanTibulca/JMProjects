using System;
using System.IO;

namespace Collections
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // string filePath = "..\\..\\..\\Numbers.txt";

            foreach (int num in ReadIntegersFromFile(Console.ReadLine()))
            {
                Console.WriteLine(num);
            }
        }

        public static List<int> ReadIntegersFromFile(string filePath)
        {
            List<int> number = new List<int>();

            try
            {
                using var file = new StreamReader(filePath);
                var nums = file.ReadToEnd().Trim().Split(" ");

                foreach (var num in nums)
                {
                    if (!string.IsNullOrEmpty(num))
                    {
                        try
                        {
                            number.Add(Convert.ToInt32(num));
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("The file does not contain only integers");
                        }
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("The file path cannot be empty");
            }

            return number;
        }
    }
}
