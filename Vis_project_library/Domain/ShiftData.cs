using Shift.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vis_project_library.Domain
{
    public class ShiftData
    {
        public static DatabaseTable<Shifts> getShifts(Dictionary<String, Object> param)
        {
            DatabaseTable<Shifts> Shift = new DatabaseTable<Shifts>();

            Shift.Fill(param);
            return Shift;
        }
    }
}
