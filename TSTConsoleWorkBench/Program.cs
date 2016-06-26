using GnuClay.CGConverters.DOT;
using GnuClay.CGConverters.SGF;
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
            //CreateGnuClayEngine();
            //CreateDotFileByCG();
            //CreateSGFContentByCG();
            ParseSGFString();
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

        private static void CreateSGFContentByCG()
        {
            var tmpRootNode = CreateTstGraph_1();

            var tmpConverter = new SGFConverter();

            var tmpTargetStr = tmpConverter.ConvertToString(tmpRootNode);

            NLog.LogManager.GetCurrentClassLogger().Info(tmpTargetStr);
        }

        private static void ParseSGFString()
        {
            //NLog.LogManager.GetCurrentClassLogger().Info("{0} {1} {2}", default(char), (int)default(char), default(char) == char.MinValue);

            var tmpConverter = new SGFConverter(new SGFECGNodeFactory());



            var tmpRootNode = CreateTstGraph_1();

            /*var tmpTargetStr = */
            NLog.LogManager.GetCurrentClassLogger().Info(tmpConverter.ConvertToString(tmpRootNode));//*/


            var tmpSb = new StringBuilder();

            tmpSb.AppendLine("[{");
            tmpSb.AppendLine("n_2:[\"I\"];");
            tmpSb.AppendLine("n_4:[\"hear\"];");
            tmpSb.AppendLine("n_3:(\"who\");");
            tmpSb.AppendLine("n_5:(\"what\");");
            tmpSb.AppendLine("n_6:(\"not\");");
            tmpSb.AppendLine("n_7:[{");
            tmpSb.AppendLine("n_8:[\"Mary\"];");
            tmpSb.AppendLine("n_10:[\"says\"];");
            tmpSb.AppendLine("n_9:(\"who\");");
            tmpSb.AppendLine("n_11:(\"what\");");
            tmpSb.AppendLine("n_12:[{");
            tmpSb.AppendLine("n_13:[\"dog:Spike\"];");
            tmpSb.AppendLine("n_15:[\"black\"];");
            tmpSb.AppendLine("n_14:(\"color\");");
            //tmpSb.AppendLine("n_13 -> n_14 -> n_15;");
            tmpSb.AppendLine("n_13 -> n_14;");
            tmpSb.AppendLine("n_14 -> n_15;");
            tmpSb.AppendLine("}];");
            tmpSb.AppendLine("");
            tmpSb.AppendLine("n_9 -> n_8;");
            tmpSb.AppendLine("n_10 -> n_9;");
            tmpSb.AppendLine("n_10 -> n_11;");
            tmpSb.AppendLine("n_11 -> n_12;");
            tmpSb.AppendLine("}];");
            tmpSb.AppendLine("");
            tmpSb.AppendLine("n_3 -> n_2;");
            tmpSb.AppendLine("n_4 -> n_3;");
            tmpSb.AppendLine("n_4 -> n_5;");
            tmpSb.AppendLine("n_5 -> n_6;");
            tmpSb.AppendLine("n_6 -> n_7;");
            tmpSb.AppendLine("}];");

            var tmpTargetStr = tmpSb.ToString();

            NLog.LogManager.GetCurrentClassLogger().Info(tmpTargetStr);

            try
            {
                var tmpGraph = tmpConverter.ConvertFromString(tmpTargetStr);

                var tmpGraphStr = tmpConverter.ConvertToString(tmpGraph);

                NLog.LogManager.GetCurrentClassLogger().Info(tmpGraphStr);
            }
            catch(Exception e)
            {
                NLog.LogManager.GetCurrentClassLogger().Info(e.ToString());
            }
            
        }
    }
}
