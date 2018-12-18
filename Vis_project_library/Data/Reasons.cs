using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Data
{
    class Reasons : Record
    {
        public Reasons(ITable table) : base(table)
        {

        }
        public int ID_reason { get; set; }
        public string Name_of_reason { get; set; }
       
    }
}
