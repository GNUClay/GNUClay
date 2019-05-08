using GnuClay.CommonClases.Storages;
using System;
using System.Collections.Generic;
using System.Text;

namespace TmpSandBox.GnuClayEngine
{
    public class TstClassJsonFileStorage: BaseJsonFileStorage<TstClass1>
    {
        public TstClassJsonFileStorage()
            : base(new TstClassTypeFactory())
        {
        }

        public override void Clear()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("Clear");
#endif

            Instance = new TstClass1();
        }
    }
}
