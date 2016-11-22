using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.StandardLibrary.SupportingMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GnuClay.Engine.StandardLibrary.CommonData
{
    public class NumberValue : BaseValue
    {
        public NumberValue(GCSClassInfo classInfo, GnuClayEngineComponentContext context, double value)
            : base(classInfo, context)
        {
            mValue = value;

            NLog.LogManager.GetCurrentClassLogger().Info($"NumberValue mValue = `{mValue}`");
        }

        private double mValue = 0;

        public override object ToExternal()
        {
            return mValue;
        }

        public override string ToString()
        {
            return $"NumberValue: {mValue}";
        }
    }
}
