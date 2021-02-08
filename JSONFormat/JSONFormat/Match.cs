using System;
using System.Collections.Generic;
using System.Text;

namespace JSONFormat
{
    public class Match : IMatch
    {
        private readonly IPattern[] patterns;

        public Match(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public string RemainingText(string text)
        {
            throw new NotImplementedException();
        }

        public bool Success(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            for (int i = 0; i < this.patterns.Length; i++)
            {
                string textToCheck = text.Substring(i);

                if (!this.patterns[i].Match(textToCheck))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
