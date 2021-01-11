using System;

namespace Json
{
    public static class JsonString
    {
        const int MinStringLength = 2;
        const int LastControlCharValue = 31;
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
                if (LastControlCharValue - ch >= 0 && !IsValidEscapedCharacter(ch))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsValidEscapedCharacter(char ch)
        {
            char[] validEscapedCharacters = { '\"', '\\', '/', '\b' };

            foreach (char escapedCh in validEscapedCharacters)
            {
                if (escapedCh == ch)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
