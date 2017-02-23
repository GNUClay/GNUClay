using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GnuClay.CommonUtils.TypeHelpers
{
    public static class _StringHelper
    {
        public static string Normalize(this string source)
        {
            if(string.IsNullOrWhiteSpace(source))
            {
                return string.Empty;
            }

            source = Regex.Replace(source, "(\\s+)", " ");

            var tmpRegex_1 = new Regex("\\W(\\s)\\W");

            source = source.SpaceRemoverInNormalizedString(tmpRegex_1);

            var tmpRegex_2 = new Regex("\\w(\\s)\\W");

            source = source.SpaceRemoverInNormalizedString(tmpRegex_2);

            var tmpRegex_3 = new Regex("\\W(\\s)\\w");

            source = source.SpaceRemoverInNormalizedString(tmpRegex_3);

            return source.Trim();
        }

        private static string SpaceRemoverInNormalizedString(this string source, Regex regex)
        {
            do
            {
                var tmpMatch = regex.Match(source);

                if (tmpMatch == Match.Empty)
                {
                    break;
                }

                source = source.Remove(tmpMatch.Index + 1, 1);
            } while (true);

            return source;
        }
    }
}
