using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Data
{
    public class Absences : Record
    {
        public Absences(ITable table) : base(table)
        {

        }
        [ShiftDbData]
        public int ID_absence { get; set; }
        [ShiftDbData]
        public int ID_reason { get; set; }
        [ShiftDbData]
        public int ID_employee { get; set; }
        [ShiftDbData]
        public DateTime From { get; set; }
        [ShiftDbData]
        public DateTime To { get; set; }

    }
}
