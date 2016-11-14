using GnuClay.Engine.StandardLibrary.SupportingMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GnuClay.Engine.StandardLibrary.CommonData
{
    public class NumberValue : BaseValue
    {
        public NumberValue(GCSClassInfo classInfo, int value)
            : base(classInfo)
        {
            mValue = value;

            NLog.LogManager.GetCurrentClassLogger().Info($"NumberValue mValue = `{mValue}`");
        }

        private int mValue = 0;

        public override string ToString()
        {
            return $"NumberValue: {mValue}";
        }
    }
}
