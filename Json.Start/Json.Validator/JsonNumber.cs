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
            if (input[0] == '0' && input.Length > 1)
            {
                return false;
            }

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
