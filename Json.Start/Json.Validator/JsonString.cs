using System;

namespace Json
{
    public static class JsonString
    {
        const int MinStringLength = 2;
        const int LastControlCharacter = 31;
        const char Quotes = '\"';
        const char ReversedSolidus = '\\';
        const char UnicodeChar = 'u';

        public static bool IsJsonString(string input)
        {
            return !string.IsNullOrEmpty(input) &&
                   HasValidUnicodeCharacters(input) &&
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
                    input[i] == ReversedSolidus && !IsValidEscapedCharacter(input[i + 1]))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool HasValidUnicodeCharacters(string input)
        {
            const int UnicodeCharLength = 6;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ReversedSolidus && input[i + 1] == UnicodeChar)
                {
                    if (input.Length - i <= UnicodeCharLength)
                    {
                        return false;
                    }

                    return IsValidUnicode(input.Substring(i + 1, UnicodeCharLength));
                }
            }

            return true;
        }

        private static bool IsValidUnicode(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (!char.IsDigit(input[i]) && !char.IsLetter(input[i]))
                {
                    return false;
                }

                if (char.IsLetter(input[i]))
                {
                    return input[i] < 'A' || (input[i] > 'F' && input[i] < 'a') || input[i] > 'f';
                }
            }

            return true;
        }

        private static bool IsValidEscapedCharacter(char escaped)
        {
            char[] validChars = { '"', ReversedSolidus, '/', 'b', 'f', 'n', 'r', 't', UnicodeChar };

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
