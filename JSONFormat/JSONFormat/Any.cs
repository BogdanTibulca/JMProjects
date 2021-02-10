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
            if (string.IsNullOrEmpty(text))
            {
                return new Match(false, text);
            }

            return accepted.Contains(text[0]) ?
                new Match(true, text.Substring(1)) :
                new Match(false, text);
        }
    }
}