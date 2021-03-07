using System;
using System.Collections.Generic;
using System.Text;

namespace JSONFormat
{
    public class DateTime : IPattern
    {

        private readonly IPattern pattern;

        public DateTime()
        {
           
        }

        public IMatch Match(string text)
        {
            return this.pattern.Match(text);
        }
    }
}
