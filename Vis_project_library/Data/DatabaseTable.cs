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
    public class DatabaseTable<T> : List<T>, ITable where T : Record
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
        }



        public T AddRecord()
        {
            T record = (T)Activator.CreateInstance(typeof(T), new object[] { this });
            this.Add(record);
            Changed?.Invoke(this, new EventArgs());
            return record;
        }

        public void Fill(Dictionary<String,Object> param = null)
        {
            IDataProvider<T> dataProvider = DataProviderFactory.GetDefaultDataProvider<T>();
            dataProvider.Fill(this, param);         
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
