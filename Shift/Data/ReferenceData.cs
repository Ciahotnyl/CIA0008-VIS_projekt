using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Data
{
    public class ReferenceData : Attribute
    {
        public string TableName { get; set; }
        public string ForeignKey { get; set; }

        public ReferenceData(string tablename, string foreignKey)
        {
            TableName = tablename;
            ForeignKey = foreignKey;
        }
    }
}
