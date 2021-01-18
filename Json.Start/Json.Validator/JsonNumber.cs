using System;

namespace Json
{
    public static class JsonNumber
    {
        const char DecimalSeparator = '.';

        public static bool IsJsonNumber(string input)
        {
            return !string.IsNullOrEmpty(input) &&
                    (IsValidInteger(input) || IsValidFractionalNumber(input));
        }

        private static bool IsValidInteger(string input)
        {
            return IsValidNegativeInteger(input) || IsValidPositiveInteger(input);
        }

        private static bool IsValidPositiveInteger(string input)
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

        private static bool IsValidNegativeInteger(string input)
        {
            return input[0] == '-' && IsValidPositiveInteger(input.Substring(1));
        }

        private static bool IsValidFractionalNumber(string input)
        {
            string[] numbersParts = input.Split(DecimalSeparator);

            return IsValidInteger(numbersParts[0]) &&
                IsValidPositiveInteger(numbersParts[1]);
        }
    }
}
