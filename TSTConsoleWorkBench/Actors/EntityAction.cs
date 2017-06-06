using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.Actors
{
    public enum EntityActionStatus
    {
        Running,
        Completed,
        Faulted,
        Canceled
    }

    public delegate void OnClarifyParams(List<CommandFilterParam> paramsList);

    public class EntityAction : IToStringData
    {
        public EntityAction(Command command)
        {
            Command = command;
        }

        private object mLockObj = new object();

        public Command Command { get; set; } = null;
        private volatile EntityActionStatus mStatus = EntityActionStatus.Running;

        public EntityActionStatus Status
        {
            get
            {
                lock (mLockObj)
                {
                    return mStatus;
                }
            }

            set
            {
                lock (mLockObj)
                {
                    if (mStatus == value)
                    {
                        return;
                    }

                    if (mStatus == EntityActionStatus.Running)
                    {
                        mStatus = value;

                        switch (mStatus)
                        {
                            case EntityActionStatus.Completed:
                                mCompletedEvent?.Invoke();
                                mFinishedEvent?.Invoke();
                                mFinishedWithOutFailEvent?.Invoke();
                                break;

                            case EntityActionStatus.Faulted:
                                mFaultedEvent?.Invoke();
                                mFinishedEvent?.Invoke();
                                break;

                            case EntityActionStatus.Canceled:
                                AutoCancelInitiatedProcesses();

                                mCanceledEvent?.Invoke();
                                mFinishedWithOutFailEvent?.Invoke();
                                mFinishedEvent?.Invoke();
                                break;
                        }

                        return;
                    }
                }
            }
        }

        public string Name { get; set; } = string.Empty;
        public ulong NameKey { get; set; }
        public Exception Exception { get; set; }

        public void Cancel()
        {
            Status = EntityActionStatus.Canceled;
        }

        private event Action mCompletedEvent;
        private event Action mFaultedEvent;
        private event Action mCanceledEvent;
        private event Action mFinishedEvent;
        private event Action mFinishedWithOutFailEvent;

        public void OnComlplete(Action<EntityAction> action)
        {
            lock (mLockObj)
            {
                switch (mStatus)
                {
                    case EntityActionStatus.Running:
                        mCompletedEvent += async () => {
                            await Task.Run(() => {
                                action(this);
                            });
                        };
                        break;

                    case EntityActionStatus.Completed:
                        Task.Run(() => { action(this); });
                        break;
                }
            }
        }

        public void OnFail(Action<EntityAction> action)
        {
            lock (mLockObj)
            {
                switch (mStatus)
                {
                    case EntityActionStatus.Running:
                        mFaultedEvent += async () =>
                        {
                            await Task.Run(() =>
                            {
                                action(this);
                            });
                        };
                        break;

                    case EntityActionStatus.Faulted:
                        Task.Run(() => { action(this); });
                        break;
                }
            }
        }

        public void OnCancel(Action<EntityAction> action)
        {
            lock (mLockObj)
            {
                switch (mStatus)
                {
                    case EntityActionStatus.Running:
                        mCanceledEvent += async () =>
                        {
                            await Task.Run(() =>
                            {
                                action(this);
                            });
                        };
                        break;

                    case EntityActionStatus.Canceled:
                        Task.Run(() => { action(this); });
                        break;
                }
            }
        }

        public void OnFinish(Action<EntityAction> action)
        {
            lock (mLockObj)
            {
                switch (mStatus)
                {
                    case EntityActionStatus.Running:
                        mFinishedEvent += async () =>
                        {
                            await Task.Run(() =>
                            {
                                action(this);
                            });
                        };
                        break;

                    case EntityActionStatus.Completed:
                    case EntityActionStatus.Faulted:
                    case EntityActionStatus.Canceled:
                        Task.Run(() => { action(this); });
                        break;
                }
            }
        }

        public void OnFinishWithOutFail(Action<EntityAction> action)
        {
            lock (mLockObj)
            {
                switch (mStatus)
                {
                    case EntityActionStatus.Running:
                        mFinishedWithOutFailEvent += async () =>
                        {
                            await Task.Run(() =>
                            {
                                action(this);
                            });
                        };
                        break;

                    case EntityActionStatus.Completed:
                    case EntityActionStatus.Canceled:
                        Task.Run(() => { action(this); });
                        break;
                }
            }
        }

        public EntityAction Initiator
        {
            get
            {
                lock (mLockObj)
                {
                    return mInitiator;
                }
            }

            set
            {
                lock (mLockObj)
                {
                    if(mInitiator == value)
                    {
                        return;
                    }

                    if(mInitiator != null)
                    {
                        mInitiator.RemoveInitiatedAction(this);
                    }

                    mInitiator = value;

                    if(mInitiator != null)
                    {
                        mInitiator.AddInitiatedAction(this);
                    }
                }
            }
        }

        public List<EntityAction> InitiatedActions
        {
            get
            {
                lock (mLockObj)
                {
                    return mInitiatedActions;
                }
            }
        }

        public void AddInitiatedAction(EntityAction initiatedAction)
        {
            lock (mLockObj)
            {
                if(mInitiatedActions.Contains(initiatedAction))
                {
                    return;
                }

                mInitiatedActions.Add(initiatedAction);

                if(initiatedAction.Initiator != this)
                {
                    initiatedAction.Initiator = this;
                }
            }
        }

        public void RemoveInitiatedAction(EntityAction initiatedAction)
        {
            lock (mLockObj)
            {
                if (!mInitiatedActions.Contains(initiatedAction))
                {
                    return;
                }

                mInitiatedActions.Remove(initiatedAction);

                if(initiatedAction.Initiator == this)
                {
                    initiatedAction.Initiator = null;
                }      
            }
        }

        private EntityAction mInitiator = null;
        private List<EntityAction> mInitiatedActions = new List<EntityAction>();

        public bool IsAutoCanceled = true;

        private async void AutoCancelInitiatedProcesses()
        {
            await Task.Run(() => {
                var initiatedActionsList = InitiatedActions.ToList();

                foreach (var initiatedAction in initiatedActionsList)
                {
                    if(initiatedAction.IsAutoCanceled)
                    {
                        Task.Run(() => {
                            initiatedAction.Cancel();
                        });                      
                    }
                }
            });
        }

        private OnClarifyParams mOnClarifyParamsByInitiatedActions = null;

        public void SetOnClarifyParamsByInitiatedActions(OnClarifyParams callBack)
        {
            lock(mLockObj)
            {
                mOnClarifyParamsByInitiatedActions = callBack;
            }
        }

        public void ResetOnClarifyParamsByInitiatedActions()
        {
            lock (mLockObj)
            {
                mOnClarifyParamsByInitiatedActions = null;
            }
        }

        public void ClarifyParamsByInitiatedActions(CommandFilterParam param)
        {
            ClarifyParamsByInitiatedActions(new List<CommandFilterParam>() { param });
        }

        public void ClarifyParamsByInitiatedActions(List<CommandFilterParam> paramsList)
        {
            lock (mLockObj)
            {
                Task.Run(() => {
                    mOnClarifyParamsByInitiatedActions?.Invoke(paramsList);
                });
            }
        }

        private OnClarifyParams mOnClarifyParamsByInitiator = null;

        public void SetOnClarifyParamsByInitiator(OnClarifyParams callBack)
        {
            lock (mLockObj)
            {
                mOnClarifyParamsByInitiator = callBack;
            }
        }

        public void ResetOnClarifyParamsByInitiator()
        {
            lock (mLockObj)
            {
                mOnClarifyParamsByInitiator = null;
            }
        }

        public void ClarifyParamsByInitiator(CommandFilterParam param)
        {
            ClarifyParamsByInitiator(new List<CommandFilterParam>() { param });
        }

        public void ClarifyParamsByInitiator(List<CommandFilterParam> paramsList)
        {
            lock (mLockObj)
            {
                Task.Run(() => {
                    mOnClarifyParamsByInitiator?.Invoke(paramsList);
                });
            }
        }

        private ulong mExclusiveGroupKey = 0;
        private ulong mOldExclusiveGroupKey = 0;
        public ulong ExclusiveGroupKey
        {
            get
            {
                lock (mLockObj)
                {
                    return mExclusiveGroupKey;
                }
            }

            set
            {
                lock (mLockObj)
                {
                    if (mExclusiveGroupKey == value)
                    {
                        return;
                    }

                    f
                }
            }
        }

        public ulong OldExclusiveGroupKey
        {
            get
            {
                lock (mLockObj)
                {
                    return mOldExclusiveGroupKey;
                }
            }
        }

        public event Action OnChangeExclusiveGroupKey;

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
            tmpSb.AppendLine($"{nameof(Command)} = {Command}");
            tmpSb.AppendLine($"{nameof(Name)} = {Name}");
            tmpSb.AppendLine($"{nameof(NameKey)} = {NameKey}");
            tmpSb.AppendLine($"{nameof(Exception)} = {Exception}");
            tmpSb.AppendLine($"{nameof(Initiator)} = {Initiator?.DisplaySmallInfo()}");
            tmpSb.AppendLine($"{nameof(InitiatedActions)} = {_ListHelper._ToString(InitiatedActions)}");

            return tmpSb.ToString();
        }

        public string DisplaySmallInfo()
        {
            var tmpSb = new StringBuilder();

            tmpSb.AppendLine($"{nameof(Status)} = {Status}");
            tmpSb.AppendLine($"{nameof(Command)} = {Command}");
            tmpSb.AppendLine($"{nameof(Name)} = {Name}");
            tmpSb.AppendLine($"{nameof(NameKey)} = {NameKey}");
            tmpSb.AppendLine($"{nameof(Exception)} = {Exception}");
            tmpSb.AppendLine($"{nameof(Initiator)} = {Initiator}");

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
