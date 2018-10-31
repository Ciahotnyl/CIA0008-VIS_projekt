using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIS_projekt.Data
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
                //TODO
                RecordChanged?.Invoke(this, new EventArgs());
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
