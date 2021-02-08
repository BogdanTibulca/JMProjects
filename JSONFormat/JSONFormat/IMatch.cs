using System;
using System.Collections.Generic;
using System.Text;

namespace JSONFormat
{
    public interface IMatch
    {
        public bool Success(string text);

        public string RemainingText(string text);
    }
}
