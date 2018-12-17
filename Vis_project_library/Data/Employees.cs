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
      
        [ShiftData]
        public int ID_employee { get; set; }
        
        [ShiftData]
        public int ID_shift { get; set; }
    
        [ShiftData]
        public string First_name { get; set; }

        [ShiftData]
        public string Last_name { get; set; }

        [ShiftData]
        public DateTime Birthday { get; set; }

        [ShiftData]
        public DateTime Start_date { get; set; }

        [ShiftData]
        public Boolean isAdmin { get; set; }

        [ShiftData]
        public string Employee_login { get; set; }

        [ShiftData]
        public string Employee_password { get; set; }

        [ShiftData]
        [ReferenceData("Shifts", "ID_shift")]
        public string Name_of_shift { get; set; }

        [ShiftData]
        [ReferenceData("Absences", "ID_employee")] 
        public int? ID_absence { get; set; }

        [ShiftData]
        [ReferenceData("EmployeePosition", "ID_employee")]
        public int ID_position { get; set; }

        [ShiftData]
        [ReferenceData("Positions", "ID_position", "EmployeePosition")]
        public string Name_of_position { get; set; }

        [ShiftData]
        [ReferenceData("Teams", "ID_position", "Positions")]
        public int ID_team { get; set; }

        [ShiftData]
        [ReferenceData("Workplaces", "ID_workplace", "Teams")]
        public string Name_of_workplace { get; set; }



    }
}
