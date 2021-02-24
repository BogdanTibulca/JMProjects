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
            var onenine = new Range('1', '9');
            var digit = new Choice(new Character('0'), new OneOrMore(onenine));
            var digits = new OneOrMore(digit);
            var negative = new Character('-');

            var integer = new Choice(
                new Sequence(digit),
                new Sequence(onenine, digits),
                new Sequence(negative, digit),
                new Sequence(negative, onenine, digits));

            var fraction = new Sequence(
                integer,
                new Character('.'),
                digits);

            var exponent = new Sequence(
                new Choice(fraction, integer),
                new Any("eE"),
                new Optional(new Any("+-")),
                digits);

            this.pattern = new Choice(exponent, fraction, integer);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
