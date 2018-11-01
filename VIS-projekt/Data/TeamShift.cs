using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIS_projekt.Data
{
    class TeamShift : Record
    {
        public TeamShift(ITable table) : base(table)
        {

        }
        public int ID_employee { get; set; }
        public int ID_team { get; set; }
        public int ID_workplace { get; set; }
        public int ID_position { get; set; }
        public int ID_shift { get; set; }
        public DateTime Date_of_work { get; set; }
    }
}
