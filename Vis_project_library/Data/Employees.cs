using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Data
{
    public class Employees : Record
    {
        public Employees(ITable table) : base(table)
        {

        }
      
        [ShiftDbData]
        public int ID_employee { get; set; }
        
        [ShiftDbData]
        public int ID_shift { get; set; }
    
        [ShiftDbData]
        public string First_name { get; set; }

        [ShiftDbData]
        public string Last_name { get; set; }

        [ShiftDbData]
        public DateTime Birthday { get; set; }

        [ShiftDbData]
        public DateTime Start_date { get; set; }

        [ShiftDbData]
        public Boolean isAdmin { get; set; }

        [ShiftDbData]
        public string Employee_login { get; set; }

        [ShiftDbData]
        public string Employee_password { get; set; }

        [ShiftDbData]
        [ReferenceData("Shifts", "ID_shift")]
        public string Name_of_shift { get; set; }

        [ShiftDbData]
        [ReferenceData("Absences", "ID_employee")] 
        public int? ID_absence { get; set; }

        [ShiftDbData]
        [ReferenceData("EmployeePosition", "ID_employee")]
        public int ID_position { get; set; }

        [ShiftDbData]
        [ReferenceData("Positions", "ID_position", "EmployeePosition")]
        public string Name_of_position { get; set; }

        [ShiftDbData]
        [ReferenceData("EmployeeTeam", "ID_employee")]
        public int ID_team { get; set; }

        [ShiftDbData]
        [ReferenceData("Teams", "ID_team", "EmployeeTeam")]
        public string Name_of_team { get; set; }

        [ShiftDbData]
        [ReferenceData("Workplaces", "ID_workplace", "Teams")]
        public string Name_of_workplace { get; set; }



    }
}
