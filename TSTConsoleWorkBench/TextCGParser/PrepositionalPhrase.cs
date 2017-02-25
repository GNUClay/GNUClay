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

            result.Prepositional = Prepositional;
            ptrList?.Add(result.Prepositional, Prepositional);

            result.Noun = Noun?.Clone(ptrList);
            ptrList?.Add(result.Noun, Noun);

            return result;
        }
    }
}
