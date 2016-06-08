using GnuClay.CGConverters.DOT;
using GnuClay.ECG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateDotFileByCG();
        }

        private static ConceptualNode CreateTstGraph_1()
        {
            var tmpRootNode = new ConceptualNode();

            return tmpRootNode;
        }

        private static string CreateDotContent(ConceptualNode node)
        {
            var tmpConverter = new DotConverter();

            return tmpConverter.ConvertToString(node);
        }

        private static void CreateDotFileByCG()
        {
            var tmpRootNode = CreateTstGraph_1();

            var tmpTargetStr = CreateDotContent(tmpRootNode);

            NLog.LogManager.GetCurrentClassLogger().Info(tmpTargetStr);
        }
    }
}
