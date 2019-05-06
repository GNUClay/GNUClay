﻿using GnuClay.CommonHelpers.DebugHelpers;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TmpSandBox.GnuClayEngine
{
    public class TstClass1 : IObjectToString, IObjectToBriefString
    {
        public string Id { get; set; }
        public TstClass2 FirstChild { get; set; }
        public List<TstClass2> Children { get; set; } = new List<TstClass2>();
        public Dictionary<int, int> Dict1 { get; set; } = new Dictionary<int, int>();
        public IDictionary<int, int> Dict2 { get; set; } = new Dictionary<int, int>();
        public IList<string> List1 { get; set; } = new List<string>();
        public int[] Arr1 { get; set; } = new int[] { 1, 2, 3 };
        public int Val1 { get; set; } = 15;

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
            sb.AppendLine($"{spaces}{nameof(Id)} = {Id}");
            sb.AppendLine($"{spaces}HashCode = {GetHashCode()}");

            if (FirstChild == null)
            {
                sb.AppendLine($"{spaces}{nameof(FirstChild)} == null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(FirstChild)}");
                sb.Append(FirstChild.ToBriefString(nextN));
                sb.AppendLine($"{spaces}End {nameof(FirstChild)}");
            }

            if (Children == null)
            {
                sb.AppendLine($"{spaces}Children == null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(Children)}");
                foreach(var item in Children)
                {
                    sb.Append(item.ToBriefString(nextN));
                }
                sb.AppendLine($"{spaces}End {nameof(Children)}");
            }
            return sb.ToString();
        }

        /// <summary>
        /// Returns a string that represents the current instance in very short way.
        /// </summary>
        /// <returns>A string that represents the current instance in very short way.</returns>
        public string ToBriefString()
        {
            return ToBriefString(0u);
        }

        /// <summary>
        /// Returns a string that represents the current instance in very short way.
        /// </summary>
        /// <param name="n">Count of spaces in the string for more comfortable representation.</param>
        /// <returns>A string that represents the current instance in very short way.</returns>
        public string ToBriefString(uint n)
        {
            return this.GetDefaultToBriefStringInformation(n);
        }

        /// <summary>
        /// Internal method which returns a string that represents the current instance in very short way without additional information, only pair name of property - value.
        /// </summary>
        /// <param name="n">Count of spaces in the string for more comfortable representation.</param>
        /// <returns>A string that represents the current instance in very short way without additional information, only pair name of property - value.</returns>
        public string PropertiesToBriefString(uint n)
        {
            var spaces = DisplayHelper.Spaces(n);
            var nextN = n + 4;
            var sb = new StringBuilder();
            sb.AppendLine($"{spaces}{nameof(Id)} = {Id}");
            sb.AppendLine($"{spaces}HashCode = {GetHashCode()}");
            return sb.ToString();
        }
    }
}
