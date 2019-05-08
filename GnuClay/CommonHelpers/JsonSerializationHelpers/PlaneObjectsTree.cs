using GnuClay.CommonHelpers.DebugHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.CommonHelpers.JsonSerializationHelpers
{
    public class PlaneObjectsTree: IObjectToString
    {
        public float Version { get; set; }
        public Dictionary<int, PlaneObject> ObjectsDict { get; set; }

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

            sb.AppendLine($"{spaces}{nameof(Version)} = {Version}");

            if (ObjectsDict == null)
            {
                sb.AppendLine($"{spaces}{nameof(ObjectsDict)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(ObjectsDict)}");
                foreach(var item in ObjectsDict)
                {
                    sb.AppendLine($"{nextNSpaces}Begin Key");
                    sb.AppendLine($"{nextNextNSpaces}{item.Key}");
                    sb.AppendLine($"{nextNSpaces}End Key");
                    sb.AppendLine($"{nextNSpaces}Begin Value");
                    sb.AppendLine(item.Value?.ToString(nextNextN));
                    sb.AppendLine($"{nextNSpaces}End Value");
                    sb.AppendLine();
                }
                sb.AppendLine($"{spaces}End {nameof(ObjectsDict)}");
            }

            return sb.ToString();
        }
    }
}
