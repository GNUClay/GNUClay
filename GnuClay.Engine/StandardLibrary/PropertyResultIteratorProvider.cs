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
    public class PropertyResultIteratorProvider : BaseTypeProvider
    {
        public PropertyResultIteratorProvider(GnuClayEngineComponentContext context)
            : base(context, StandartTypeNamesConstants.PropertyResultIteratorName)
        {
        }

        protected override void OnRegType()
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"OnRegType `{TypeName}` `{TypeKey}`");
            RegType<PropertyResultIteratorValue>();
        }

        public override IValue Create(object value)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"Create `{TypeName}` `{TypeKey}` `{value}`");

            return NCreate((List<IValue>.Enumerator)value);
        }

        public PropertyResultIteratorValue NCreate(List<IValue>.Enumerator value)
        {
            return new PropertyResultIteratorValue(ClassInfo, Context, value);
        }
    }
}
