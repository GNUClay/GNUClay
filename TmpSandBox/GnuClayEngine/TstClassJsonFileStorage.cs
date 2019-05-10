using GnuClay.CommonClasses.Storages;
using System;
using System.Collections.Generic;
using System.Text;

namespace TmpSandBox.GnuClayEngine
{
    public class TstClassJsonFileStorage: BaseJsonFileStorage<TstClass1>
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
