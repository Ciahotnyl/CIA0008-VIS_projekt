using Shift.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Domain
{
    public class SqlDataProvider<T> : IDataProvider<T> where T : Record
    {

        public static string ConnectionString = @"server=dbsys.cs.vsb.cz\STUDENT;database=cia0008;user=cia0008;password=qkFGDEHrFz;";

        public void Export(DatabaseTable<T> db)
        {
            throw new NotImplementedException();
        }

        public void Fill(DatabaseTable<T> db, Dictionary<string, object> param = null)
        {
            string sql;

            var props = typeof(T).GetProperties();

            string columns = "SELECT ";
            ArrayList arrayOfJoins = new ArrayList();
            string FirstTable = typeof(T).ToString().Substring(typeof(T).ToString().IndexOf('.') + 1);
            FirstTable = FirstTable.ToString().Substring(FirstTable.ToString().IndexOf('.') + 1);
            String NameOfJoined = "";
            String ForeignKey = "";
            String ForeignTableName = "";
            List<Tuple<String, String, String>> Joining = new List<Tuple<string, string, string>>();

            foreach (var prop in props)
            {
                var CA = prop.GetCustomAttribute(typeof(ShiftDbData), false);
                if (CA != null)
                {
                    var refe = prop.GetCustomAttribute(typeof(ReferenceData), false);


                    if(refe == null)
                    {
                        string column = prop.Name;
                        columns += (FirstTable + "." + column + ", ");
                    }
                    else
                    {              
                        ReferenceData da = refe as ReferenceData;
                        if (da != null)
                        {
                            NameOfJoined = da.TableName;
                            ForeignKey = da.ForeignKey;
                            ForeignTableName = da.ForeignTableName;
                            Joining.Add(new Tuple<String, String, String>(da.TableName,da.ForeignKey, da.ForeignTableName));
                        }
                        string joinedColumn = prop.ToString().Substring(prop.ToString().IndexOf(' ') + 1);
                        columns += (NameOfJoined+ "." +joinedColumn + ", ");
                        arrayOfJoins.Add(joinedColumn);
                    }
                }         
            }
            columns = columns.Substring(0,columns.Length - 2);
            columns += (" FROM " + FirstTable);
            if (arrayOfJoins != null)
            {
                foreach (var r in Joining)
                {
                    columns += (" LEFT OUTER JOIN " + r.Item1 + " ON " + r.Item1 + "." + r.Item2 + " = " + (r.Item3 == "" ? FirstTable : r.Item3) + "." + r.Item2);
                }

            }
            if (param != null && param.Count >= 1)
            {
                columns += " WHERE ";
                foreach (var p in param)
                {
                    if(p.Value == null)
                    {
                        columns +=  p.Key + " is null ";
                    }
                    else
                    {
                        columns +=  p.Key + " = @" + p.Key.Split(".".ToCharArray()).Last();
                    }
                    //columns += FirstTable+"." + p.Key + " = @" + p.Key.Split(".".ToCharArray()).Last() + ", ";
                }
                //columns = columns.Substring(0, columns.Length - 2);
            }
            sql = columns;
            using ( SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (param != null)
                    {
                        foreach (var par in param)
                        {
                            if(par.Value != null)
                            {
                                cmd.Parameters.AddWithValue(par.Key.Split(".".ToCharArray()).Last(), par.Value);
                            }
                        }
                    }
                    using (SqlDataReader sr = cmd.ExecuteReader())
                    {

                        if (db.Fields == null)
                        {
                            db.Fields = new List<string>();
                            for (int i = 0; i < sr.FieldCount; i++)
                            {
                                db.Fields.Add(sr.GetName(i));
                            }
                        }

                        while (sr.Read())
                        {
                            T record = (T)Activator.CreateInstance(typeof(T), new object[] { db });
                            for (int i = 0; i < sr.FieldCount; i++)
                            {
                                object val = sr[i];
                                PropertyInfo prop = record.GetType().GetProperty(db.Fields[i]);
                                prop.SetValue(record, (val==DBNull.Value?null:val), null);
                        

                            }
                            db.Add(record);
                        }
                    }
                }
            }
        }

        public void Save(Dictionary<string, object> param = null)
        {
            string sql;
            string FirstTable = typeof(T).Name;
            string key = ("ID_" + FirstTable.Substring(0, FirstTable.Length - 1)).ToLower();
            var props = typeof(T).GetProperties();
            string column = "UPDATE " + FirstTable + " SET ";
            foreach (var p in param)
            {

                if (p.Key.ToLower() != key)
                {
                    column += p.Key + " = @" + p.Key + ", ";
                }

            }
            column = column.Substring(0, column.Length - 2);
            column += " WHERE " + key + " = @" + key;
            sql = column;
            int ret = 0;

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                SqlCommand command = new SqlCommand(sql, conn);
                foreach (var p in param) 
                {
                    command.Parameters.AddWithValue(p.Key, p.Value);
                }

                ret = command.ExecuteNonQuery();
            }
        }
    }
}
