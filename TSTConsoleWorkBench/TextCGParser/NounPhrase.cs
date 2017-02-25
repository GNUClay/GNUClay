using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.TextCGParser
{
    /// <summary>
    /// NP
    /// </summary>
    public class NounPhrase: IPhrase
    {
        public ExtendToken Determiner = null;
        public IPhrase Noun = null;
        public PrepositionalPhrase Prepositional = null;
        public IPhrase Adjective = null;

        public IPhrase Clone(Dictionary<object, object> ptrList)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Clone");

            var result = new NounPhrase();

            if(Determiner != null)
            {
                result.Determiner = Determiner;
                ptrList?.Add(Determiner, result.Determiner);
            }

            if (Noun != null)
            {
                result.Noun = Noun.Clone(ptrList);
                ptrList?.Add(Noun, result.Noun);
            }


            if (Prepositional != null)
            {
                result.Prepositional = (PrepositionalPhrase)Prepositional.Clone(ptrList);
                ptrList?.Add(Prepositional, result.Prepositional);
            }

            if (Adjective != null)
            {
                result.Adjective = Adjective.Clone(ptrList);
                ptrList?.Add(Adjective, result.Adjective);
            }

            return result;
        }

        public string ToDbgString()
        {
            var tmpSb = new StringBuilder();

            tmpSb.Append($"{nameof(Determiner)} = ");

            if(Determiner == null)
            {
                tmpSb.AppendLine("null");
            }
            else
            {
                tmpSb.AppendLine(Determiner.ToDbgString());
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

            tmpSb.Append($"{nameof(Prepositional)} = ");

            if (Prepositional == null)
            {
                tmpSb.AppendLine("null");
            }
            else
            {
                tmpSb.AppendLine(Prepositional.ToDbgString());
            }

            tmpSb.Append($"{nameof(Adjective)} = ");

            if (Adjective == null)
            {
                tmpSb.AppendLine("null");
            }
            else
            {
                tmpSb.AppendLine(Adjective.ToDbgString());
            }

            return tmpSb.ToString();
        }
    }
}
