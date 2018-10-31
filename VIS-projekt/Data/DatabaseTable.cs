using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VIS_projekt.Data
{
    //proxy, fasada, observer, observable
    class DatabaseTable<T> : List<T>, ITable where T : Record
    {
        private List<string> _fields = null;
        public event EventHandler Changed;

        public List<string> Fields
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
            Changed?.Invoke(this, new EventArgs());
            return record;
        }

        public void Fill()
        {
            string sql = $"SELECT * FROM {TableName}";
            using (SqlConnection conn = new SqlConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
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
    }
}
