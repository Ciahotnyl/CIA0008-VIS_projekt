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
        public string ForeignTableName { get; set; }

        public ReferenceData(string tablename, string foreignKey, string foreignTableName = "")
        {
            TableName = tablename;
            ForeignKey = foreignKey;
            ForeignTableName = foreignTableName;
        }
    }
}
