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

        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
