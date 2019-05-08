using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.CommonHelpers.ReflectionHelpers
{
    /// <summary>
    /// Provides methods for more comfortable working with System.Type.
    /// </summary>
    public static class TypeHelper
    {
        /// <summary>
        /// Removes information about version, culture, PublicKeyToken and library name from type name.
        /// </summary>
        /// <param name="fullName">Initial type name.</param>
        /// <returns>Typename without version, culture, PublicKeyToken and library name.</returns>
        public static string RemoveLibInfoFromFullName(string fullName)
        {
            fullName = fullName.Replace(" ", string.Empty);

            while(true)
            {
                var startPos = fullName.IndexOf(",Version=");

                if(startPos == -1)
                {
                    break;
                }

                var posOfComma = IndexOfBeforeAndNearStartIndex(fullName, ",", startPos);
                var stopPos = fullName.IndexOf("]", startPos);
                fullName = fullName.Remove(posOfComma, stopPos - posOfComma);
            }

            return fullName;
        }

        private static int IndexOfBeforeAndNearStartIndex(string text, string value, int startIndex)
        {
            var lastIndex = -1;

            var pos = 0;
            var lengthOfValue = value.Length;

            while ((pos = text.IndexOf(value, pos)) != -1)
            {
                if(pos < startIndex)
                {
                    lastIndex = pos;
                    pos += lengthOfValue;
                    continue;
                }

                return lastIndex;
            }

            return lastIndex;
        }
    }
}
