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
    public class PropertyResultProvider : BaseTypeProvider
    {
        public PropertyResultProvider(GnuClayEngineComponentContext context)
            : base(context, StandartTypeNamesConstants.PropertyResultName)
        {
        }

        protected override void OnRegType()
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"OnRegType `{TypeName}` `{TypeKey}`");
            RegType<PropertyResultValue>();
        }

        public override IValue Create(object value)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"Create `{TypeName}` `{TypeKey}` `{value}`");

            return NCreate((List<IValue>)value);
        }

        public PropertyResultValue NCreate(List<IValue> value)
        {
            return new PropertyResultValue(ClassInfo, Context, value);
        }
    }
}
