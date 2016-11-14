using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.StandardLibrary.SupportingMachines
{
    public abstract class BaseTypeProvider : BaseGnuClayEngineComponent, ITypeProvider
    {
        protected BaseTypeProvider(GnuClayEngineComponentContext context, string typeName)
            : base(context)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"BaseTypeProvider typeName = `{typeName}`");

            if(string.IsNullOrWhiteSpace(typeName))
            {
                throw new ArgumentNullException(nameof(typeName));
            }

            mTypeName = typeName;
        }

        private string mTypeName = string.Empty;

        public string TypeName
        {
            get
            {
                return mTypeName;
            }
        }

        private int mTypeKey = 0;

        public int TypeKey
        {
            get
            {
                return mTypeKey;
            }
        }

        public virtual void InitFromZero()
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"InitFromZero TypeName = `{mTypeName}`");
            mTypeKey = Context.DataDictionary.GetKey(mTypeName);
            NLog.LogManager.GetCurrentClassLogger().Info($"InitFromZero TypeName = `{mTypeName}` mTypeKey = {mTypeKey}");
            OnRegType();
        }

        protected abstract void OnRegType();

        protected GCSClassInfo ClassInfo = null;

        protected void RegType<T>()
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"RegType TypeName = `{mTypeName}` mTypeKey = {mTypeKey}");
            ClassInfo = Context.TypeProcessingContext.RegType<T>(this);
        }

        public abstract IValue Create(object value);
    }
}
