using System;
using System.Collections.Generic;
using System.Text;

namespace JSONFormat
{
    public class Number : IPattern
    {
        private readonly IPattern pattern;
        private readonly IPattern numbersRange = new Range('0', '9');

        public Number()
        {
            this.pattern = new OneOrMore(numbersRange);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
