using System;
using System.Collections.Generic;
using System.Text;

namespace JSONFormat
{
    public interface IMatch
    {
        public bool Success();

        public string RemainingText();
    }
}
