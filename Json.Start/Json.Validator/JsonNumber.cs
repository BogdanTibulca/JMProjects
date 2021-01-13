using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            return char.IsDigit(input[0]);
        }
    }
}
