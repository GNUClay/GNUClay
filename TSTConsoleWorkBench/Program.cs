using GnuClay.CGConverters.DOT;
using GnuClay.ECG;
using GnuClay.Engine.Implementations;
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
            CreateGnuClayEngine();
            //CreateDotFileByCG();
        }

        private static void CreateGnuClayEngine()
        {
            var tmpFactory = new GnuClayEngineFactory();

            var tmpEngine = tmpFactory.Create();
        }

        private static ConceptualNode CreateTstGraph_1()
        {
            var tmpRootNode = new ConceptualNode();

            var tmpA_1 = new ConceptualNode(tmpRootNode);
            tmpA_1.Name = "I";

            var tmpA_2 = new RelationNode(tmpRootNode);
            tmpA_2.Name = "who";

            var tmpA_3 = new ConceptualNode(tmpRootNode);
            tmpA_3.Name = "hear";

            var tmpA_4 = new RelationNode(tmpRootNode);
            tmpA_4.Name = "what";

            var tmpA_5 = new RelationNode(tmpRootNode);
            tmpA_5.Name = "not";

            var tmpCluster_1 = new ConceptualNode(tmpRootNode);

            var tmpA_6 = new ConceptualNode(tmpCluster_1);
            tmpA_6.Name = "Mary";

            var tmpA_7 = new RelationNode(tmpCluster_1);
            tmpA_7.Name = "who";

            var tmpA_8 = new ConceptualNode(tmpCluster_1);
            tmpA_8.Name = "says";

            var tmpA_9 = new RelationNode(tmpCluster_1);
            tmpA_9.Name = "what";

            var tmpCluster_2 = new ConceptualNode(tmpCluster_1);

            var tmpA_10 = new ConceptualNode(tmpCluster_2);
            tmpA_10.Name = "dog:Spike";

            var tmpA_11 = new RelationNode(tmpCluster_2);
            tmpA_11.Name = "color";

            var tmpA_12 = new ConceptualNode(tmpCluster_2);
            tmpA_12.Name = "black";

            tmpA_11.AddInputNode(tmpA_10);

            tmpA_12.AddInputNode(tmpA_11);

            tmpA_6.AddInputNode(tmpA_7);

            tmpA_7.AddInputNode(tmpA_8);

            tmpA_9.AddInputNode(tmpA_8);

            tmpCluster_2.AddInputNode(tmpA_9);

            tmpA_1.AddInputNode(tmpA_2);

            tmpA_2.AddInputNode(tmpA_3);

            tmpA_4.AddInputNode(tmpA_3);

            tmpA_5.AddInputNode(tmpA_4);

            tmpCluster_1.AddInputNode(tmpA_5);

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
