using GnuClay.Engine;
using GnuClay.Engine.Parser.InternalParsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.TextCGParser
{
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

            var queryStr = "INSERT {>: {`part of speech`(the, article)}}, { >: {root(the, the)}}, {>: {number(the, plural)}}, {>: {number(the, singular)}}";
            engine.Query(queryStr);

            queryStr = "INSERT {>: {`part of speech`(dog, noun)}}, {>: {root(dog, dog)}}, { >: {number(dog, singular)}}";
            engine.Query(queryStr);

            queryStr = "INSERT {>: {`part of speech`(like, verb)}}, { >: {tense(like, present)}}";
            engine.Query(queryStr);

            queryStr = "INSERT {>: {`part of speech`(likes, verb)}}, { >: {tense(likes, present)}}";
            engine.Query(queryStr);

            queryStr = "INSERT {>: {`part of speech`(man, noun)}}";
            engine.Query(queryStr);
        }

        private const string NP = "NP";
        private const string QW = "QW";
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
        private const string abble = "able";
        private const string F_to_do = "(f to do)";
        private const string F_to_be = "(f to be)";
        private const string F_to_have = "(f to have)";

        private class N
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

        public void CreateATNStateTree()
        {
            var nodes = new List<N>()
            {
                new N()
                {
                    N_1 = NP,
                    N_2 = V
                },
                new N ()
                {
                    N_1 = NP,
                    N_2 = F_to_do,
                    N_3 = not,
                    N_4 = V
                },
                new N()
                {
                    N_1 = QW,
                    N_2 = V
                },
                new N ()
                {
                    N_1 = QW,
                    N_2 = F_to_do,
                    N_3 = not,
                    N_4 = V
                },
                new N()
                {
                    N_1 = F_to_do,
                    N_2 = NP,
                    N_3 = V
                },
                new N()
                {
                    N_1 = F_to_do,
                    N_2 = not,
                    N_3 = NP,
                    N_4 = V
                },
                new N()
                {
                    N_1 = QW,
                    N_2 = F_to_do,
                    N_3 = NP,
                    N_4 = V
                },
                new N()
                {
                    N_1 = QW,
                    N_2 = F_to_do,
                    N_3 = not,
                    N_4 = NP,
                    N_5 = V
                },
                new N()
                {
                    N_1 = NP,
                    N_2 = will,
                    N_3 = V
                },
                new N()
                {
                    N_1 = NP,
                    N_2 = will,
                    N_3 = not,
                    N_4 = V
                },
                new N()
                {
                    N_1 = QW,
                    N_2 = will,
                    N_3 = V
                },
                new N()
                {
                    N_1 = QW,
                    N_2 = will,
                    N_3 = not,
                    N_4 = V
                },
                new N()
                {
                    N_1 = will,
                    N_2 = NP,
                    N_3 = V
                }
            };

            var N1List = nodes.GroupBy(p => p.N_1).ToDictionary(p => p.Key, p => p.ToList());

            var n = 0;

            foreach(var node in N1List)
            {
                var n_1 = node.Key;

                var stateName = GetStateName(n_1);

                n++;

                NLog.LogManager.GetCurrentClassLogger().Info($"CreateATNStateTree n_1 = {n_1} stateName = {stateName} n = {n}");

                var N2List = node.Value.GroupBy(p => p.N_2).ToDictionary(p => p.Key, p => p.ToList());

                foreach(var subNode_2 in N2List)
                {
                    var n_2 = subNode_2.Key;

                    stateName = GetStateName(n_1, n_2);

                    n++;

                    NLog.LogManager.GetCurrentClassLogger().Info($"CreateATNStateTree {Spacer(1)} n_2 = {n_2} stateName = {stateName} n = {n}");

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

            if (node == abble)
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
    }
}
