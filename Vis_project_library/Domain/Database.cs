using Shift.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
namespace Shift.Domain
{
    //builder - getTable, facada, proxy
    class Database
    {
        protected Database()
        {

        }
        private static Database _instance;

        //singleton
        public static Database Instance
        {
            get {
                if(_instance == null)
                {
                    _instance = new Database();
                }
                return _instance; }

       
        }
        
        Dictionary<Type, object> Tables = new Dictionary<Type, object>();
        public DatabaseTable<T> getTable<T>(Dictionary<String, Object> param) where T : Record, new()
        {
            if (Tables.ContainsKey(typeof(T)))
            {
                return Tables[typeof(T)] as DatabaseTable<T>;
            }
            var ret = new DatabaseTable<T>();

            Tables.Add(typeof(T), ret);
            return ret;
        }
        
         using (SqlConnection conn = new SqlConnection(Database.ConnectionString))
            {
                conn.Open();
            }
        

     //   public static string ConnectionString = @"server=dbsys.cs.vsb.cz\STUDENT;database=cia0008;user=cia0008;password=qkFGDEHrFz;";
    }
}
*/
