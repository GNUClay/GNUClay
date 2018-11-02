using MyNPCLib.NLToCGParsing;
using MyNPCLib.NLToCGParsing.PhraseTree;
using MyNPCLib.SimpleWordsDict;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2
{
    public class ContextOfATNParsing_v2: IObjectToString
    {
        public ContextOfATNParsing_v2(string text, IWordsDict wordsDict, CommonContextOfATNParsing_v2 commonContext)
        {
            CommonContext = commonContext;
            mATNExtendedLexer = new ATNExtendedLexer(text, wordsDict);
        }

        private ContextOfATNParsing_v2()
        {
        }

        private CommonContextOfATNParsing_v2 CommonContext;
        private ATNExtendedLexer mATNExtendedLexer;
        public Sentence Sentence { get; set; }
        public Stack<BaseNounLikePhrase> OperativeNounPhrasesStack = new Stack<BaseNounLikePhrase>();
        public void AddNounLikePhrase(BaseNounLikePhrase nounPhrase)
        {
            OperativeNounPhrasesStack.Push(nounPhrase);
        }

        public BaseNounLikePhrase PeekCurrentNounPhrase()
        {
            if (OperativeNounPhrasesStack.Count == 0)
            {
                return null;
            }

            return OperativeNounPhrasesStack.Peek();
        }

        public Stack<VerbPhrase> OperativeVerbPhraseStack = new Stack<VerbPhrase>();

        public void AddVerbPhrase(VerbPhrase verbPhrase)
        {
            OperativeVerbPhraseStack.Push(verbPhrase);
        }

        public VerbPhrase PeekCurrentVerbPhrase()
        {
            if (OperativeVerbPhraseStack.Count == 0)
            {
                return null;
            }

            return OperativeVerbPhraseStack.Peek();
        }

        public ContextOfATNParsing_v2 Fork()
        {
            var result = new ContextOfATNParsing_v2();
            result.CommonContext = CommonContext;
            result.mATNExtendedLexer = mATNExtendedLexer.Fork();
            result.Sentence = Sentence?.Fork();
            return result;
        }

        public IList<ATNExtendedToken> GetСlusterOfExtendedTokens()
        {
            return mATNExtendedLexer.GetСlusterOfExtendedTokens();
        }

        public void PutSentenceToResult()
        {
            CommonContext.AddSentence(Sentence);
        }

        public override string ToString()
        {
            return ToString(0u);
        }

        public string ToString(uint n)
        {
            return this.GetDefaultToStringInformation(n);
        }

        public string PropertiesToSting(uint n)
        {
            var spaces = StringHelper.Spaces(n);
            var nextN = n + 4;
            var sb = new StringBuilder();
            if (Sentence == null)
            {
                sb.AppendLine($"{spaces}{nameof(Sentence)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(Sentence)}");
                sb.Append(Sentence.ToString(nextN));
                sb.AppendLine($"{spaces}End {nameof(Sentence)}");
            }
            if (OperativeNounPhrasesStack == null)
            {
                sb.AppendLine($"{spaces}{nameof(OperativeNounPhrasesStack)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(OperativeNounPhrasesStack)}");
                var operativeNounPhrasesList = OperativeNounPhrasesStack.ToList();
                foreach (var operativeNounPhrase in operativeNounPhrasesList)
                {
                    sb.Append(operativeNounPhrase.ToString(nextN));
                }
                sb.AppendLine($"{spaces}End {nameof(OperativeNounPhrasesStack)}");
            }
            if (OperativeVerbPhraseStack == null)
            {
                sb.AppendLine($"{spaces}{nameof(OperativeVerbPhraseStack)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(OperativeVerbPhraseStack)}");
                var operativeVerbPhraseList = OperativeVerbPhraseStack.ToList();
                foreach (var operativeVerbPhrase in OperativeVerbPhraseStack)
                {
                    sb.Append(operativeVerbPhrase.ToString(nextN));
                }
                sb.AppendLine($"{spaces}End {nameof(OperativeVerbPhraseStack)}");
            }
            return sb.ToString();
        }
    }
}
