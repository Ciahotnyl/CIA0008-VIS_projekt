using Shift.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vis_project_library.Domain
{
    public class WorkplaceData
    {
        public static DatabaseTable<Workplaces> getWorkplaces(Dictionary<String, Object> param)
        {
            DatabaseTable<Workplaces> workplace = new DatabaseTable<Workplaces>();

            workplace.Fill(param);
            return workplace;
        }
    }
}
