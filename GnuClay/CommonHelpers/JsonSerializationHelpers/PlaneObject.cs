using GnuClay.CommonHelpers.DebugHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.CommonHelpers.JsonSerializationHelpers
{
    // TODO: fix me!
    public class PlaneObject : IObjectToString
    {
        public string FullTypeName { get; set; }
        public string TypeName { get; set; }
        public string Namespace { get; set; }
        public int Key { get; set; }
        public Dictionary<string, object> Values { get; set; } = new Dictionary<string, object>();

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
            var nextNSpaces = DisplayHelper.Spaces(nextN);
            var nextNextN = nextN + 4;
            var nextNextNSpaces = DisplayHelper.Spaces(nextNextN);
            var sb = new StringBuilder();
            sb.AppendLine($"{spaces}{nameof(FullTypeName)} = {FullTypeName}");
            sb.AppendLine($"{spaces}{nameof(TypeName)} = {TypeName}");
            sb.AppendLine($"{spaces}{nameof(Namespace)} = {Namespace}");
            sb.AppendLine($"{spaces}{nameof(Key)} = {Key}");

            if (Values == null)
            {
                sb.AppendLine($"{spaces}{nameof(Values)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(Values)}");
                foreach (var item in Values)
                {
                    sb.AppendLine($"{nextNSpaces}Begin Key");
                    sb.AppendLine($"{nextNextNSpaces}{item.Key}");
                    sb.AppendLine($"{nextNSpaces}End Key");
                    sb.AppendLine($"{nextNSpaces}Begin Value");
                    sb.AppendLine($"{nextNextNSpaces}{item.Value}");
                    sb.AppendLine($"{nextNSpaces}End Value");
                    sb.AppendLine();
                }
                sb.AppendLine($"{spaces}End {nameof(Values)}");
            }

            return sb.ToString();
        }
    }
}
