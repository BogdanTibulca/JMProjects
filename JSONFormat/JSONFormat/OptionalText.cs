using System;
using System.Collections.Generic;
using System.Text;

namespace JSONFormat
{
    public class OptionalText : IPattern
    {
        private readonly IPattern pattern;

        public OptionalText(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            return new Match(true, this.pattern.Match(text).RemainingText());
        }
    }
}
