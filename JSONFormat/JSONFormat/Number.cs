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
            IPattern numbersRange = new Range('0', '9');
            IPattern integerNumber = new OneOrMore(numbersRange);
            IPattern decimalNumber = new Sequence(
                integerNumber,
                new Optional(new Sequence(new Character('.'), integerNumber)));

            this.pattern = new Choice(decimalNumber);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
