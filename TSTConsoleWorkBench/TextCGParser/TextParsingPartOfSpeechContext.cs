using GnuClay.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.TextCGParser
{
    public class TextParsingPartOfSpeechContext: BaseTextParsingContext
    {
        public TextParsingPartOfSpeechContext(GnuClayEngine engine)
            : base(engine)
        {
            NLog.LogManager.GetCurrentClassLogger().Info(nameof(TextParsingPartOfSpeechContext));

            Init();
        }

        private void Init()
        {
            NounKey = DataDictionary.GetKey("noun");
            PronounKey = DataDictionary.GetKey("pronoun");
            AdjectiveKey = DataDictionary.GetKey("adjective");
            VerbKey = DataDictionary.GetKey("verb");
            AdverbKey = DataDictionary.GetKey("adverb");
            PrepositionKey = DataDictionary.GetKey("preposition");
            ConjunctionKey = DataDictionary.GetKey("conjunction");
            InterjectionKey = DataDictionary.GetKey("interjection");
            ArticleKey = DataDictionary.GetKey("article");
        }

        public ulong NounKey = 0;
        public ulong PronounKey = 0;
        public ulong AdjectiveKey = 0;
        public ulong VerbKey = 0;
        public ulong AdverbKey = 0;
        public ulong PrepositionKey = 0;
        public ulong ConjunctionKey = 0;
        public ulong InterjectionKey = 0;
        public ulong ArticleKey = 0;
    }
}
