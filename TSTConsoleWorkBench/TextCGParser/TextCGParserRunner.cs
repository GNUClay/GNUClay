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

        public void GetarateATNStateTree()
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
                }
            };


        }
    }
}
