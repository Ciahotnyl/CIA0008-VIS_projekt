using Shift.Data;
using Shift.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vis_project_library.Domain
{
    public class DataProviderFactory
    {
        protected static string typeProvider = "SQL";
        public static Dictionary<String, Object> settings = new Dictionary<string, object>();
        public static IDataProvider<T> GetDefaultDataProvider<T>() where T: Record
        {
            switch (typeProvider)
            {
                case "SQL":
                    return new SqlDataProvider<T>();
                case "JSON":
                    return new JsonDataProvider<T>();
                default:
                    return new SqlDataProvider<T>();
            }

        }
       public static void SetDefaultDataProvider(string provider)
        {
            typeProvider = provider;
        }
        public static Type[] tables = new Type[]{
                typeof(Employees),
                typeof(Positions),
                typeof(EmployeeTeam),
                typeof(Shifts),
                typeof(Teams),
                typeof(Workplaces)

            };
    }
}
