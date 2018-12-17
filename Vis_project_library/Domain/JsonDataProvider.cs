using Shift.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Shift.Domain
{
    public class JsonDataProvider<T> : IDataProvider<T> where T : Record
    {
        public void Export(DatabaseTable<T> db)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string dir = Path.Combine(path, "ShiftData");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
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

        public void Fill(DatabaseTable<T> db, Dictionary<string, object> param = null)
        {
            /*
            JavaScriptSerializer jss_load = new JavaScriptSerializer();
            
            var test = jss_load.DeserializeObject(temp2);
            */
        }
    }
}
