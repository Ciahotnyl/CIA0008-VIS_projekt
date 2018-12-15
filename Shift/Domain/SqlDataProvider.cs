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
            //record.GetType()

            var props = typeof(T).GetProperties();

            string columns = "SELECT ";
            ArrayList arrayOfJoins = new ArrayList();
            string FirstTable = typeof(T).ToString().Substring(typeof(T).ToString().IndexOf('.') + 1);
            FirstTable = FirstTable.ToString().Substring(FirstTable.ToString().IndexOf('.') + 1);
            String NameOfJoined = "";
            String ForeignKey = "";
            Dictionary<string, string> Joining = new Dictionary<string, string>();

            foreach (var prop in props)
            {
                var CA = prop.GetCustomAttribute(typeof(ShiftData), false);
                if (CA != null)
                {
                    var refe = prop.GetCustomAttribute(typeof(ReferenceData), false);


                    if(refe == null)
                    {
                        string column = prop.Name;// .ToString().Substring(prop.ToString().IndexOf(' ') + 1);
                        columns += (FirstTable + "." + column + ", ");
                    }
                    else
                    {              
                        ReferenceData da = refe as ReferenceData;
                        if (da != null)
                        {
                            NameOfJoined = da.TableName;
                            ForeignKey = da.ForeignKey;
                            Joining.Add(da.TableName,da.ForeignKey);
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
                    columns += (" JOIN " + r.Key + " ON " + FirstTable + "." + r.Value + " = " + r.Key + "." + r.Value);
                }

            }
            sql = columns;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();


                //sql =$"SELECT * FROM {db.TableName}";



                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (param != null)
                    {
                        foreach (var par in param)
                        {
                            cmd.Parameters.AddWithValue(par.Key, par.Value);
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
                            //record.RecordChanged += Record_RecordChanged;
                            for (int i = 0; i < sr.FieldCount; i++)
                            {
                                object val = sr[i];
                                PropertyInfo prop = record.GetType().GetProperty(db.Fields[i]);

                                prop.SetValue(record, val, null);

                            }
                            db.Add(record);
                        }
                    }
                }
            }
        }
    }
}
