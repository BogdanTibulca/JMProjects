﻿using System;
using System.Collections.Generic;
using System.Text;

namespace JSONFormat
{
    interface IMatch
    {
        bool Success(string text);

        string RemainingText(string text);
    }
}
