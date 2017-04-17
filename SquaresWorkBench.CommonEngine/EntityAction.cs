using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresWorkBench.CommonEngine
{
    public enum EntityActionStatus
    {
        Running,
        Completed,
        Faulted
    }

    public class EntityAction : IToStringData
    {
        public EntityAction(Command command)
        {
            Command = command;
        }

        private object mLockObj = new object();

        public Command Command { get; set; } = null;
        private volatile EntityActionStatus mStatus = EntityActionStatus.Running;
         
        public EntityActionStatus Status {
            get
            {
                lock(mLockObj)
                {
                    return mStatus;
                }              
            }

            set
            {
                lock (mLockObj)
                {
                    if(mStatus == value)
                    {
                        return;
                    }

                    if(mStatus == EntityActionStatus.Running)
                    {
                        mStatus = value;

                        switch(mStatus)
                        {
                            case EntityActionStatus.Completed:
                                mCompletedEvent?.Invoke();
                                break;

                            case EntityActionStatus.Faulted:
                                mCompletedEvent?.Invoke();
                                break;
                        }

                        return;
                    }
                }
            }
        }

        private Action mCompletedEvent;
        private Action mFaultedEvent;

        public void OnComlplete(Action action)
        {
            lock(mLockObj)
            {
                switch(mStatus)
                {
                    case EntityActionStatus.Running:
                        mCompletedEvent += action;
                        break;

                    case EntityActionStatus.Completed:
                        action();
                        break;
                }
            }
        }

        public void OnFail(Action action)
        {
            lock (mLockObj)
            {
                switch (mStatus)
                {
                    case EntityActionStatus.Running:
                        mFaultedEvent += action;
                        break;

                    case EntityActionStatus.Completed:
                        action();
                        break;
                }
            }
        }

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. Overrides (Object.ToString)
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString()
        {
            return _ObjectHelper.PrintDefaultToStringInformation(this);
        }

        /// <summary>
        /// Provides string data for method ToString.
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public string ToStringData()
        {
            var tmpSb = new StringBuilder();

            tmpSb.AppendLine($"{nameof(Status)} = {Status}");

            return tmpSb.ToString();
        }

        public static EntityAction Create(Command command)
        {
            return new EntityAction(command);
        }

        public static EntityAction CreateSuccess(Command command)
        {
            var action = new EntityAction(command);
            action.Status = EntityActionStatus.Completed;
            return action;
        }

        public static EntityAction CreateError(Command command)
        {
            var action = new EntityAction(command);
            action.Status = EntityActionStatus.Faulted;
            return action;
        }
    }
}
