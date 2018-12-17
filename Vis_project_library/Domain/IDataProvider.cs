using Shift.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Domain
{
    public interface IDataProvider<T> /*: List<T>, ITable */where T : Record
    {
        //public abstract List<string> Fields { get; }
        void Fill(DatabaseTable<T> db, Dictionary<String, object> param = null);
        void Export(DatabaseTable<T> db);
    }

}
