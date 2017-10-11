using GnuClay.CommonClientTypes.CommonData;
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
            lock(mLockObj)
            {
                var handlers = mHandlersDict.ToList();
                var externalValue = value.ToExternalValue();

                var listOfTasks = new List<Task>();

                foreach (var handler in handlers)
                {
                    var task = Task.Run(() =>
                    {
                        handler.Value?.Invoke(externalValue);
                    });

                    listOfTasks.Add(task);
                }

                Task.WaitAll(listOfTasks.ToArray());
            }
        }

        private ulong mCurrentIndex = 0;

        private Dictionary<ulong, Action<IExternalValue>> mHandlersDict = new Dictionary<ulong, Action<IExternalValue>>();
    }
}
