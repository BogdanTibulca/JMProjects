using System;

namespace Json
{
    public static class JsonString
    {
        const int MinStringLength = 2;
        const int LastControlCharacter = 31;
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
            for (int i = 0; i < input.Length - 1; i++)
            {
                if (LastControlCharacter - input[i] > 0 ||
                    input[i] == '\\' && !IsValidEscapedCharacter(input[i + 1]))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsValidEscapedCharacter(char escaped)
        {
            char[] validChars = { '"', '\\', '/', 'b', 'f', 'n', 'r' };

            foreach (char ch in validChars)
            {
                if (ch == escaped || char.IsWhiteSpace(escaped))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
