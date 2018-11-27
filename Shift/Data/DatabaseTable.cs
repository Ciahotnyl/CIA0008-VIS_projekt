using Shift.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Data
{
    // bude class factory a bude fungovat jako injection of control
    public abstract class DataProvider<T> : List<T>, ITable where T : Record
    {
        public abstract List<string> Fields { get; }
    }
    //proxy, fasada, observer, observable
    public class DatabaseTable<T> :DataProvider<T> where T : Record
    {
        private List<string> _fields = null;
        public event EventHandler Changed;

        public override List<string> Fields
        {
            get { return _fields; }
        }

        public DatabaseTable() : base()
        {
            //blabla
        }

        public T AddRecord()
        {
            T record = (T)Activator.CreateInstance(typeof(T), new object[] { this });
            this.Add(record);
            Changed?.Invoke(this, new EventArgs());
            return record;
        }
        public void Save()
        {
            foreach (var rec in this)
            {
                switch (rec.CURRENT_STATE)
                {
                    case Record.state.UNCHANGED:
                        break;
                }
            }
        }
                                                // SELECT * FROM Employees WHERE name = @jmeno
                                                // param = new dictionery<string,object>{{"jmeno", "Lukas"}}
        public void Fill(SqlConnection conn, string command = null, Dictionary<String, object> param = null)
        {
           string sql;
           if (command == null)
            {
                sql = $"SELECT * FROM {TableName}";
            }
           else
            {
                sql = command;
            }


            using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                if(param != null)
                {
                    foreach(var par in param)
                    {
                        cmd.Parameters.AddWithValue(par.Key, par.Value);
                    }
                }
                    using (SqlDataReader sr = cmd.ExecuteReader())
                    {
                        if (_fields == null)
                        {
                            _fields = new List<string>();
                            for (int i = 0; i < sr.FieldCount; i++)
                            {
                                _fields.Add(sr.GetName(i));
                            }
                        }

                        while (sr.Read())
                        {
                            T record = (T)Activator.CreateInstance(typeof(T), new object[] { this });
                            record.RecordChanged += Record_RecordChanged;
                            for (int i = 0; i < sr.FieldCount; i++)
                            {
                                object val = sr[i];
                                PropertyInfo prop = record.GetType().GetProperty(_fields[i]);

                                prop.SetValue(record, val, null);

                            }
                            this.Add(record);

                        }
                    }
                }
            
        }
        private void Record_RecordChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private string _tableName = null;

        public string TableName
        {
            get
            {
                if (_tableName == null)
                {
                    _tableName = typeof(T).Name;
                }
                return _tableName;
            }
        }

        //public override List<string> Fields { get { return null; } }
    }
}
