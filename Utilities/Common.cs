using System;
using System.Data; 
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Utilities
{
    public static class Common
    {
        public static List<T> ConvertJSONToList<T>(string json)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();
            List<T> objects = new List<T>();

            JObject content = JObject.Parse(json);

            var errors = new List<string>();

            foreach (var fregment in content)
            {
                obj = JsonConvert.DeserializeObject<T>(fregment.Value.ToString(), new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Include,
                    Error = delegate (object sender, Newtonsoft.Json.Serialization.ErrorEventArgs earg)
                    {
                        errors.Add(earg.ErrorContext.Member.ToString());
                        earg.ErrorContext.Handled = true;
                    }
                });
                foreach(PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name.ToUpper() == "ID")
                    {
                        pro.SetValue(obj, fregment.Key.ToString());
                        break; 
                    }
                }
                objects.Add(obj);
            }
            return objects;
        }

        public static List<T> ConvertDataTableToList<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data; 
        }

        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            string columnName = string.Empty;

            foreach(PropertyInfo pro in temp.GetProperties())
            {
                for(int i=0; i< dr.Table.Columns.Count; i++)
                {
                    columnName = dr.Table.Rows[0][i].ToString();

                    if (pro.Name == columnName)
                    {
                        pro.SetValue(obj, dr[i], null);
                    }
                    else
                        continue; 
                }
            }

            //foreach (DataColumn column in dr.Table.Columns)
            //{
            //    foreach (PropertyInfo pro in temp.GetProperties())
            //    {
            //        if (pro.Name == column.ColumnName)
            //            pro.SetValue(obj, dr[column.ColumnName], null);
            //        else
            //            continue;
            //    }
            //}
            return obj;
        }
    }
}
