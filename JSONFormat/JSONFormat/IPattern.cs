﻿using System;
using System.Collections.Generic;
using System.Text;

namespace JSONFormat
{
    public interface IPattern
    {
        public IMatch Match(string text);
    }
}
