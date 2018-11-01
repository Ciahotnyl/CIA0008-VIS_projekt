using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIS_projekt.Data
{
    class Teams : Record
    {
        public Teams(ITable table) : base(table)
        {

        }
        public int ID_team { get; set; }
        public int ID_workplace { get; set; }
        public int ID_position { get; set; }
        public string Name_of_team { get; set; }
    }
}
