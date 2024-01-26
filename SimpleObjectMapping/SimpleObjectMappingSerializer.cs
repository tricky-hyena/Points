using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace SimpleObjectMapping
{
    public class SimpleObjectMappingSerializer
    {
        private static string Serialize(object data)
        {
            var dataType = data.GetType();

            var properties = new List<PropertyInfo>(dataType.GetProperties());

            string result = "";

            result += $"{dataType.AssemblyQualifiedName}\n";

            foreach (var property in properties)
            {
                var propertyValue = property.GetValue(data, null);

                result += $"{property.Name}={propertyValue}\n";
            }

            return result;
        }

        private static object Deserialize(string str)
        {
            object obj = null;

            using (var reader = new StringReader(str))
            {
                reader.ReadLine();
                string first = reader.ReadLine();

                obj = GetInstance(first);

                var typ = obj.GetType();

                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    if (line == "") break;
                    var nameval = line.Split('=');
                    string name = nameval[0];
                    string val = nameval[1];

                    var prop = typ.GetProperty(name);

                    prop.SetValue(obj, Convert.ChangeType(val, prop.PropertyType));
                }
            }
            
            return obj;
        }

        public static object[] DeserializeArray(string str)
        {
            var splitted = str.Split(';');

            var length = Convert.ToInt32(splitted[0]);

            object[] objects = new object[length];

            for (int i = 1; i <= length; i++)
            {
                objects[i - 1] = Deserialize(splitted[i]);
            }

            return objects;
        }

        public static string Serialize(object[] datas)
        {
            string result = "";

            result += $"{datas.Length}\n;\n";

            foreach (var data in datas)
            {
                result += Serialize(data) + "\n;\n";
            }

            return result;
        }

        private static object GetInstance(string strFullyQualifiedName)
        {
            Type t = Type.GetType(strFullyQualifiedName);
            return Activator.CreateInstance(t);
        }
    }
}
