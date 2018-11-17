using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VIS_projekt.Data
{
    class Employees : Record
    {
        public Employees(ITable table) : base(table)
        {

        }
      
        public int ID_employee { get; set; }
        public int ID_shift { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime Start_date { get; set; }
        
    }
}
