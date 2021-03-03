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
            var whitespace = new OneOrMore(new Any("\r\t\n "));

            var choice = new Choice(
                    new String(),
                    new Number(),
                    new Text("true"),
                    new Text("false"),
                    new Text("null"));

            var value = new Sequence(
                new Optional(whitespace),
                choice,
                new Optional(whitespace));

            var elements = new List(
                value,
                new Character(','));

            var array = new Sequence(
                new Character('['),
                new Choice(whitespace, elements),
                new Character(']'));

            choice.Add(array);

            this.pattern = value;
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
