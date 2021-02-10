using System;
using System.Collections.Generic;
using System.Text;

namespace JSONFormat
{
    public class Any : IPattern
    {
        private readonly string accepted;

        public Any(string accepted)
        {
            this.accepted = accepted;
        }

        public IMatch Match(string text)
        {
            throw new NotImplementedException();
        }
    }
}
