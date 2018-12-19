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
        public int ID_position { get; set; }
        public int ID_employee { get; set; }
    }
}
