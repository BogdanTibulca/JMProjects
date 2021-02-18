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
            IPattern exponent = new Any("eE");

            IPattern integerNumber = new OneOrMore(numbersRange);

            IPattern exponentialNumber = new Sequence(
                integerNumber,
                new Optional(new Sequence(new Character('.'), integerNumber)),
                new Optional(new Sequence(exponent, integerNumber)));

            this.pattern = new Sequence(exponentialNumber);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
