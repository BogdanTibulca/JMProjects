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
            Sequence sequence = new Sequence(element, new Many(new Sequence(separator, element)));

            this.pattern = new Optional(sequence);
        }

        public IMatch Match(string text)
        {
            return this.pattern.Match(text);
        }
    }
}
