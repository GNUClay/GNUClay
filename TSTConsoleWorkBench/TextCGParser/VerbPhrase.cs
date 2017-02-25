using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.TextCGParser
{
    /// <summary>
    /// VP
    /// </summary>
    public class VerbPhrase: IPhrase
    {
        public ExtendToken Verb = null;
        public IPhrase Object = null;

        public IPhrase Clone(Dictionary<object, object> ptrList)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Clone");

            var result = new VerbPhrase();

            result.Verb = Verb;

            if(Verb != null)
            {
                ptrList?.Add(Verb, result.Verb);
            }
            
            if(Object != null)
            {
                result.Object = Object.Clone(ptrList);
                ptrList?.Add(Object, result.Object);
            }

            return result;
        }

        public string ToDbgString()
        {
            var tmpSb = new StringBuilder();

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
