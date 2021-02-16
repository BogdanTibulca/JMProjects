using System;
using System.Collections.Generic;
using System.Text;

namespace JSONFormat
{
    public class Choice : IPattern
    {
        private readonly IPattern[] patterns;

        public Choice(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            foreach (var pattern in patterns)
            {
                IMatch result = pattern.Match(text);

                if (result.Success())
                {
                    return result;
                }
            }

            return new Match(false, text);
        }
    }
}
