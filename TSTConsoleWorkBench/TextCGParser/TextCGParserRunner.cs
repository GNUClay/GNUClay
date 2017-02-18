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
    }
}
