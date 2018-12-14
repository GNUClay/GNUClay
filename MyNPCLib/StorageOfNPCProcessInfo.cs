using MyNPCLib.LogicalSoundModeling;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib
{
    public class StorageOfNPCProcessInfo : IDisposable
    {
        public StorageOfNPCProcessInfo(IEntityLogger entityLogger, IEntityDictionary entityDictionary, NPCProcessInfoCache npcProcessInfoCache)
        {
            mEntityLogger = entityLogger;
            mFactory = new NPCProcessInfoFactory(entityLogger, entityDictionary);
            mNPCProcessInfoCache = npcProcessInfoCache;
        }

        #region private members
        private IEntityLogger mEntityLogger;
        private object mLockObj = new object();
        private NPCProcessInfoCache mNPCProcessInfoCache;
        private NPCProcessInfoFactory mFactory;
        private Dictionary<Type, NPCProcessInfo> mNPCProcessInfoDictByType = new Dictionary<Type, NPCProcessInfo>();
        private Dictionary<ulong, NPCProcessInfo> mNPCProcessInfoDictByKey = new Dictionary<ulong, NPCProcessInfo>();
        private readonly object mDisposeLockObj = new object();
        private bool mIsDisposed;
        private readonly object mSoundProcessesLockObj = new object();
        private Dictionary<string, NPCProcessInfo> mNPCProcessInfoDictByLogicalSoundActions = new Dictionary<string, NPCProcessInfo>();
        private NPCProcessInfo mNPCProcessInfoForLogicalSoundEntityCondition;
        private NPCProcessInfo mNPCProcessInfoForLogicalSoundFact;
        #endregion

        [MethodForLoggingSupport]
        protected void Log(string message)
        {
            mEntityLogger?.Log(message);
        }

        [MethodForLoggingSupport]
        protected void Error(string message)
        {
            mEntityLogger?.Error(message);
        }

        [MethodForLoggingSupport]
        protected void Warning(string message)
        {
            mEntityLogger?.Warning(message);
        }

        public bool AddTypeOfProcess(Type type)
        {
#if DEBUG
            //Log($"type = {type?.FullName}");
#endif

            lock (mDisposeLockObj)
            {
                if (mIsDisposed)
                {
                    throw new ElementIsNotActiveException();
                }
            }

            if(type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            return NAddTypeOfProcess(type).Key;        
        }

        public bool AddTypeOfProcess(Type type, SoundEventProcessOptions soundEventProcessOptions)
        {
#if DEBUG
            Log($"type = {type?.FullName}");
            Log($"soundEventProcessOptions = {soundEventProcessOptions}");
#endif

            var resultOfTypeOfProcess = NAddTypeOfProcess(type);

            var boolResult = resultOfTypeOfProcess.Key;

#if DEBUG
            Log($"boolResult = {boolResult}");
#endif

            if (!boolResult)
            {
                return false;
            }

            var processInfo = resultOfTypeOfProcess.Value;

#if DEBUG
            Log($"processInfo == null = {processInfo == null}");
#endif

            lock (mSoundProcessesLockObj)
            {
                var kindOfSoundEvent = soundEventProcessOptions.Kind;

#if DEBUG
                Log($"kindOfSoundEvent = {kindOfSoundEvent}");
#endif

                switch (kindOfSoundEvent)
                {
                    case KindOfSoundEvent.EntityCondition:
                        mNPCProcessInfoForLogicalSoundEntityCondition = processInfo;
#if DEBUG
                        LogInstance.Log($"mNPCProcessInfoForLogicalSoundEntityCondition == null = {mNPCProcessInfoForLogicalSoundEntityCondition == null}");
#endif
                        break;

                    case KindOfSoundEvent.Command:
                        {
                            mNPCProcessInfoDictByLogicalSoundActions[soundEventProcessOptions.ActionName] = processInfo;
                        }
                        break;

                    case KindOfSoundEvent.Fact:
                        mNPCProcessInfoForLogicalSoundFact = processInfo;
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(nameof(kindOfSoundEvent), kindOfSoundEvent, null);
                }
            }

            return true;
        }

        private KeyValuePair<bool, NPCProcessInfo> NAddTypeOfProcess(Type type)
        {
            lock (mLockObj)
            {
                if (mNPCProcessInfoDictByType.ContainsKey(type))
                {
                    return new KeyValuePair<bool, NPCProcessInfo>(false, null);
                }

                NPCProcessInfo info = null;

                if (mNPCProcessInfoCache != null)
                {
                    info = mNPCProcessInfoCache.Get(type);
                }

                if (info == null)
                {
                    info = mFactory.CreateInfo(type);

                    if (mNPCProcessInfoCache != null)
                    {
                        var resultOfPutToCache = mNPCProcessInfoCache.Set(info);

                        if (resultOfPutToCache == false)
                        {
                            info = mNPCProcessInfoCache.Get(type);
                        }
                    }
                }

                if (info != null)
                {
                    var key = info.Key;

                    if (mNPCProcessInfoDictByKey.ContainsKey(key))
                    {
                        return new KeyValuePair<bool, NPCProcessInfo>(false, null);
                    }

                    mNPCProcessInfoDictByType[type] = info;
                    mNPCProcessInfoDictByKey[key] = info;
                }

                return new KeyValuePair<bool, NPCProcessInfo>(true, info);
            }
        }

        public NPCProcessInfo GetNPCProcessInfo(Type type)
        {
#if DEBUG
            //Log($"type = {type?.FullName}");
#endif

            lock (mDisposeLockObj)
            {
                if (mIsDisposed)
                {
                    throw new ElementIsNotActiveException();
                }
            }

            if(type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            lock (mLockObj)
            {
                if(mNPCProcessInfoDictByType.ContainsKey(type))
                {
                    return mNPCProcessInfoDictByType[type];
                }

                return null;
            }
        }

        public NPCProcessInfo GetNPCProcessInfo(ulong key)
        {
#if DEBUG
            //Log($"key = {key}");
#endif

            lock (mDisposeLockObj)
            {
                if (mIsDisposed)
                {
                    throw new ElementIsNotActiveException();
                }
            }

            if (key == 0u)
            {
                throw new ArgumentNullException(nameof(key));
            }

            lock (mLockObj)
            {
                if(mNPCProcessInfoDictByKey.ContainsKey(key))
                {
                    return mNPCProcessInfoDictByKey[key];
                }

                return null;
            }
        }

        public NPCProcessInfo GetNPCProcessInfo(LogicalSoundInfo logicalSoundInfo)
        {
            lock (mDisposeLockObj)
            {
                if (mIsDisposed)
                {
                    throw new ElementIsNotActiveException();
                }
            }

            lock (mSoundProcessesLockObj)
            {
                var kindOfSoundEvent = logicalSoundInfo.Kind;

#if DEBUG
                //LogInstance.Log($"kindOfSoundEvent = {kindOfSoundEvent}");
#endif

                switch (kindOfSoundEvent)
                {
                    case KindOfSoundEvent.EntityCondition:
#if DEBUG
                        //LogInstance.Log($"mNPCProcessInfoForLogicalSoundEntityCondition == null = {mNPCProcessInfoForLogicalSoundEntityCondition == null}");
#endif
                        return mNPCProcessInfoForLogicalSoundEntityCondition;

                    case KindOfSoundEvent.Command:
                        if(mNPCProcessInfoDictByLogicalSoundActions.ContainsKey(logicalSoundInfo.ActionName))
                        {
                            return mNPCProcessInfoDictByLogicalSoundActions[logicalSoundInfo.ActionName];
                        }
                        break;

                    case KindOfSoundEvent.Fact:
                        return mNPCProcessInfoForLogicalSoundFact;

                    default:
                        throw new ArgumentOutOfRangeException(nameof(kindOfSoundEvent), kindOfSoundEvent, null);
                }

                return null;
            }
        }

        public void Dispose()
        {
            lock (mDisposeLockObj)
            {
                if (mIsDisposed)
                {
                    return;
                }

                mIsDisposed = true;
            }
        }
    }
}
