using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Data
{


    //Observable
    
    public class Record
    {
        ITable Table;
        public event EventHandler RecordChanged;
       
       
        public Record(ITable table)
        {
            Table = table;
        }

        public object this[string field]
        {
            get
            {
                if (!Table.Fields.Contains(field))
                {
                    throw new Exception($"Record do not have field {field}");
                }
                return GetType().GetProperty(field).GetValue(this);
            }
            set
            {
                       RecordChanged?.Invoke(this, new EventArgs());
            }

        }

        public List<string> DataFields
        {
            get
            {
                var props = GetType().GetProperties();
                var dbs = props.Where((p)=> {
                     return p.GetCustomAttributes(typeof(ShiftDbData), false).Length > 0;
                });
                List<string> ret = new List<string>();
                foreach(var p in dbs)
                {
                    ret.Add(p.Name);
                }
                return ret;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (string fld in Table.Fields)
            {
                sb.Append($"{fld}: {this[fld]}\t");
            }
            return sb.ToString();
        }

    }
}
