using System;
using System.Collections.Generic;
using System.Text;

namespace JSONFormat
{
    public class List : IPattern
    {
        private readonly IPattern pattern;

        public List(IPattern element, IPattern separator)
        {
            Sequence sequence = new Sequence(
                new OneOrMore(element),
                new Many(new Sequence(separator, new OneOrMore(element))));

            this.pattern = new Many(sequence);
        }

        public IMatch Match(string text)
        {
            return this.pattern.Match(text);
        }
    }
}
