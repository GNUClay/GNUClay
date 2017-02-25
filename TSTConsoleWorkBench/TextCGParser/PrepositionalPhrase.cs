using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.TextCGParser
{
    /// <summary>
    /// PP
    /// </summary>
    public class PrepositionalPhrase: IPhrase
    {
        public ExtendToken Prepositional = null;
        public IPhrase Noun = null;

        public IPhrase Clone(Dictionary<object, object> ptrList)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Clone");

            var result = new PrepositionalPhrase();

            if(Prepositional != null)
            {
                result.Prepositional = Prepositional;
                ptrList?.Add(result.Prepositional, Prepositional);
            }

            if (Noun != null)
            {
                result.Noun = Noun.Clone(ptrList);
                ptrList?.Add(result.Noun, Noun);
            }

            return result;
        }

        public string ToDbgString()
        {
            var tmpSb = new StringBuilder();

            tmpSb.Append($"{nameof(Prepositional)} = ");

            if (Prepositional == null)
            {
                tmpSb.AppendLine("null");
            }
            else
            {
                tmpSb.AppendLine(Prepositional.ToDbgString());
            }

            tmpSb.Append($"{nameof(Noun)} = ");

            if (Noun == null)
            {
                tmpSb.AppendLine("null");
            }
            else
            {
                tmpSb.AppendLine(Noun.ToDbgString());
            }

            return tmpSb.ToString();
        }
    }
}
