using System.Collections.Generic;

namespace GnuClay.TextCGParser
{
    public interface IPhrase
    {
        IPhrase Clone(Dictionary<object, object> ptrList);
        string ToDbgString();
    }
}
