using System;
using System.Collections.Generic;
using System.Text;

namespace TmpSandBox.Navigation
{
    public static class TstPathsHelper
    {
        public static string DisplayPath(IList<TstPlane> path)
        {
            var sb = new StringBuilder();

            foreach (var item in path)
            {
                sb.Append($"{item.Name},");
            }
            sb.Remove(sb.Length - 1, 1);

            var str = sb.ToString().Replace(",", " -> ");
            return str;
        }
    }
}
