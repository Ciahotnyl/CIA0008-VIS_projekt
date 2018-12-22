using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Data
{
    class EmployeePosition : Record
    {
        public EmployeePosition(ITable table) : base(table)
        {

        }
        [ShiftDbData]
        public int ID_position { get; set; }
        [ShiftDbData]
        public int ID_employee { get; set; }
    }
}
