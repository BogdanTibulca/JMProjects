using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            return !string.IsNullOrEmpty(input) &&
                    ContainsOnlyDiggits(input);
        }

        private static bool ContainsOnlyDiggits(string input)
        {
            foreach (char ch in input)
            {
                if (!char.IsDigit(ch))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
