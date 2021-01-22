using System;

namespace Json
{
    public static class JsonNumber
    {
        const char DecimalSeparator = '.';
        const char Exponent = 'e';

        public static bool IsJsonNumber(string input)
        {
            return !string.IsNullOrEmpty(input) &&
                    IsValidNumber(input);
        }

        private static bool IsValidNumber(string input)
        {
            return IsValidInteger(input) ||
                   IsValidFractionalNumber(input) ||
                   IsValidNumberWithExponent(input);
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

            return ContainsOnlyDiggits(input);
        }

        private static bool IsValidNegativeInteger(string input)
        {
            return input[0] == '-' && IsValidPositiveInteger(input.Substring(1));
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

        private static bool IsValidFractionalNumber(string input)
        {
            if (!HasFractionalFormat(input))
            {
                return false;
            }

            string[] numbersParts = input.Split(DecimalSeparator);

            return IsValidInteger(numbersParts[0]) &&
                ContainsOnlyDiggits(numbersParts[1]);
        }

        private static bool HasFractionalFormat(string input)
        {
            return input.IndexOf(DecimalSeparator) != input.Length - 1 &&
                   input.IndexOf(DecimalSeparator) == input.LastIndexOf(DecimalSeparator);
        }

        private static bool IsValidNumberWithExponent(string input)
        {
            return HasValidExponentFormat(input.ToLower());
        }

        private static bool HasValidExponentFormat(string input)
        {
            if (input.IndexOf(Exponent) != input.LastIndexOf(Exponent) || input.IndexOf(Exponent) < 1)
            {
                return false;
            }

            string[] numberParts = input.Split(Exponent);

            if (!(IsValidInteger(numberParts[0]) || IsValidFractionalNumber(numberParts[0])))
            {
                return false;
            }

            return (numberParts[1].Length >= 1) &&
                IsValidExponent(numberParts[1]) &&
                input.IndexOf(Exponent) > input.IndexOf(DecimalSeparator);
        }

        private static bool IsValidExponent(string input)
        {
            if (input.Length == 1 && !char.IsDigit(input[0]))
            {
                return false;
            }

            return ContainsOnlyDiggits(input) ||
                  ((input[0] == '+' || input[0] == '-') && ContainsOnlyDiggits(input.Substring(1)));
        }
    }
}
