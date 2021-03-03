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

            var array = new Sequence(
                new Character('['),
                new List(
                    value,
                    new Character(',')),
                new Character(']'));

            var member = new Sequence(
                new Optional(whitespace),
                new String(),
                new Optional(whitespace),
                new Character(':'),
                value);

            var obj = new Sequence(
                new Character('{'),
                new List(member, new Character(',')),
                new Character('}'));

            choice.Add(obj);
            choice.Add(array);

            this.pattern = value;
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
