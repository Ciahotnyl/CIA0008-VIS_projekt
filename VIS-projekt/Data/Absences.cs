using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIS_projekt.Data
{
    class Absences : Record
    {
        public Absences(ITable table) : base(table)
        {

        }
        public int ID_absence { get; set; }
        public int ID_reason { get; set; }
        public int ID_employee { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

    }
}
