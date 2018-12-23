using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Data
{
    public class Workplaces : Record
    {
        public Workplaces(ITable table) : base(table)
        {

        }
        [ShiftDbData]
        public int ID_workplace { get; set; }

        [ShiftDbData]
        public int ID_superior_workplace { get; set; }

        [ShiftDbData]
        public string Name_of_workplace { get; set; }
    }
}
