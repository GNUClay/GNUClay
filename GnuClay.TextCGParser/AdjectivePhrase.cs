using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.TextCGParser
{
    /// <summary>
    /// AP
    /// </summary>
    public class AdjectivePhrase : IPhrase
    {
        public ExtendToken Adjective = null;
        public ExtendToken Adverb = null;

        public IPhrase Clone(Dictionary<object, object> ptrList)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Clone");

            var result = new AdjectivePhrase();

            if (Adjective != null)
            {
                result.Adjective = Adjective;
                ptrList?.Add(Adjective, result.Adjective);
            }

            if (Adverb != null)
            {
                result.Adverb = Adverb;
                ptrList?.Add(Adverb, result.Adverb);
            }

            return result;
        }

        public string ToDbgString()
        {
            var tmpSb = new StringBuilder();

            tmpSb.Append($"{nameof(Adjective)} = ");

            if (Adjective == null)
            {
                tmpSb.AppendLine("null");
            }
            else
            {
                tmpSb.AppendLine(Adjective.ToDbgString());
            }

            tmpSb.Append($"{nameof(Adverb)} = Adverb");

            if (Adverb == null)
            {
                tmpSb.AppendLine("null");
            }
            else
            {
                tmpSb.AppendLine(Adverb.ToDbgString());
            }

            return tmpSb.ToString();
        }
    }
}
