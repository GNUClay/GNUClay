using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CommonUtils.TypeHelpers
{
    public static class _ListHelper
    {
        public static bool FullContains(this List<string> source, List<string> compararedItems)
        {
            foreach(var item in compararedItems)
            {
                if(!source.Contains(item))
                {
                    return false;
                }
            }

            return true;
        }

        public static List<string> StringToList(this string value)
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                return new List<string>();
            }

            return value.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        public static string ListToString(this List<string> list)
        {
            var sb = new StringBuilder();

            foreach (var c in list)
            {
                if (string.IsNullOrWhiteSpace(c))
                {
                    continue;
                }

                sb.Append($"{c} ");
            }

            return sb.ToString().Trim();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEmpty<T>(IEnumerable<T> list)
        {
            if (list == null || list.Count() == 0)
            {
                return true;
            }

            return false;
        }

        public static string _ToString<T>(IEnumerable<T> list)
        {
            if (list == null)
            {
                return "null";
            }

            var tmpSb = new StringBuilder();

            foreach (var item in list)
            {
                tmpSb.AppendLine(item.ToString());
            }

            return tmpSb.ToString();
        }

        public static string _ToString<T>(IEnumerable<T> list, string listName)
        {
            if (list == null)
            {
                return $"{listName} = null";
            }

            var tmpSb = new StringBuilder();

            tmpSb.AppendLine($"Begin {listName}");

            foreach (var item in list)
            {
                if (Equals(item, null))
                {
                    tmpSb.AppendLine("null");
                }
                else
                {
                    tmpSb.AppendLine(item.ToString());
                }
            }

            tmpSb.AppendLine($"End {listName}");

            return tmpSb.ToString();
        }

        public class CompararedResult<T> : IToStringData
        {
            public List<T> Source = new List<T>();

            public List<T> Dest = new List<T>();

            public List<T> MustAddedItems = new List<T>();

            public List<T> MustIgnoredItems = new List<T>();

            public List<T> MustRemovedItems = new List<T>();

            public override string ToString()
            {
                return _ObjectHelper.PrintDefaultToStringInformation(this);
            }

            public string ToStringData()
            {
                var tmpSb = new StringBuilder();

                tmpSb.AppendLine(_ToString(Source, "Source"));

                tmpSb.AppendLine(_ToString(Dest, "Dest"));

                tmpSb.AppendLine(_ToString(MustAddedItems, "MustAddedItems"));

                tmpSb.AppendLine(_ToString(MustIgnoredItems, "MustIgnoredItems"));

                tmpSb.AppendLine(_ToString(MustRemovedItems, "MustRemovedItems"));

                return tmpSb.ToString();
            }
        }

        public static CompararedResult<T> Comparare<T>(List<T> source, List<T> dest)
        {
            var tmpResult = new CompararedResult<T>();

            tmpResult.Source = source;
            tmpResult.Dest = dest;

            if (source == null || dest == null)
            {
                return tmpResult;
            }

            foreach (var item in tmpResult.Source)
            {
                if (tmpResult.Dest.Contains(item))
                {
                    tmpResult.MustIgnoredItems.Add(item);
                }
                else
                {
                    tmpResult.MustRemovedItems.Add(item);
                }
            }

            foreach (var item in tmpResult.Dest)
            {
                if (!tmpResult.MustIgnoredItems.Contains(item))
                {
                    tmpResult.MustAddedItems.Add(item);
                }
            }

            return tmpResult;
        }
    }
}
