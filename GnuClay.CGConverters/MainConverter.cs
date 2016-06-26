using GnuClay.CG;
using GnuClay.CGConverters.DOT;
using GnuClay.CGConverters.SGF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CGConverters
{
    public class MainConverter: IMainConverter
    {
        public string ConvertToDotString(IConceptualNode node)
        {
            var tmpConverter = new DotConverter();

            return tmpConverter.ConvertToString(node);
        }

        public IConceptualNode ConvertFromSGFStringToECG(string source)
        {
            var tmpConverter = new SGFConverter(new SGFECGNodeFactory());

            return tmpConverter.ConvertFromString(source);
        }

        public string ConvertToSGFString(IConceptualNode node)
        {
            var tmpConverter = new SGFConverter(new SGFECGNodeFactory());

            return tmpConverter.ConvertToString(node);
        }

        public string ConvertFromSGFToDotString(string source)
        {
            var tmpSGFConverter = new SGFConverter(new SGFECGNodeFactory());

            var tmpNode = tmpSGFConverter.ConvertFromString(source);

            var tmpDotConverter = new DotConverter();

            return tmpDotConverter.ConvertToString(tmpNode);
        }
    }
}
