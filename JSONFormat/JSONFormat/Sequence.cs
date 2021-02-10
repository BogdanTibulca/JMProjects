using System;
using System.Collections.Generic;
using System.Text;

namespace JSONFormat
{
    public class Sequence : IPattern
    {
        private readonly IPattern[] patterns;

        public Sequence(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            throw new NotImplementedException();
        }
    }
}
