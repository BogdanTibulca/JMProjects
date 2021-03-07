using System;
using System.Collections.Generic;
using System.Text;

namespace JSONFormat
{
    public class DateTime : IPattern
    {
        private readonly IPattern pattern;

        public DateTime()
        {
            var dateSeparator = new Character('-');
            var timeSeparator = new Character(':');
            var digit = new Range('0', '9');

            var year = new Sequence(digit, digit, digit, digit);
            var twoDigits = new Sequence(digit, digit);

            var date = new Sequence(
                year,
                dateSeparator,
                twoDigits,
                dateSeparator,
                twoDigits);

            var time = new Sequence(
                new Character('T'),
                twoDigits,
                timeSeparator,
                twoDigits,
                timeSeparator,
                twoDigits,
                new Optional(new Sequence(new Character('.'), new OneOrMore(digit))));

            var timeZoneDesignator = new Choice(
                new Character('Z'),
                new Sequence(
                    new Choice(new Character('+'), new Character('-')),
                    twoDigits,
                    timeSeparator,
                    twoDigits));

            this.pattern = new Sequence(date, time, timeZoneDesignator);
        }

        public IMatch Match(string text)
        {
            return this.pattern.Match(text);
        }
    }
}
