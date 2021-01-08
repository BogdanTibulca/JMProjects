using System;

namespace Json
{
    public static class JsonString
    {
        const int MinStringLength = 2;
        const int LastControlCharValue = 32;
        const char Quotes = '\"';

        public static bool IsJsonString(string input)
        {
            return !string.IsNullOrEmpty(input) &&
                   !ContainsControlCharacters(input) &&
                   IsWrappedInQuotes(input);
        }

        private static bool IsWrappedInQuotes(string input)
        {
            return input.Length >= MinStringLength && input[0] == Quotes && input[^1] == Quotes;
        }

        private static bool ContainsControlCharacters(string input)
        {
            foreach (char ch in input)
            {
                if (LastControlCharValue - ch >= 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
