using System;
using System.Collections.Generic;
using System.Text;

namespace JSONFormat
{
    public class Character : IPattern
    {
        readonly char pattern;

        public Character(char pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new Match(false, text);
            }

            bool success = text[0] == pattern;
            string remainingText = success ? text.Substring(1) : text;

            return new Match(success, remainingText);
        }
    }
}