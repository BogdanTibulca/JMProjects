using System;
using System.Collections.Generic;
using System.Text;

namespace JSONFormat
{
    public class Number : IPattern
    {
        private readonly IPattern pattern;

        public Number()
        {

        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
