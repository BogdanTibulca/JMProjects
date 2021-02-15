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
            string originalText = text;

            foreach (IPattern pattern in this.patterns)
            {
                IMatch result = pattern.Match(originalText);

                if (!result.Success())
                {
                    return new Match(false, text);
                }

                originalText = result.RemainingText();
            }

            return new Match(true, originalText);
        }
    }
}