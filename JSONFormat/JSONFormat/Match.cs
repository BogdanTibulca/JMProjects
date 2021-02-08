using System;
using System.Collections.Generic;
using System.Text;

namespace JSONFormat
{
    public class Match : IMatch
    {
        private readonly IPattern patterns;

        public Match(IPattern patterns)
        {
            this.patterns = patterns;
        }

        public string RemainingText(string text)
        {
            if (text is null)
            {
                return null;
            }

            return !Success(text) ? text : text.Substring(1);
        }

        public bool Success(string text)
        {
            return this.patterns.Match(text);
        }
    }
}
