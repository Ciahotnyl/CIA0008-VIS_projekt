using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Data
{
    public class Teams : Record
    {
        public Teams(ITable table) : base(table)
        {

        }
        [ShiftDbData]
        public int ID_team { get; set; }
        [ShiftDbData]
        public int ID_workplace { get; set; }
        [ShiftDbData]
        public int ID_position { get; set; }
        [ShiftDbData]
        public string Name_of_team { get; set; }
    }
}
