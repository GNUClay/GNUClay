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

            if ( != null)
            {

            }

            result.Adjective = Adjective?.Clone(ptrList);

            ptrList?.Add(Adjective, result.Adjective);

            return result;
        }
    }
}
