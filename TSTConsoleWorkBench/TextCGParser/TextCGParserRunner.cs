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

            var tmpLexer = new Lexer(targetPhrase);

            Token CurrToken = null;

            while ((CurrToken = tmpLexer.GetToken()) != null)
            {
                NLog.LogManager.GetCurrentClassLogger().Info(CurrToken);
            }
        }
    }
}
