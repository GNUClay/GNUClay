using GnuClay.CGConverters;
using GnuClay.CGConverters.DOT;
using GnuClay.CGConverters.SGF;
using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.ECG;
using GnuClay.Engine.CGResolver.Implementations;
using GnuClay.Engine.CGResolver.Implementations.FromECGToICG;
using GnuClay.Engine.Implementations;
using GnuClay.Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench
{
    class Program
    {
        static void Main(string[] args)
        {
            //TSTParseNodeName();
            //TSTGetDictionaryForTargetGenerationExceptionMessage();
            TSTConvertECGToICG();
            //TSTNormalizeString();
            //CreateGnuClayEngine();
            //CreateDotFileByCG();
            //CreateSGFContentByCG();
            //ParseSGFString();
            //ConvertSGFToDotString();  
        }

        private static void TSTParseNodeName()
        {
            //ParseNodeName("dog");
            //ParseNodeName("dog cat");
            //ParseNodeName("dog(cat(mode))");
            //ParseNodeName("dog:#123");
            //ParseNodeName("dog(cat):#123");
            //ParseNodeName("#123");
            //ParseNodeName("∀");
            //ParseNodeName("∀:#123");
            //ParseNodeName("∀X");
            //ParseNodeName("∀X:#123");
            //ParseNodeName("∃");
            //ParseNodeName("∃X");
            //ParseNodeName("∃:#123");
            //ParseNodeName("?");
            //ParseNodeName("?*X");
            //ParseNodeName("?∃X");
            //ParseNodeName("?∃");
            //ParseNodeName("?X");
            //ParseNodeName("?:#123");
            //ParseNodeName("dog:*");
            //ParseNodeName("dog:∃");
            //ParseNodeName("dog:?");
            //ParseNodeName("dog:?X");
            //ParseNodeName("dog:?∃");
            //ParseNodeName("dog:?*");
            //ParseNodeName("dog:?∃X");
            //ParseNodeName("dog:?*X");
            //ParseNodeName("?*");
            //ParseNodeName("*:*");
            //ParseNodeName("?:?");
            //ParseNodeName("?*X:?*Y");
            //ParseNodeName("#?");
            //ParseNodeName("#*");
            //ParseNodeName("#∃");
            ParseNodeName("#∃)");
            ParseNodeName("!");
            ParseNodeName("dog(");
        }

        private static void ParseNodeName(string name)
        {
            try
            {
                var tmpInfo = _QueryStringHelper.CreateNodeNameInfo(name);

                NLog.LogManager.GetCurrentClassLogger().Info(tmpInfo);
            }
            catch (Exception e)
            {
                NLog.LogManager.GetCurrentClassLogger().Info(e.ToString());
            }
        }

        private static void TSTGetDictionaryForTargetGenerationExceptionMessage()
        {
            var tmpList = new List<ulong>(){ 1, 2, 3};

            foreach(var i in tmpList)
            {
                NLog.LogManager.GetCurrentClassLogger().Info("i = {0}", i);
            }

            var tmpIndex = tmpList.First();

            NLog.LogManager.GetCurrentClassLogger().Info("tmpIndex = {0}", tmpIndex);

            tmpList.Remove(tmpIndex);

            foreach (var i in tmpList)
            {
                NLog.LogManager.GetCurrentClassLogger().Info("i = {0}", i);
            }

            try
            {
                GetDictionaryForTargetGeneration(3);
            }
            catch(Exception e)
            {
                NLog.LogManager.GetCurrentClassLogger().Info(e.Message);
            }
        }

        private static Dictionary<ulong, ulong> GetDictionaryForTargetGeneration(byte targetGeneration)
        {
            var tmpSb = new StringBuilder();

            tmpSb.Append("Generation maybe from 0 to 2 inclusively, but current value is ");
            tmpSb.Append(targetGeneration);

            throw new ArgumentOutOfRangeException(nameof(targetGeneration), tmpSb.ToString());
        }

        private static void TSTConvertECGToICG()
        {
            var tmpFactory = new GnuClayEngineFactory();

            var tmpEngine = tmpFactory.Create();

            try
            {
                var tmpRootNode = CreateTstGraph_1();

                var tmpConverter = new ECGResolver(tmpEngine.TSTContext);

                var tmpTargetICG = tmpConverter.ConvertECGToICG(tmpRootNode);

                var tmpSGFConverter = new SGFConverter();

                var tmpTargetStr = tmpSGFConverter.ConvertToString(tmpTargetICG);

                NLog.LogManager.GetCurrentClassLogger().Info(tmpTargetStr);

                //NLog.LogManager.GetCurrentClassLogger().Info(tmpEngine.Query(tmpRootNode));
            }
            catch (Exception e)
            {
                NLog.LogManager.GetCurrentClassLogger().Info(e.ToString());
            }
        }

        private static void TSTNormalizeString()
        {
            var source = " dog      cat (    (tree)   )   g ";

            var tmpTargetString = _StringHelper.Normalize(source);

            NLog.LogManager.GetCurrentClassLogger().Info("|{0}|", tmpTargetString);
        }

        private static IGnuClayEngine mEngine = null;

        private static void CreateGnuClayEngine()
        {
            var tmpEngine = GnuClayCreator.Create();

            NLog.LogManager.GetCurrentClassLogger().Info(tmpEngine.TSTContext.TimeProvider.Now);

            Thread.Sleep(2000);

            NLog.LogManager.GetCurrentClassLogger().Info(tmpEngine.TSTContext.TimeProvider.Now);

            tmpEngine.Exit();
        }

        private static ConceptualNode CreateTstGraph_1()
        {
            var tmpRootNode = new ConceptualNode();

            //CreateAdditionalNodes(tmpRootNode);

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
            tmpA_10.Name = "dog:#123456";

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

        private static void CreateAdditionalNodes(ConceptualNode rootNode)
        {
            var tmpA_1 = new ConceptualNode(rootNode);
            tmpA_1.Name = "∀";

            tmpA_1 = new ConceptualNode(rootNode);
            tmpA_1.Name = "?*X";

            tmpA_1 = new ConceptualNode(rootNode);
            tmpA_1.Name = "#?*Z";

            var tmpA_2 = new RelationNode(rootNode);
            tmpA_2.Name = "∀";

            tmpA_2 = new RelationNode(rootNode);
            tmpA_2.Name = "?*X";

            tmpA_2 = new RelationNode(rootNode);
            tmpA_2.Name = "?*Y";
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

        private static string CreateSGFStringExample()
        {
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

            return tmpSb.ToString();
        }

        private static void ParseSGFString()
        {
            //NLog.LogManager.GetCurrentClassLogger().Info("{0} {1} {2}", default(char), (int)default(char), default(char) == char.MinValue);

            var tmpConverter = new SGFConverter(new SGFECGNodeFactory());



            var tmpRootNode = CreateTstGraph_1();

            /*var tmpTargetStr = */
            NLog.LogManager.GetCurrentClassLogger().Info(tmpConverter.ConvertToString(tmpRootNode));//*/

            var tmpTargetStr = CreateSGFStringExample();

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

        private static void ConvertSGFToDotString()
        {
            var tmpMainConverter = new MainConverter();

            var tmpSourceString = CreateSGFStringExample();

            NLog.LogManager.GetCurrentClassLogger().Info(tmpSourceString);

            var tmpTargetStr = tmpMainConverter.ConvertFromSGFToDotString(tmpSourceString);

            NLog.LogManager.GetCurrentClassLogger().Info(tmpTargetStr);
        }
    }
}
