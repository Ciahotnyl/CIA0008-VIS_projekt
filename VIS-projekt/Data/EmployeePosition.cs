using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIS_projekt.Data
{
    class EmployeePosition : Record
    {
        public EmployeePosition(ITable table) : base(table)
        {

        }
        public int ID_position { get; set; }
        public int ID_employee { get; set; }
    }
}
