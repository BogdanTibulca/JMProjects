using System;
using System.Collections.Generic;
using System.Text;

namespace JSONFormat
{
    public class Many : IPattern
    {
        private readonly IPattern pattern;

        public Many(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            IMatch result = pattern.Match(text);

            while (result.Success())
            {
                result = pattern.Match(result.RemainingText());
            }

            return new Match(true, result.RemainingText());
        }
    }
}
