using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Data
{
    class Workplaces : Record
    {
        public Workplaces(ITable table) : base(table)
        {

        }
        public int ID_workplace { get; set; }
        public int ID_superior_workplace { get; set; }
        public string Name_of_workplace { get; set; }
    }
}
