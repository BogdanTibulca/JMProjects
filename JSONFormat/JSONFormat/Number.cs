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
            var digit = new Range('0', '9');
            var digits = new OneOrMore(digit);
            var negative = new Character('-');

            var integer = new Sequence(
                new Optional(negative),
                new Choice(new Character('0'), digits));

            var fraction = new Sequence(
                new Character('.'),
                digits);

            var exponent = new Sequence(
                new Any("eE"),
                new Optional(new Any("+-")),
                digits);

            this.pattern = new Sequence(integer, new Optional(fraction), new Optional(exponent));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
