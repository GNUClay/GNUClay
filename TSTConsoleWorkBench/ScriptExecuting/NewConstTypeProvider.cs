using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.ScriptExecuting
{
    public class NewConstTypeProvider
    {
        public void AddProvider(INewConcreteTypeProvider concreteTypeProvider)
        {
            mDict[concreteTypeProvider.TypeKey] = concreteTypeProvider;
        }

        private Dictionary<ulong, INewConcreteTypeProvider> mDict = new Dictionary<ulong, INewConcreteTypeProvider>();

        public INewValue CreateConstValue(ulong typeKey, object value)
        {
            return mDict[typeKey].CreateConstValue(typeKey, value);
        }
    }
}
