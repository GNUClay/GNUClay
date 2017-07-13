using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.ScriptExecuting
{
    public class NewEntityAction: INewValue
    {
        public NewEntityAction(string name, ulong key, NewCommand command, ulong typeKey)
        {
            Name = name;
            Key = key;
            Command = command;
            TypeKey = typeKey;
        }

        private object mLockObj = new object();

        public ulong TypeKey { get; private set; }

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

        public INewValue Result { get; set; }
        public INewValue Error { get; set; }

        public ulong Initiator { get;  set; }
        public List<ulong> InitiatedActions { get; set; } = new List<ulong>();

        public ulong GetLongHashCode()
        {
            return Key;
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
            tmpSb.AppendLine($"{nameof(Result)} = {Result }");
            tmpSb.AppendLine($"{nameof(Error)} = {Error}");
            tmpSb.AppendLine($"{nameof(Initiator)} = {Initiator}");
            tmpSb.AppendLine($"{nameof(InitiatedActions)} = {_ListHelper._ToString(InitiatedActions)}");

            return tmpSb.ToString();
        }
    }
}
