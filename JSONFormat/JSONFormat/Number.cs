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
            IPattern negative = new Character('-');
            IPattern integerNumber = new OneOrMore(numbersRange);

            IPattern exponent = new Sequence(new Any("eE"), new Optional(negative));
            IPattern exponentialNumber = new Sequence(new Optional(integerNumber), exponent, integerNumber);

            IPattern decimalNumber = new Sequence(
                    new Optional(new Character('.')),
                    new Optional(exponent),
                    integerNumber);

            IPattern number = new Sequence(
                new Optional(negative),
                integerNumber,
                new Optional(decimalNumber),
                new Optional(exponentialNumber));

            this.pattern = new Sequence(number);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
