using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor.CommonData;
using GnuClay.Engine.StandardLibrary.CommonData;
using GnuClay.Engine.StandardLibrary.SupportingMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.StandardLibrary
{
    public class ArrayProvider : BaseTypeProvider
    {
        public ArrayProvider(GnuClayEngineComponentContext context)
            : base(context, StandartTypeNamesConstants.ArrayName)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("ArrayProvider");
        }

        protected override void OnRegType()
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"OnRegType `{TypeName}` `{TypeKey}`");
            RegType<ArrayValue>();
        }

        public override IValue Create(object value)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"Create `{TypeName}` `{TypeKey}` `{value}`");

            return NCreate((List<IValue>)value);
        }

        public ArrayValue NCreate(List<IValue> value)
        {
            return new ArrayValue(ClassInfo, Context, value);
        }
    }
}
