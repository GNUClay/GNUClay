using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.TextCGParser
{
    public class Sentence
    {
        public NounPhrase Subject = null;
        public ExtendToken Verb = null;
        public NounPhrase Object = null;

        public GrammaticalTenses Tense = GrammaticalTenses.Present;
        public GrammaticalAspect Aspect = GrammaticalAspect.Simple;
        public TypeOfSentence TypeOfSentence = TypeOfSentence.Declaration;

        public string ToDbgString()
        {
            var tmpSb = new StringBuilder();

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

            tmpSb.AppendLine($"{nameof(Tense)} = {Tense}");
            tmpSb.AppendLine($"{nameof(Aspect)} = {Aspect}");
            tmpSb.AppendLine($"{nameof(TypeOfSentence)} = {TypeOfSentence}");

            return tmpSb.ToString();
        }
    }
}
