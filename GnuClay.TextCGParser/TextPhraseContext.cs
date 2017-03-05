using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.TextCGParser
{
    public class TextPhraseContext : BaseATNParserContext
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
        public ExtendTokenGoal TailState = ExtendTokenGoal.Undefined;

        public NounPhrase PQW = null;
        public NounPhrase QW = null;
        public NounPhrase Subject = null;
        public ExtendToken Verb = null;
        public NounPhrase Object = null;

        public ExtendToken AdditionalVerb = null;

        public TextPhraseContext Clone()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Clone");

            var result = new TextPhraseContext(this);

            result.PQW = PQW;
            result.QW = QW;
            result.State = State;
            result.TailState = TailState;
            result.Subject = Subject;
            result.Verb = Verb;
            result.Object = Object;
            result.AdditionalVerb = AdditionalVerb;

            return result;
        }

        public string ToDbgString()
        {
            var tmpSb = new StringBuilder();

            tmpSb.AppendLine($"{nameof(State)} = {State}");
            tmpSb.AppendLine($"{nameof(TailState)} = {TailState}");

            tmpSb.Append($"{nameof(PQW)} = ");

            if (PQW == null)
            {
                tmpSb.AppendLine("null");
            }
            else
            {
                tmpSb.AppendLine(PQW.ToDbgString());
            }

            tmpSb.Append($"{nameof(QW)} = ");

            if (QW == null)
            {
                tmpSb.AppendLine("null");
            }
            else
            {
                tmpSb.AppendLine(QW.ToDbgString());
            }

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

            tmpSb.Append($"{nameof(AdditionalVerb)} = ");

            if (AdditionalVerb == null)
            {
                tmpSb.AppendLine("null");
            }
            else
            {
                tmpSb.AppendLine(AdditionalVerb.ToDbgString());
            }
            return tmpSb.ToString();
        }
    }
}
