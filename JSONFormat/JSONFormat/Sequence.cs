using System;
using System.Collections.Generic;
using System.Text;

namespace JSONFormat
{
    public class Sequence : IPattern
    {
        private readonly IPattern[] patterns;

        public Sequence(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new Match(false, text);
            }

            string originalText = text;

            foreach (IPattern pattern in this.patterns)
            {
                if (!pattern.Match(text).Success())
                {
                    return new Match(false, originalText);
                }

                text = pattern.Match(text).RemainingText();
            }

            return new Match(true, text);
        }
    }
}