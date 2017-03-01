﻿using GnuClay.Engine;
using GnuClay.Engine.Parser.InternalParsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.TextCGParser
{
    public class N
    {
        public string N_1 = string.Empty;
        public string N_2 = string.Empty;
        public string N_3 = string.Empty;
        public string N_4 = string.Empty;
        public string N_5 = string.Empty;
        public string N_6 = string.Empty;
        public string N_7 = string.Empty;
        public string N_8 = string.Empty; 
    }

    public class TextCGParserRunner
    {
        public void Run()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Run");

            var targetPhrase = "The dog likes man.";

            var context = CreateContext();

            var tmpLexer = new ExtendTextLexer(targetPhrase.ToLower().Trim(), context);

            ExtendToken CurrToken = null;

            try
            {
                var tokens = new List<ExtendToken>();

                while ((CurrToken = tmpLexer.GetToken()) != null)
                {
                    NLog.LogManager.GetCurrentClassLogger().Info(CurrToken);

                    tokens.Add(CurrToken);
                }

                var parser = new ATNParser(tokens);

                parser.Run();

                var result = parser.Result;

                var semanticAnalyzer = new SemanticAnalyzer(result, context.Engine);
                semanticAnalyzer.Run();

                var cgNodes = semanticAnalyzer.Result;
            }
            catch(Exception e)
            {
                NLog.LogManager.GetCurrentClassLogger().Info(e);
            }
        }

        private TextParsingLexerContex CreateContext()
        {
            var engine = new GnuClayEngine();

            var context = new TextParsingLexerContex(engine);

            var dataDictionary = context.Engine.DataDictionary;

            InitWordsDb(context);

            dataDictionary.TSTDump();

            return context;
        }

        private void InitWordsDb(TextParsingLexerContex context)
        {
            var engine = context.Engine;

            var queryStr = "INSERT {>: {`part of speech`(the, article)}}";
            engine.Query(queryStr);

            queryStr = "INSERT {>: {`part of speech`(dog, noun)}}, { >: {number(dog, singular)}}";
            engine.Query(queryStr);

            queryStr = "INSERT {>: {`part of speech`(like, verb)}}, { >: {tense(like, present)}}";
            engine.Query(queryStr);

            queryStr = "INSERT {>: {`part of speech`(likes, verb)}}, { >: {tense(likes, present)}}, {>: {root(likes, like)}}";
            engine.Query(queryStr);

            queryStr = "INSERT {>: {`part of speech`(man, noun)}}, { >: {number(man, singular)}}";
            engine.Query(queryStr);
        }

        private const string NP = "NP";
        private const string QW = "QW";
        private const string PQW = "PQW";
        private const string V = "V";
        private const string Ving = "Ving";
        private const string V3f = "V3f";
        private const string to = "to";
        private const string not = "not";
        private const string have = "have";
        private const string will = "will";
        private const string must = "must";
        private const string can = "can";
        private const string _do = "do";
        private const string may = "may";
        private const string could = "could";
        private const string might = "might";
        private const string be = "be";
        private const string able = "able";
        private const string F_to_do = "(f to do)";
        private const string F_to_be = "(f to be)";
        private const string F_to_have = "(f to have)";

        public void CreateATNStateTree()
        {
            var nodes = new List<N>()
            {
                N(NP, V),
                N(NP, F_to_do, not, V),
                N(PQW, V),
                N(PQW, F_to_do, not, V),
                N(F_to_do, NP, V),
                N(F_to_do, not, NP, V),
                N(QW, F_to_do, NP, V),
                N(QW, F_to_do, not, NP, V),
                N(NP, will, V),
                N(NP, will, not, V),
                N(PQW, will, V),
                N(PQW, will, not, V),
                N(will, NP, V),
                N(will, not, NP, V),
                N(QW, will, NP, V),
                N(QW, will, not, NP, V),
                N(V, NP),
                N(_do, not, V, NP),
                N(NP, F_to_be, Ving),
                N(NP, F_to_be, not, Ving),
                N(PQW, F_to_be, Ving),
                N(PQW, F_to_be, not, Ving),
                N(F_to_be, NP, Ving),
                N(F_to_be, not, NP, Ving),
                N(QW, F_to_be, NP, Ving),
                N(QW, F_to_be, not, NP, Ving),
                N(NP, will, be, Ving),
                N(NP, will, not, be, Ving),
                N(PQW, will, be, Ving),
                N(PQW, will, not, be, Ving),
                N(will, NP, be, Ving),
                N(will, not, NP, be, Ving),
                N(QW, will, NP, be, Ving),
                N(QW, will, not, NP, be, Ving),
                N(NP, F_to_have, V3f),
                N(NP, F_to_have, not, V3f),
                N(PQW, F_to_have, V3f),
                N(PQW, F_to_have, not, V3f),
                N(F_to_have, NP, V3f),
                N(F_to_have, not, NP, V3f),
                N(QW, F_to_have, NP, V3f),
                N(QW, F_to_have, not, NP, V3f),
                N(NP, will, have, V3f),
                N(NP, will, not, have, V3f),
                N(PQW, will, have, V3f),
                N(PQW, will, not, have, V3f),
                N(will, NP, have, V3f),
                N(will, not, NP, have, V3f),
                N(QW, will, NP, have, V3f),
                N(QW, will, not, NP, have, V3f),
                N(NP, must, V),
                N(NP, must, not, V),
                N(PQW, must, V),
                N(PQW, must, not, V),
                N(must, NP, V),
                N(must, not, NP, V),
                N(QW, must, NP, V),
                N(QW, must, not, NP, V),
                N(NP, F_to_have, to, V),
                N(PQW, F_to_have, to, V),
                N(NP, F_to_do, not, have, to, V),
                N(PQW, F_to_do, not, have, to, V),
                N(F_to_do, NP, have, to, V),
                N(F_to_do, not, NP, have, to, V),
                N(QW, F_to_do, NP, have, to, V),
                N(QW, F_to_do, not, NP, have, to, V),
                N(NP, will, have, to, V),
                N(NP, will, not, have, to, V),
                N(PQW, will, have, to, V),
                N(PQW, will, not, have, to, V),
                N(will, NP, have, to, V),
                N(will, not, NP, have, to, V),
                N(QW, will, NP, have, to, V),
                N(QW, will, not, NP, have, to, V),
                N(NP, F_to_be, able, to, V),
                N(NP, F_to_be, not, able, to, V),
                N(PQW, F_to_be, able, to, V),
                N(PQW, F_to_be, not, able, to, V),
                N(F_to_be, NP, able, to, V),
                N(F_to_be, not, NP, able, to, V),
                N(QW, F_to_be, NP, able, to, V),
                N(QW, F_to_be, not, NP, able, to, V),
                N(NP, will, be, able, to, V),
                N(NP, will, not, be, able, to, V),
                N(PQW, will, be, able, to, V),
                N(PQW, will, not, be, able, to, V),
                N(will, NP, be, able, to, V),
                N(will, not, NP, be, able, to, V),
                N(QW, will, NP, be, able, to, V),
                N(QW, will, not, NP, be, able, to, V),
                N(NP, may, V),
                N(NP, may, not, V),
                N(PQW, may, V),
                N(PQW, may, not, V),
                N(may, NP, V),
                N(may, not, NP, V),
                N(QW, may, NP, V),
                N(QW, may, not, NP, V),
                N(NP, might, V),
                N(NP, might, not, V),
                N(PQW, might, V),
                N(PQW, might, not, V),
                N(might, NP, V),
                N(might, not, NP, V),
                N(QW, might, NP, V),
                N(QW, might, not, NP, V),
                N(NP, can, V),
                N(NP, can, not, V),
                N(PQW, can, V),
                N(PQW, can, not, V),
                N(can, NP, V),
                N(can, not, NP, V),
                N(QW, can, NP, V),
                N(QW, can, not, NP, V),
                N(NP, could, V),
                N(NP, could, not, V),
                N(PQW, could, V),
                N(PQW, could, not, V),
                N(could, NP, V),
                N(could, not, NP, V),
                N(QW, could, NP, V),
                N(QW, could, not, NP, V)
            };

            var N1List = nodes.GroupBy(p => p.N_1).ToDictionary(p => p.Key, p => p.ToList());

            var n = 0;

            var tmpStateSb = new StringBuilder();

            var tmpProcessingStub = new StringBuilder();

            foreach(var node in N1List)
            {
                var n_1 = node.Key;

                var stateName = GetStateName(n_1);

                n++;

                NLog.LogManager.GetCurrentClassLogger().Info($"CreateATNStateTree n_1 = {n_1} stateName = {stateName} n = {n}");

                RegStateItem(tmpStateSb, stateName);
                RegProsessingItem(tmpProcessingStub, stateName);

                var N2List = node.Value.GroupBy(p => p.N_2).ToDictionary(p => p.Key, p => p.ToList());

                foreach(var subNode_2 in N2List)
                {
                    var n_2 = subNode_2.Key;

                    stateName = GetStateName(n_1, n_2);

                    n++;

                    NLog.LogManager.GetCurrentClassLogger().Info($"CreateATNStateTree {Spacer(1)} n_2 = {n_2} stateName = {stateName} n = {n}");

                    RegStateItem(tmpStateSb, stateName);
                    RegProsessingItem(tmpProcessingStub, stateName);

                    var items_3 = subNode_2.Value;

                    if (items_3.Any(p => !string.IsNullOrWhiteSpace(p.N_3)))
                    {
                        var N3List = subNode_2.Value.GroupBy(p => p.N_3).ToDictionary(p => p.Key, p => p.ToList());

                        foreach (var subNode_3 in N3List)
                        {
                            var n_3 = subNode_3.Key;

                            stateName = GetStateName(n_1, n_2, n_3);

                            n++;

                            NLog.LogManager.GetCurrentClassLogger().Info($"CreateATNStateTree {Spacer(2)} n_3 = {n_3} stateName = {stateName} n = {n}");

                            RegStateItem(tmpStateSb, stateName);
                            RegProsessingItem(tmpProcessingStub, stateName);

                            var items_4 = subNode_3.Value;

                            if(items_4.Any(p => !string.IsNullOrWhiteSpace(p.N_4)))
                            {
                                var N4List = items_4.GroupBy(p => p.N_4).ToDictionary(p => p.Key, p => p.ToList());

                                foreach(var subNode_4 in N4List)
                                {
                                    var n_4 = subNode_4.Key;

                                    stateName = GetStateName(n_1, n_2, n_3, n_4);

                                    n++;

                                    NLog.LogManager.GetCurrentClassLogger().Info($"CreateATNStateTree {Spacer(3)} n_4 = {n_4} stateName = {stateName} n = {n}");

                                    RegStateItem(tmpStateSb, stateName);
                                    RegProsessingItem(tmpProcessingStub, stateName);

                                    var items_5 = subNode_4.Value;

                                    if(items_5.Any(p => !string.IsNullOrWhiteSpace(p.N_5)))
                                    {
                                        var N5List = items_5.GroupBy(p => p.N_5).ToDictionary(p => p.Key, p => p.ToList());

                                        foreach (var subNode_5 in N5List)
                                        {
                                            var n_5 = subNode_5.Key;

                                            stateName = GetStateName(n_1, n_2, n_3, n_4, n_5);

                                            n++;

                                            NLog.LogManager.GetCurrentClassLogger().Info($"CreateATNStateTree {Spacer(4)} n_5 = {n_5} stateName = {stateName} n = {n}");

                                            RegStateItem(tmpStateSb, stateName);
                                            RegProsessingItem(tmpProcessingStub, stateName);

                                            var items_6 = subNode_5.Value;

                                            if(items_6.Any(p => !string.IsNullOrWhiteSpace(p.N_6)))
                                            {
                                                var N6List = items_6.GroupBy(p => p.N_6).ToDictionary(p => p.Key, p => p.ToList());

                                                foreach (var subNode_6 in N6List)
                                                {
                                                    var n_6 = subNode_6.Key;

                                                    stateName = GetStateName(n_1, n_2, n_3, n_4, n_5, n_6);

                                                    n++;

                                                    NLog.LogManager.GetCurrentClassLogger().Info($"CreateATNStateTree {Spacer(5)} n_6 = {n_6} stateName = {stateName} n = {n}");

                                                    RegStateItem(tmpStateSb, stateName);
                                                    RegProsessingItem(tmpProcessingStub, stateName);

                                                    var items_7 = subNode_6.Value;

                                                    if(items_7.Any(p => !string.IsNullOrWhiteSpace(p.N_7)))
                                                    {
                                                        var N7List = items_7.GroupBy(p => p.N_7).ToDictionary(p => p.Key, p => p.ToList());

                                                        foreach(var subNode_7 in N7List)
                                                        {
                                                            var n_7 = subNode_7.Key;

                                                            stateName = GetStateName(n_1, n_2, n_3, n_4, n_5, n_6, n_7);

                                                            n++;

                                                            NLog.LogManager.GetCurrentClassLogger().Info($"CreateATNStateTree {Spacer(6)} n_7 = {n_7} stateName = {stateName} n = {n}");

                                                            RegStateItem(tmpStateSb, stateName);
                                                            RegProsessingItem(tmpProcessingStub, stateName);

                                                            var items_8 = subNode_7.Value;

                                                            if(items_8.Any(p => !string.IsNullOrWhiteSpace(p.N_8)))
                                                            {
                                                                var N8List = items_8.GroupBy(p => p.N_8).ToDictionary(p => p.Key, p => p.ToList());

                                                                foreach (var subNode_8 in N8List)
                                                                {
                                                                    var n_8 = subNode_8.Key;

                                                                    stateName = GetStateName(n_1, n_2, n_3, n_4, n_5, n_6, n_7, n_8);

                                                                    n++;

                                                                    NLog.LogManager.GetCurrentClassLogger().Info($"CreateATNStateTree {Spacer(7)} n_8 = {n_8} stateName = {stateName} n = {n}");

                                                                    RegStateItem(tmpStateSb, stateName);
                                                                    RegProsessingItem(tmpProcessingStub, stateName);
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            NLog.LogManager.GetCurrentClassLogger().Info(tmpStateSb.ToString());
            NLog.LogManager.GetCurrentClassLogger().Info(tmpProcessingStub.ToString());

        }

        private static void RegStateItem(StringBuilder sb, string name)
        {
            sb.AppendLine($"{name},");
        }

        private static void RegProsessingItem(StringBuilder sb, string name)
        {
            sb.AppendLine($"case ATNNodeState.{name}:");
            sb.AppendLine("throw new NotImplementedException();");
            sb.AppendLine(string.Empty);
        }

        private static N N(string n_1)
        {
            var result = new N();

            result.N_1 = n_1;

            return result;
        }

        private static N N(string n_1, string n_2)
        {
            var result = new N();

            result.N_1 = n_1;
            result.N_2 = n_2;

            return result;
        }

        private static N N(string n_1, string n_2, string n_3)
        {
            var result = new N();

            result.N_1 = n_1;
            result.N_2 = n_2;
            result.N_3 = n_3;

            return result;
        }

        private static N N(string n_1, string n_2, string n_3, string n_4)
        {
            var result = new N();

            result.N_1 = n_1;
            result.N_2 = n_2;
            result.N_3 = n_3;
            result.N_4 = n_4;

            return result;
        }

        private static N N(string n_1, string n_2, string n_3, string n_4, string n_5)
        {
            var result = new N();

            result.N_1 = n_1;
            result.N_2 = n_2;
            result.N_3 = n_3;
            result.N_4 = n_4;
            result.N_5 = n_5;

            return result;
        }

        private static N N(string n_1, string n_2, string n_3, string n_4, string n_5, string n_6)
        {
            var result = new N();

            result.N_1 = n_1;
            result.N_2 = n_2;
            result.N_3 = n_3;
            result.N_4 = n_4;
            result.N_5 = n_5;
            result.N_6 = n_6;

            return result;
        }

        private static N N(string n_1, string n_2, string n_3, string n_4, string n_5, string n_6, string n_7)
        {
            var result = new N();

            result.N_1 = n_1;
            result.N_2 = n_2;
            result.N_3 = n_3;
            result.N_4 = n_4;
            result.N_5 = n_5;
            result.N_6 = n_6;
            result.N_7 = n_7;

            return result;
        }

        private static N N(string n_1, string n_2, string n_3, string n_4, string n_5, string n_6, string n_7, string n_8)
        {
            var result = new N();

            result.N_1 = n_1;
            result.N_2 = n_2;
            result.N_3 = n_3;
            result.N_4 = n_4;
            result.N_5 = n_5;
            result.N_6 = n_6;
            result.N_7 = n_7;
            result.N_8 = n_8;

            return result;
        }

        private string Spacer(int n)
        {
            var tmpSb = new StringBuilder();

            for(var i = 0; i < n; i++)
            {
                tmpSb.Append(" ");
            }

            return tmpSb.ToString();
        }

        private string GetStateName(string n_1)
        {
            return GetNodeName(n_1);
        }

        private string GetStateName(string n_1, string n_2)
        {
            return $"{GetNodeName(n_1)}_{GetNodeName(n_2)}";
        }

        private string GetStateName(string n_1, string n_2, string n_3)
        {
            return $"{GetNodeName(n_1)}_{GetNodeName(n_2)}_{GetNodeName(n_3)}";
        }

        private string GetStateName(string n_1, string n_2, string n_3, string n_4)
        {
            return $"{GetNodeName(n_1)}_{GetNodeName(n_2)}_{GetNodeName(n_3)}_{GetNodeName(n_4)}";
        }

        private string GetStateName(string n_1, string n_2, string n_3, string n_4, string n_5)
        {
            return $"{GetNodeName(n_1)}_{GetNodeName(n_2)}_{GetNodeName(n_3)}_{GetNodeName(n_4)}_{GetNodeName(n_5)}";
        }

        private string GetStateName(string n_1, string n_2, string n_3, string n_4, string n_5, string n_6)
        {
            return $"{GetNodeName(n_1)}_{GetNodeName(n_2)}_{GetNodeName(n_3)}_{GetNodeName(n_4)}_{GetNodeName(n_5)}_{GetNodeName(n_6)}";
        }

        private string GetStateName(string n_1, string n_2, string n_3, string n_4, string n_5, string n_6, string n_7)
        {
            return $"{GetNodeName(n_1)}_{GetNodeName(n_2)}_{GetNodeName(n_3)}_{GetNodeName(n_4)}_{GetNodeName(n_5)}_{GetNodeName(n_6)}_{GetNodeName(n_7)}";
        }

        private string GetStateName(string n_1, string n_2, string n_3, string n_4, string n_5, string n_6, string n_7, string n_8)
        {
            return $"{GetNodeName(n_1)}_{GetNodeName(n_2)}_{GetNodeName(n_3)}_{GetNodeName(n_4)}_{GetNodeName(n_5)}_{GetNodeName(n_6)}_{GetNodeName(n_7)}_{GetNodeName(n_8)}";
        }

        private string GetNodeName(string node)
        {
            if(node == NP)
            {
                return NP;
            }

            if (node == QW)
            {
                return QW;
            }

            if(node == PQW)
            {
                return PQW;
            }

            if (node == V)
            {
                return V;
            }

            if(node == Ving)
            {
                return Ving;
            }

            if(node == V3f)
            {
                return V3f;
            }

            if (node == to)
            {
                return "To";
            }

            if (node == not)
            {
                return "Not";
            }

            if (node == have)
            {
                return "Have";
            }

            if (node == will)
            {
                return "Will";
            }

            if (node == must)
            {
                return "Must";
            }

            if (node == can)
            {
                return "Can";
            }

            if (node == _do)
            {
                return "Do";
            }

            if (node == may)
            {
                return "May";
            }

            if (node == could)
            {
                return "Could";
            }

            if (node == might)
            {
                return "Might";
            }

            if (node == be)
            {
                return "Be";
            }

            if (node == able)
            {
                return "Able";
            }

            if (node == F_to_do)
            {
                return "FToDo";
            }

            if (node == F_to_be)
            {
                return "FToBe";
            }

            if (node == F_to_have)
            {
                return "FToHave";
            }

            throw new ArgumentOutOfRangeException(nameof(node), node);
        }

        public void TstCG()
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"TstCG");

            var rootNode = new CGNode();

            rootNode.Kind = CGNodeKind.Concept;
            rootNode.ClassName = "qwerty";

            var child_1 = new CGNode(rootNode);
            child_1.ClassName = "person";
            child_1.InstanceName = "#123";

            NLog.LogManager.GetCurrentClassLogger().Info($"TstCG child_1.Name = {child_1.Name}");

            NLog.LogManager.GetCurrentClassLogger().Info($"TstCG rootNode.Children.Count = {rootNode.Children.Count}");

            var child_2 = new CGNode(rootNode);

            NLog.LogManager.GetCurrentClassLogger().Info($"TstCG rootNode.Children.Count = {rootNode.Children.Count}");

            child_1.AddInputNode(child_2);

            NLog.LogManager.GetCurrentClassLogger().Info($"TstCG child_2.OutputNodes.Count = {child_2.OutputNodes.Count}");

            NLog.LogManager.GetCurrentClassLogger().Info($"End TstCG");
        }
    }
}
