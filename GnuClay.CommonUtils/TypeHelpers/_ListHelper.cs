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
            var tmpSb = new StringBuilder();

            if (list == null)
            {
                tmpSb.AppendLine("null");

                return tmpSb.ToString();
            }

            foreach (var item in list)
            {
                tmpSb.AppendLine(item.ToString());
            }

            return tmpSb.ToString();
        }

        public static string _ToString<T>(IEnumerable<T> list, string listName)
        {
            var tmpSb = new StringBuilder();

            if (list == null)
            {
                tmpSb.Append(listName);
                tmpSb.AppendLine(" = null");

                return tmpSb.ToString();
            }

            tmpSb.Append("Begin ");
            tmpSb.AppendLine(listName);

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

            tmpSb.Append("End ");
            tmpSb.AppendLine(listName);

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
