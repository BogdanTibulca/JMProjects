using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            return char.IsDigit(input[0]) &&
                !ContainsLetters(input);
        }

        private static bool ContainsLetters(string input)
        {
            foreach (char ch in input)
            {
                if (char.IsLetter(ch))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
