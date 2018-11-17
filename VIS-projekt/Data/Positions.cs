using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIS_projekt.Data
{
    class Positions : Record
    {
        public Positions(ITable table) : base(table)
        {

        }
        public int ID_position { get; set; }
        public String Name_of_position { get; set; }
        public int Class { get; set; }
    }
}
