using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.TextCGParser
{
    /// <summary>
    /// AP
    /// </summary>
    public class AdjectivePhrase: IPhrase
    {
        public ExtendToken Adjective = null;
        public ExtendToken Adverb = null;

        public IPhrase Clone(Dictionary<object, object> ptrList)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Clone");

            var result = new AdjectivePhrase();

            if ( != null)
            {

            }

            result.Adjective = Adjective;

            ptrList?.Add(Adjective, result.Adjective);

            if ( != null)
            {

            }

            result.Adverb = Adverb;

            ptrList?.Add(Adverb, result.Adverb);

            return result;
        }
    }
}
