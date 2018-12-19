using Shift.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vis_project_library
{
    public class EmployeeTeam :Record
    {
        public EmployeeTeam(ITable table) : base(table)
        {

        }

        [ShiftDbData]
        public int ID_employee_team { get; set; }
        [ShiftDbData]
        public int ID_employee { get; set; }
        [ShiftDbData]
        public int ID_team { get; set; }

    }
}
