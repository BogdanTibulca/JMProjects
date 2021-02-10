using System;
using System.Collections.Generic;
using System.Text;

namespace JSONFormat
{
    public class Text : IPattern
    {
        private readonly string prefix;

        public Text(string prefix)
        {
            this.prefix = prefix;
        }

        public IMatch Match(string text)
        {
            throw new NotImplementedException();
        }
    }
}
