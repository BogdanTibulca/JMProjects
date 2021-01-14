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
            bool hasValidUnicodes = true;

            for (int i = 0; i < input.Length - 1; i++)
            {
                if (HasUnicodeFormat(input, i, i + 1))
                {
                    if (input.Length - i <= UnicodeCharLength)
                    {
                        return false;
                    }

                    if (!IsValidUnicode(input.Substring(i + MinStringLength, UnicodeCharLength)))
                    {
                        hasValidUnicodes = false;
                    }
                }
            }

            return hasValidUnicodes;
        }

        private static bool HasUnicodeFormat(string input, int firstIndex, int secondIndex)
        {
            return input[firstIndex] == ReversedSolidus && input[secondIndex] == (char)ValidEscapedChars.UnicodeChar;
        }

        private static bool IsValidUnicode(string input)
        {
            bool isValid = true;

            for (int i = 0; i < input.Length; i++)
            {
                if (!char.IsDigit(input[i]) && !char.IsLetter(input[i]))
                {
                    return false;
                }

                if (char.IsLetter(input[i]) && !IsValidUnicodeLetter(input[i]))
                {
                    isValid = false;
                }
            }

            return isValid;
        }

        private static bool IsValidUnicodeLetter(char ch)
        {
            return (ch >= 'A' && ch <= 'F') || (ch >= 'a' && ch <= 'f');
        }
    }
}
