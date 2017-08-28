﻿using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.Engine.ScriptExecutor.CommonData;
using GnuClay.Engine.ScriptExecutor.InternalScriptExecutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor
{
    [Serializable]
    public class EntityAction : BaseSystemType
    {
        public EntityAction(ulong key, Command command, ulong typeKey)
            : base(typeKey)
        {
            Key = key;
            Command = command;
        }

        private object mLockObj = new object();

        public ulong Key { get; private set; }

        public Command Command { get; private set; }

        private EntityActionState mState = EntityActionState.Init;

        public EntityActionState State
        {
            get
            {
                lock (mLockObj)
                {
                    return mState;
                }
            }

            set
            {
                lock (mLockObj)
                {
                    if (mState == value)
                    {
                        return;
                    }

                    mState = value;
                }
            }
        }

        public IValue Result { get; set; }
        public IValue Error { get; set; }

        public void AppendResultOfResultOfCalling(ResultOfCalling resultOfCalling)
        {
            if(resultOfCalling.Success)
            {
                Result = resultOfCalling.Result;
                State = EntityActionState.Completed;
                return;
            }

            Error = resultOfCalling.Error;
            State = EntityActionState.Faulted;
        }

        public ulong Initiator { get; set; }
        public List<ulong> InitiatedActions { get; set; } = new List<ulong>();

        public override ulong GetLongHashCode()
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

            tmpSb.AppendLine($"{nameof(Key)} = {Key}");
            tmpSb.AppendLine($"{nameof(Command)} = {Command}");
            tmpSb.AppendLine($"{nameof(State)} = {State}");
            tmpSb.AppendLine($"{nameof(Result)} = {Result}");
            tmpSb.AppendLine($"{nameof(Error)} = {Error}");
            tmpSb.AppendLine($"{nameof(Initiator)} = {Initiator}");
            tmpSb.AppendLine($"{nameof(InitiatedActions)} = {_ListHelper._ToString(InitiatedActions)}");

            return tmpSb.ToString();
        }
    }
}
