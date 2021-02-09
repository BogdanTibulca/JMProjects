using System;
using System.Collections.Generic;
using System.Text;

namespace JSONFormat
{
    public class Range : IPattern
    {
        private readonly char start;
        private readonly char end;

        public Range(char start, char end)
        {
            this.start = start;
            this.end = end;
        }

        public IMatch Match(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new Match(false, text);
            }

            bool success = text[0] >= start && text[0] <= end;
            string remainingText = success ? text.Substring(1) : text;

            return new Match(success, remainingText);
        }
    }
}
