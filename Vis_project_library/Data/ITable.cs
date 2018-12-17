using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Data
{
    public interface ITable
    {
        List<string> Fields { get; }
    }
}
