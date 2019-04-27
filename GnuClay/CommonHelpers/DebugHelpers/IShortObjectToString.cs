using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.CommonHelpers.DebugHelpers
{
    public interface IShortObjectToString
    {
        /// <summary>
        /// Returns a string that represents the current instance in short way.
        /// </summary>
        /// <returns>A string that represents the current instance in short way.</returns>
        string ToShortString();

        /// <summary>
        /// Returns a string that represents the current instance in short way.
        /// </summary>
        /// <param name="n">Count of spaces in the string for more comfortable representation.</param>
        /// <returns>A string that represents the current instance in short way.</returns>
        string ToShortString(uint n);

        /// <summary>
        /// Internal method which returns a string that represents the current instance in short way without additional information, only pair name of property - value.
        /// </summary>
        /// <param name="n">Count of spaces in the string for more comfortable representation.</param>
        /// <returns>A string that represents the current instance in short way without additional information, only pair name of property - value.</returns>
        string PropertiesToShortString(uint n);
    }
}

/*
        /// <summary>
        /// Returns a string that represents the current instance in short way.
        /// </summary>
        /// <returns>A string that represents the current instance in short way.</returns>
        public string ToShortString()
        {
            return ToShortString(0u);
        }

        /// <summary>
        /// Returns a string that represents the current instance in short way.
        /// </summary>
        /// <param name="n">Count of spaces in the string for more comfortable representation.</param>
        /// <returns>A string that represents the current instance in short way.</returns>
        public string ToShortString(uint n)
        {
            return this.GetDefaultToShortStringInformation(n);
        }

        /// <summary>
        /// Internal method which returns a string that represents the current instance in short way without additional information, only pair name of property - value.
        /// </summary>
        /// <param name="n">Count of spaces in the string for more comfortable representation.</param>
        /// <returns>A string that represents the current instance in short way without additional information, only pair name of property - value.</returns>
        public string PropertiesToShortString(uint n)
        {
            var spaces = StringHelper.Spaces(n);
            var nextN = n + 4;
            var sb = new StringBuilder();
            return sb.ToString();
        } 
*/
