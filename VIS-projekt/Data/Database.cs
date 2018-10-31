using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIS_projekt.Data
{
    //builder - getTable, fasada, proxy
    class Database
    {
        Dictionary<Type, object> Tables = new Dictionary<Type, object>();
        public DatabaseTable<T> getTable<T>() where T : Record, new()
        {
            if (Tables.ContainsKey(typeof(T)))
            {
                return Tables[typeof(T)] as DatabaseTable<T>;
            }
            var ret = new DatabaseTable<T>();

            Tables.Add(typeof(T), ret);
            return ret;
        }

        public static string ConnectionString = @"server=dbsys.cs.vsb.cz\STUDENT;database=cia0008;user=cia0008;password=qkFGDEHrFz;";
    }
}
