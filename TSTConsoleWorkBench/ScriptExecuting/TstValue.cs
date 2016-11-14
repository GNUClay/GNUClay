using GnuClay.Engine.ScriptExecutor.CommonData;
using GnuClay.Engine.StandardLibrary.CommonData;
using GnuClay.Engine.StandardLibrary.SupportingMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.ScriptExecuting
{
    public class TstValue: BaseValue
    {
        public TstValue(GCSClassInfo classInfo, int value)
            : base(classInfo)
        {
            mValue = value;

            NLog.LogManager.GetCurrentClassLogger().Info($"TstValue mValue = `{mValue}`");
        }

        private int mValue = 0;

        /*[GCSMember]
        public void SecondMethod()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("SecondMethod");
        }*/

        [GCSMember]
        public IValue SomeMethod()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("SomeMethod");

            return new NumberValue(ClassInfo, 1);
        }

        [GCSMember]
        public void SecondMethod(NumberValue num = null)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"SecondMethod num = `{num}`");
        }

        [GCSMember]
        public IValue SomeProperty
        {
            get                                                          
            {                       
                NLog.LogManager.GetCurrentClassLogger().Info("get SomeMethod");
                return new NumberValue(ClassInfo, 12);
            }

            set
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"set SomeMethod num = `{value}`");
            }
        }
    }
}
