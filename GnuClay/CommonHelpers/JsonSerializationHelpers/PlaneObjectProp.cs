using GnuClay.CommonHelpers.DebugHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.CommonHelpers.JsonSerializationHelpers
{
    // TODO: fix me!
    public class PlaneObjectProp: IObjectToString
    {
        public string Name { get; set; }
        public string FullTypeName { get; set; }
        public KindOfPlaneObjectPropType Kind { get; set; } = KindOfPlaneObjectPropType.Null;
        public object Value { get; set; }
        public PlaneObjectList List { get; set; }
        public PlaneObjectDictionary Dict { get; set; }
        public int Key { get; set; }

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
            sb.AppendLine($"{spaces}{nameof(Name)} = {Name}");
            sb.AppendLine($"{spaces}{nameof(FullTypeName)} = {FullTypeName}");         
            sb.AppendLine($"{spaces}{nameof(Kind)} = {Kind}");
            sb.AppendLine($"{spaces}{nameof(Value)} = {Value}");
            sb.AppendLine($"{spaces}{nameof(Key)} = {Key}");

            if (List == null)
            {
                sb.AppendLine($"{spaces}{nameof(List)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(List)}");
                sb.Append(List.ToString(nextN));
                sb.AppendLine($"{spaces}End {nameof(List)}");
            }

            if (Dict == null)
            {
                sb.AppendLine($"{spaces}{nameof(Dict)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(Dict)}");
                sb.Append(Dict.ToString(nextN));
                sb.AppendLine($"{spaces}End {nameof(Dict)}");
            }

            return sb.ToString();
        }
    }
}
