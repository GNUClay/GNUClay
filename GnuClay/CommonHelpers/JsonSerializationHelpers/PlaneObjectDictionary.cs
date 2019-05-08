﻿using GnuClay.CommonHelpers.DebugHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.CommonHelpers.JsonSerializationHelpers
{
    public class PlaneObjectDictionary : IObjectToString
    {
        public string TypeName { get; set; }
        public List<KeyValuePair<PlaneObjectProp, PlaneObjectProp>> List { get; set; } = new List<KeyValuePair<PlaneObjectProp, PlaneObjectProp>>();

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
            var sb = new StringBuilder();
            sb.AppendLine($"{spaces}{nameof(TypeName)} = {TypeName}");

            if(List == null)
            {
                sb.AppendLine($"{spaces}{nameof(List)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(List)}");
                foreach (var item in List)
                {
                    sb.AppendLine($"{nextNSpaces}Begin Key");
                    sb.Append(item.Key.ToString(nextNextN));
                    sb.AppendLine($"{nextNSpaces}End Key");
                    sb.AppendLine($"{nextNSpaces}Begin Value");
                    sb.Append(item.Value.ToString(nextNextN));
                    sb.AppendLine($"{nextNSpaces}End Value");
                }
                sb.AppendLine($"{spaces}End {nameof(List)}");
            }

            return sb.ToString();
        }
    }
}
