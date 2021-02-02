using System;
using System.Collections.Generic;
using System.Text;

namespace JSONFormat
{
    interface IPattern
    {
        public bool Match(string text);
    }
}
