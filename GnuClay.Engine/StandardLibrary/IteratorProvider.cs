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
    public class IteratorProvider : BaseTypeProvider
    {
        public IteratorProvider(GnuClayEngineComponentContext context)
            : base(context, StandartTypeNamesConstants.IteratorName)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("IteratorProvider");
        }

        protected override void OnRegType()
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"OnRegType `{TypeName}` `{TypeKey}`");
            RegType<IteratorValue>();
        }

        public override IValue Create(object value)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"Create `{TypeName}` `{TypeKey}` `{value}`");

            return NCreate((List<IValue>.Enumerator) value);
        }

        public IteratorValue NCreate(List<IValue>.Enumerator value)
        {
            return new IteratorValue(ClassInfo, Context, value);
        }
    }
}
