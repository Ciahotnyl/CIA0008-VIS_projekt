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
        public static IDataProvider<T> GetDefaultDataProvider<T>() where T: Record
        {
            return new SqlDataProvider<T>();
        }
       
    }
}
