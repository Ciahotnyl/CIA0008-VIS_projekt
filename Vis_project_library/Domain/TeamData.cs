using Shift.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vis_project_library.Domain
{
    public class TeamData
    {
        public static DatabaseTable<Teams> getTeams(Dictionary<String, Object> param)
        {
            DatabaseTable<Teams> Team = new DatabaseTable<Teams>();

            Team.Fill(param);
            return Team;
        }
    }
}
