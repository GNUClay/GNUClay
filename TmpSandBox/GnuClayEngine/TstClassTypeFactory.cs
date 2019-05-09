using GnuClay.CommonHelpers.JsonSerializationHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace TmpSandBox.GnuClayEngine
{
    public class TstClassTypeFactory: MapTypeFactory
    {
        public TstClassTypeFactory()
            : base((name) => {
                switch (name)
                {
                    case "TmpSandBox.GnuClayEngine.TstClass1":
                        return typeof(TstClass1);

                    case "TmpSandBox.GnuClayEngine.TstClass2":
                        return typeof(TstClass2);

                    case "System.Collections.Generic.List`1[[TmpSandBox.GnuClayEngine.TstClass2]]":
                        return typeof(List<TstClass2>);

                    default:
                        throw new ArgumentOutOfRangeException(nameof(name), name, null);
                }
            })
        {
        }
    }
}
