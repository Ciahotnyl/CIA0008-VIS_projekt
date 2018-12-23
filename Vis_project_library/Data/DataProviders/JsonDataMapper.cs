using Newtonsoft.Json;
using Shift.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Vis_project_library.Domain;

namespace Shift.Domain
{
    public class JsonDataMapper<T> : IDataProvider<T> where T : Record
    {

        static Dictionary<String, object> tables = new Dictionary<string, object>();
        public void Export(DatabaseTable<T> db)
        {

            string dir = "";
            if (DataProviderFactory.settings.Count != 0)
            {
                dir = DataProviderFactory.settings["path"].ToString();
            }
            else
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                dir = Path.Combine(path, "ShiftData");
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
            }
            
            string fileName = Path.Combine(dir, db.TableName+".json");
            string fileNameTmp = Path.Combine(dir, db.TableName+"Tmp.json");
            Dictionary<string, Object> table = new Dictionary<string, object>();
            using (StreamWriter sw = new StreamWriter(fileNameTmp))
            {
                
                table.Add("TableName", db.TableName);
                ArrayList records = new ArrayList();
                table.Add("Records", records);
                foreach (Record rec in db)
                {
                    Dictionary<string, Object> record = new Dictionary<string, object>();
                    foreach(string field in db.Fields)
                    {
                        record.Add(field, rec[field]);

                    }
                    records.Add(record);
                }
                
                JavaScriptSerializer jss = new JavaScriptSerializer();
                string temp = jss.Serialize(table);
                sw.Write(temp);
            }
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            File.Move(fileNameTmp, fileName);


        }

        protected void fillAllTables()
        {
            tables.Clear();
            foreach (Type t in DataProviderFactory.tables)
            {
                    Type dt = typeof(DatabaseTable<>).MakeGenericType(t);

                    Type jp = typeof(JsonDataMapper<>).MakeGenericType(t);
                    Type sp = typeof(SqlDataMapper<>).MakeGenericType(t);

                    object oo = Activator.CreateInstance(dt);

                    dynamic ins = oo;
            
                    dynamic jprov = Activator.CreateInstance(jp);

                   jprov.fillInner(ins);
                tables.Add(t.Name, ins);
            }
        }

        internal void fillInner(DatabaseTable<T> db)
        {
            db.Clear();
            DatabaseTable<Shifts> shift = new DatabaseTable<Shifts>();
            string path = "";
            string fileName = "";
            if (DataProviderFactory.settings.Count != 0)
            {
                path = DataProviderFactory.settings["path"].ToString();
                fileName = Path.Combine(path, db.TableName + ".json");
            }
            else
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string dir = Path.Combine(path, "ShiftData");
                fileName = Path.Combine(dir, db.TableName + ".json");
            }

            using (StreamReader r = new StreamReader(fileName))
            {
                string json = r.ReadToEnd();
                JavaScriptSerializer jss = new JavaScriptSerializer();
                Dictionary<string, Object> table = jss.Deserialize<Dictionary<string, Object>>(json);
                string tableName = table["TableName"] as string;
                ArrayList records = table["Records"] as ArrayList;
                List<string> flds = null;
                foreach (Dictionary<string, object> rec in records)
                {
                    T record = (T)Activator.CreateInstance(typeof(T), new object[] { db });
                    if (flds == null)
                    {
                        flds = record.DataFields;
                    }
                    db.Fields = flds;
                    for (int i = 0; i < flds.Count; i++)
                    {
                        object val = rec[flds[i]];
                        PropertyInfo prop = record.GetType().GetProperty(flds[i]);
                        prop.SetValue(record, (val), null);
                    }

                    db.Add(record);
                }

            }
        }

        public void Fill(DatabaseTable<T> db, Dictionary<string, object> param = null)
        {

            if (tables.Count == 0)
            {
                fillAllTables();
            }
            db.Clear();
            DatabaseTable<T> tab = tables[db.TableName] as DatabaseTable<T>;

            IEnumerable<T> res = null;
            if (param != null)
            {
                foreach (var p in param)
                {
                    res = tab.Where((r) => { return r[p.Key].Equals(p.Value == null ? 0 : p.Value) ; });
                }
            }
            else
            {
                res = tab;
            }
            foreach (var r in res)
            {
                db.Add(r);
            }
        }

        public void Save(Dictionary<string, object> param = null, DatabaseTable<T> db = null)
        {
            string FirstTable = typeof(T).Name;
            if(tables.Count() == 0)
            {
                fillAllTables();
            }
            string key = ("ID_" + FirstTable.Substring(0, FirstTable.Length - 1)).ToLower();
            DatabaseTable<T> tab = tables[typeof(T).Name] as DatabaseTable<T>;

            object id = param.FirstOrDefault((p)=> {
                return p.Key.ToLower() == key;
            }).Value;

            var rr = tab.FirstOrDefault((r) => { return r[key].Equals(id); });

            foreach (var p in param)
            {
                if (p.Key.ToLower() != key)
                {
                    rr[p.Key] = p.Value;
                }
            }
            Export(tab);
        }
    }
}
