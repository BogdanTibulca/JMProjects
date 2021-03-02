using System;
using System.Collections.Generic;
using System.Text;

namespace JSONFormat
{
    public class Value : IPattern
    {
        private readonly IPattern pattern;

        public Value()
        {

        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
