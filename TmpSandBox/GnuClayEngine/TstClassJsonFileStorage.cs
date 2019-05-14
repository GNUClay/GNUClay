using GnuClay.CommonClasses.FileStorages;
using System;
using System.Collections.Generic;
using System.Text;

namespace TmpSandBox.GnuClayEngine
{
    public class TstClassJsonFileStorage: BaseComplexJsonFileStorage<TstClass1>
    {
        public TstClassJsonFileStorage()
            : base(new TstClassTypeFactory(), 5.2F)
        {
        }

        public override void Clear()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("Clear");
#endif

            Data = new TstClass1();
        }
    }
}
