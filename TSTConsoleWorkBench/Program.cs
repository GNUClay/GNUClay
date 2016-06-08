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
            var tmpSb = new StringBuilder();

            return tmpSb.ToString();
        }

        private static void CreateDotFileByCG()
        {
            var tmpRootNode = CreateTstGraph_1();

            var tmpTargetStr = CreateDotContent(tmpRootNode);

            NLog.LogManager.GetCurrentClassLogger().Info(tmpTargetStr);
        }
    }
}
