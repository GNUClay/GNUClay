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

            var tmpLexer = new ExtendTextLexer(targetPhrase, context);

            ExtendToken CurrToken = null;

            try
            {
                while ((CurrToken = tmpLexer.GetToken()) != null)
                {
                    NLog.LogManager.GetCurrentClassLogger().Info(CurrToken);
                }
            }
            catch(Exception e)
            {
                NLog.LogManager.GetCurrentClassLogger().Info(e);
            }
        }

        private TextParsingContex CreateContext()
        {
            var context = new TextParsingContex();

            context.Engine = new GnuClayEngine();

            var dataDictionary = context.Engine.DataDictionary;

            InitPartOfSpeechKeys(context);

            dataDictionary.TSTDump();

            return context;
        }

        private void InitPartOfSpeechKeys(TextParsingContex context)
        {
            var dataDictionary = context.Engine.DataDictionary;

            context.NounKey = dataDictionary.GetKey("noun");
        }
    }
}
