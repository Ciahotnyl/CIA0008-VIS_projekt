using Shift.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vis_project_library.Domain
{
    public class EmployeeTeamData
    {
        public static DatabaseTable<EmployeeTeam> getEmployeeTeam(Dictionary<String, Object> param)
        {
            DatabaseTable<EmployeeTeam> employee = new DatabaseTable<EmployeeTeam>();

            employee.Fill(param);
            return employee;
        }
    }
}
