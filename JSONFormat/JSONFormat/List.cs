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

        }

        public IMatch Match(string text)
        {
            return this.pattern.Match(text);
        }
    }
}
