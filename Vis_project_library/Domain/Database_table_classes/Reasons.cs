using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Data
{
    public class Reasons : Record
    {
        public Reasons(ITable table) : base(table)
        {

        }
        [ShiftDbData]
        public int ID_reason { get; set; }

        [ShiftDbData]
        public string Name_of_reason { get; set; }
       
    }
}
