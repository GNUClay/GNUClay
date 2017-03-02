using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.TextCGParser.DOT
{
    public class DotConverter
    {
        public static string ConvertToString(CGNode node)
        {
            var tmpContext = new DotContext();

            var tmpMainLeaf = tmpContext.CreateRootLeaf(node);

            tmpMainLeaf.Run();

            return tmpMainLeaf.Text;
        }
    }
}
