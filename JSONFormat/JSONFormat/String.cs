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

            this.pattern = new Sequence(quotes, quotes);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
