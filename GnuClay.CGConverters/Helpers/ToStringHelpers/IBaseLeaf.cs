using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CGConverters.Helpers.ToStringHelpers
{
    public interface IBaseLeaf
    {
        string Name { get; }

        bool IsContainer { get; }

        IBaseLeaf SomeChildLeaf { get; }

        string Text { get; }

        void Run();
    }
}
