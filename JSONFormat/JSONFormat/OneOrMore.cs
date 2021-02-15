using System;
using System.Collections.Generic;
using System.Text;

namespace JSONFormat
{
    public class OneOrMore : IPattern
    {
        private readonly IPattern pattern;

        public OneOrMore(IPattern pattern)
        {
            this.pattern = new Many(pattern);
        }

        public IMatch Match(string text)
        {
            throw new NotImplementedException();
        }
    }
}
