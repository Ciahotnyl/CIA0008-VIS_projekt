﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIS_projekt.Data
{
    public interface ITable
    {
        List<string> Fields { get; }
    }
}
