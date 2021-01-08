using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            const char Quotes = '\"';

            return input[0] == Quotes && input[^1] == Quotes;
        }
    }
}
