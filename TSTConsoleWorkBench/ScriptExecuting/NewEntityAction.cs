using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.ScriptExecuting
{
    public class NewEntityAction
    {
        public NewEntityAction(string name, ulong key, NewCommand command)
        {
            Name = name;
            Key = key;
            Command = command;
        }

        private object mLockObj = new object();

        public string Name { get; private set; }
        public ulong Key { get; private set; }
        public NewCommand Command { get; private set; }

        private NewEntityActionState mState = NewEntityActionState.Init;

        public NewEntityActionState State
        {
            get
            {
                lock(mLockObj)
                {
                    return mState;
                }
            }

            set
            {
                lock (mLockObj)
                {
                    if(mState == value)
                    {
                        return;
                    }

                    mState = value;
                }
            }
        }

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. Overrides (Object.ToString)
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString()
        {
            var tmpSb = new StringBuilder();

            tmpSb.AppendLine($"{nameof(Name)} = {Name }");
            tmpSb.AppendLine($"{nameof(Key)} = {Key}");
            tmpSb.AppendLine($"{nameof(Command)} = {Command}");
            tmpSb.AppendLine($"{nameof(State)} = {State}");

            return tmpSb.ToString();
        }
    }
}
