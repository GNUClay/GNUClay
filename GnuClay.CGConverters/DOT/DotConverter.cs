using GnuClay.CG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CGConverters.DOT
{
    public class DotConverter: IConverter
    {
        public string ConvertToString(IConceptualNode node)
        {
            var tmpContext = new DotContext();

            var tmpMainLeaf = new RootGraphDotLeaf(tmpContext, node);

            tmpMainLeaf.Run();

            return tmpMainLeaf.Text;
        }

        public IConceptualNode ConvertFromString(string source)
        {
            throw new NotImplementedException();
        }
    }
}
