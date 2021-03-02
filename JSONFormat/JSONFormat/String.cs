using System;
using System.Collections.Generic;
using System.Text;

namespace JSONFormat
{
    public class String : IPattern
    {
        private readonly IPattern pattern;

        public String()
        {
            var quotes = new Character('"');
            var hex = new Choice(new Range('A', 'F'), new Range('a', 'f'), new Range('0', '9'));

            var escaped = new Sequence(
                new Character('\\'),
                new Choice(
                    new Any("\"\\/bfnrt"),
                    new Sequence(new Character('u'), hex, hex, hex, hex)));

            var character = new Choice(
                new Character('\u0020'),
                new Character('\u0021'),
                new Range('\u0023', '\u005B'),
                new Range('\u005D', char.MaxValue),
                escaped);

            this.pattern = new Sequence(quotes, new OneOrMore(character), quotes);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
