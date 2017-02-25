using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.TextCGParser
{
    public class TextPhraseContext: BaseATNParserContext
    {
        public TextPhraseContext(List<ExtendToken> tokens)
            : base(tokens)
        {    
        }

        public TextPhraseContext(BaseATNParserContext source)
            : base(source)
        {
        }

        public ATNNodeState State = ATNNodeState.Init;

        public NounPhrase Subject = null;
        public ExtendToken Verb = null;
        public NounPhrase Object = null;

        public TextPhraseContext Clone()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Clone");

            var result = new TextPhraseContext(this);

            result.State = State;
            result.Subject = Subject;
            result.Verb = Verb;
            result.Object = Object;

            return result;
        }

        public string ToDbgString()
        {
            var tmpSb = new StringBuilder();

            tmpSb.AppendLine($"{nameof(State)} = {State}");

            tmpSb.Append($"{nameof(Subject)} = ");

            if (Subject == null)
            {
                tmpSb.AppendLine("null");
            }
            else
            {
                tmpSb.AppendLine(Subject.ToDbgString());
            }

            tmpSb.Append($"{nameof(Verb)} = ");

            if (Verb == null)
            {
                tmpSb.AppendLine("null");
            }
            else
            {
                tmpSb.AppendLine(Verb.ToDbgString());
            }

            tmpSb.Append($"{nameof(Object)} = ");

            if (Object == null)
            {
                tmpSb.AppendLine("null");
            }
            else
            {
                tmpSb.AppendLine(Object.ToDbgString());
            }

            return tmpSb.ToString();
        }
    }
}
