using GnuClay.CommonClientTypes.ResultTypes;
using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Console
{
    public class ConsoleEngine : BaseGnuClayEngineComponent
    {
        public ConsoleEngine(GnuClayEngineComponentContext context)
            : base(context)
        {
        }

        private object mLockObj = new object();

        public ulong AddLogHandler(Action<IExternalValue> handler)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"AddLogHandler handler = {handler}");
#endif
            lock(mLockObj)
            {
                mCurrentIndex++;

                var desctiptor = mCurrentIndex;

                mHandlersDict[desctiptor] = handler;

                return desctiptor;
            }
        }

        public void RemoveLogHandler(ulong descriptor)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"RemoveLogHandler descriptor = {descriptor}");
#endif

            lock (mLockObj)
            {
                if(mHandlersDict.ContainsKey(descriptor))
                {
                    mHandlersDict.Remove(descriptor);
                }
            }
        }

        public void Emit(IValue value)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Emit value = {value}");
#endif

            throw new NotImplementedException();
        }

        private ulong mCurrentIndex = 0;

        private Dictionary<ulong, Action<IExternalValue>> mHandlersDict = new Dictionary<ulong, Action<IExternalValue>>();
    }
}
