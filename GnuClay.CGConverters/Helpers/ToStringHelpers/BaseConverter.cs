using GnuClay.CG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CGConverters.Helpers.ToStringHelpers
{
    public abstract class BaseConverter<T>: IConverter where T : ILeafContext, new()
    {
        public virtual string ConvertToString(IConceptualNode node)
        {
            var tmpContext = new T();

            var tmpMainLeaf = tmpContext.LeafFactory.CreateRootLeaf(tmpContext, node);

            tmpMainLeaf.Run();

            return tmpMainLeaf.Text;
        }

        public virtual IConceptualNode ConvertFromString(string source)
        {
            throw new NotImplementedException();
        }
    }
}
