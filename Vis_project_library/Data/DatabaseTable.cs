using Shift.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vis_project_library.Domain;

namespace Shift.Data
{


    //proxy, fasada, observer, observable
    public class DatabaseTable<T> : List<T>, ITable where T : Record// :DataProvider<T> where T : Record
    {
        private List<string> _fields = null;
        public event EventHandler Changed;

        public List<string> Fields
        {
            get { return _fields; }
            set { _fields = value; }
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
                                                // SELECT * FROM Employees WHERE name = @jmeno
                                                // param = new dictionery<string,object>{{"jmeno", "Lukas"}}
        public void Fill(Dictionary<String,Object> param = null)
        {
            IDataProvider<T> dataProvider = DataProviderFactory.GetDefaultDataProvider<T>();
            dataProvider.Fill(this, param);
            
            /*
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
            */
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
