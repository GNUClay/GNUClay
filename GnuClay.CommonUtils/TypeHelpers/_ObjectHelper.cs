using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CommonUtils.TypeHelpers
{
    public static class _ObjectHelper
    {
        public static string PrintDefaultToStringInformation(object obj)
        {
            if (obj == null)
            {
                return string.Empty;
            }

            var tmpObj = obj as IToStringData;

            if (tmpObj == null)
            {
                return string.Empty;
            }

            var tmpSb = new StringBuilder();

            var tmpTypeName = obj.GetType().FullName;

            tmpSb.Append("Begin ");
            tmpSb.AppendLine(tmpTypeName);

            tmpSb.Append(tmpObj.ToStringData());

            tmpSb.Append("End ");
            tmpSb.AppendLine(tmpTypeName);

            return tmpSb.ToString();
        }

        public static string _ToString(object obj)
        {
            if (obj == null)
            {
                return "null";
            }

            return obj.ToString();
        }

        public static string _ToString(object obj, string objName)
        {
            if (obj == null)
            {
                return objName + " = null";
            }

            return objName + " = " + obj.ToString();
        }

        public static void CopyTo<T>(this object source, T dest)
        {
            JsonConvert.PopulateObject(source.ToJson(), dest);
        }

        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static string PrintJsonToStringInformation(object obj)
        {
            var json = JsonConvert.SerializeObject(obj).Replace("{", "{\n").Replace("[", "[\n").Replace("}", "\n}").Replace("]", "\n]").Replace(",", ",\n");
            return json;
        }

        public static string CreateName()
        {
            return $"#{Guid.NewGuid().ToString("D").Replace('-', '_')}";
        }

        /// <summary>
        /// Create string which will be contain only spaces.
        /// Count of spaces in the string equals value of parameter `indent`.
        /// </summary>
        /// <param name="indent">Count of spaces in the string.</param>
        /// <returns>String which will be contain only spaces</returns>
        public static string CreateSpaces(int indent)
        {
            var sb = new StringBuilder();

            for(var i = 0; i < indent; i++)
            {
                sb.Append(" ");
            }

            return sb.ToString();
        }
    }
}
