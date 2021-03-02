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
            this.pattern = new Choice(
                new Text("null"),
                new Text("true"),
                new Text("false"));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
