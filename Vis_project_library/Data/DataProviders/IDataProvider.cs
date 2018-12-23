using Shift.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Domain
{
    public interface IDataProvider<T> where T : Record
    {
        void Fill(DatabaseTable<T> db, Dictionary<String, object> param = null);
        void Export(DatabaseTable<T> db);
        void Save(Dictionary<String, object> param = null, DatabaseTable<T> db = null);
    }

}
