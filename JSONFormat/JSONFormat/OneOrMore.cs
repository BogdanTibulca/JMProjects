using System;
using System.Collections.Generic;
using System.Text;

namespace JSONFormat
{
    public class OneOrMore : IPattern
    {
        private readonly IPattern pattern;

        public OneOrMore(IPattern pattern)
        {
            this.pattern = new Many(pattern);
        }

        public IMatch Match(string text)
        {
            IMatch result = this.pattern.Match(text);

            return string.IsNullOrEmpty(text) || result.RemainingText().Equals(text) ?
                new Match(false, text) :
                new Match(true, result.RemainingText());
        }
    }
}
