using GnuClay.CommonHelpers.DebugHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.CommonHelpers.JsonSerializationHelpers
{
    // TODO: fix me!
    public class PlaneObject : IObjectToString
    {
        public string TypeName { get; set; }
        public int Key { get; set; }
        public List<PlaneObjectProp> PropertiesList { get; set; } = new List<PlaneObjectProp>();

        /// <summary>
        /// Returns a string that represents the current instance.
        /// </summary>
        /// <returns>A string that represents the current instance.</returns>
        public override string ToString()
        {
            return ToString(0u);
        }

        /// <summary>
        /// Returns a string that represents the current instance.
        /// </summary>
        /// <param name="n">Count of spaces in the string for more comfortable representation.</param>
        /// <returns>A string that represents the current instance.</returns>
        public string ToString(uint n)
        {
            return this.GetDefaultToStringInformation(n);
        }

        /// <summary>
        /// Internal method which returns a string that represents the current instance without additional information, only pair name of property - value.
        /// </summary>
        /// <param name="n">Count of spaces in the string for more comfortable representation.</param>
        /// <returns>A string that represents the current instance without additional information, only pair name of property - value.</returns>
        public string PropertiesToString(uint n)
        {
            var spaces = DisplayHelper.Spaces(n);
            var nextN = n + 4;
            var sb = new StringBuilder();
            sb.AppendLine($"{spaces}{nameof(TypeName)} = {TypeName}");
            sb.AppendLine($"{spaces}{nameof(Key)} = {Key}");

            if (PropertiesList == null)
            {
                sb.AppendLine($"{spaces}{nameof(PropertiesList)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(PropertiesList)}");
                foreach (var item in PropertiesList)
                {
                    sb.Append(item.ToString(nextN));
                    sb.AppendLine();
                }
                sb.AppendLine($"{spaces}End {nameof(PropertiesList)}");
            }

            return sb.ToString();
        }
    }
}
