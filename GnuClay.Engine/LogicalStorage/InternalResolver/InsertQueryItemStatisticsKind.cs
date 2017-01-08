using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.LogicalStorage.InternalResolver
{
    public enum InsertQueryItemStatisticsKind
    {
        Unknown,
        Rule,
        Fact,
        RemoveFact,
        SetInheritence,
        RemoveInheritence
    }
}
