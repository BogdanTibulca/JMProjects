using System;

namespace Json
{
    enum ValidEscapedChars
    {
        Quotes = '\"',
        ReversedSolid = '\\',
        Solidus = '/',
        UnicodeChar = 'u',
        Backspace = 'b',
        FormFeed = 'f',
        LineFeed = 'n',
        Carriage = 'r',
        HorizontalTab = 't'
    }

    public static class JsonString
    {
        const int MinStringLength = 2;
        const int UnicodeCharLength = 4;
        const int LastControlCharacter = 31;
        const char ReversedSolidus = '\\';

        public static bool IsJsonString(string input)
        {
            return HasContentWrappedInQuotes(input) &&
                   HasValidUnicodeCharacters(input) &&
                   ContainsValidEscapedCharacters(input) &&
                   !ContainsControlCharacters(input);
        }

        private static bool IsWrappedInQuotes(string input)
        {
            return input.Length >= MinStringLength &&
                input[0] == (char)ValidEscapedChars.Quotes &&
                input[^1] == (char)ValidEscapedChars.Quotes;
        }

        private static bool HasContentWrappedInQuotes(string input)
        {
            return !string.IsNullOrEmpty(input) &&
                   IsWrappedInQuotes(input);
        }

        private static bool ContainsControlCharacters(string input)
        {
            foreach (char ch in input)
            {
                if (ch <= LastControlCharacter)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool ContainsValidEscapedCharacters(string input)
        {
            if (input.LastIndexOf(ReversedSolidus) == input.Length - MinStringLength &&
                input[input.Length - MinStringLength - 1] != ReversedSolidus)
            {
                return false;
            }

            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == ReversedSolidus && !IsValidEscapedCharacter(input[i + 1]))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsValidEscapedCharacter(char escaped)
        {
            foreach (ValidEscapedChars ch in Enum.GetValues(typeof(ValidEscapedChars)))
            {
                if ((char)ch == escaped)
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
