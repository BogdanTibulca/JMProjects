using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            return !string.IsNullOrEmpty(input) && IsWrappedInQuotes(input);
        }

        private static bool IsWrappedInQuotes(string input)
        {
            const char Quotes = '\"';
            const int minStringLength = 2;

            return input.Length >= minStringLength && input[0] == Quotes && input[^1] == Quotes;
        }
    }
}
