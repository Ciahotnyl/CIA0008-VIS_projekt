using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Data
{
    public class Positions : Record
    {
        public Positions(ITable table) : base(table)
        {

        }
        [ShiftDbData]
        public int ID_position { get; set; }
        [ShiftDbData]
        public String Name_of_position { get; set; }
    }
}
