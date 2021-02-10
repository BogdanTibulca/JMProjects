using System;
using System.Collections.Generic;
using System.Text;

namespace JSONFormat
{
    public class Many : IPattern
    {
        private readonly IPattern pattern;

        public Many(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            throw new NotImplementedException();
        }
    }
}
