using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Data
{
    public class Shifts : Record
    {
        

        public Shifts(ITable table) : base(table)
        {

        }

        [ShiftDbData]
        public int ID_shift { get; set; }

        [ShiftDbData]
        public string Name_of_shift { get; set; }
    }
}
