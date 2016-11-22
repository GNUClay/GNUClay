using GnuClay.Engine.ScriptExecutor.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.StandardLibrary.SupportingMachines
{
    public class GnuClayScriptSystemProperty: IGnuClayAbstractProperty
    {
        public GnuClayScriptSystemProperty(PropertyInfo property)
        {
            mPropertyInfo = property;
        }

        private PropertyInfo mPropertyInfo = null;

        public bool Probing(IValue arg)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"Probing arg = `{arg}`");

            if(mPropertyInfo.PropertyType == arg.GetType())
            {
                return true;
            }

            return false;
        }

        public IValue Set(object obj, IValue arg)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"SetProperty obj = `{obj}` arg = `{arg}`");
            mPropertyInfo.SetValue(obj, arg);
            return arg;
        }

        public IValue Get(object obj)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"SetProperty obj = `{obj}`");
            return (IValue)mPropertyInfo.GetValue(obj);
        }
    }
}
