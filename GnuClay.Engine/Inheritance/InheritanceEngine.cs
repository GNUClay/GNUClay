using GnuClay.Engine.InternalCommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GnuClay.CommonUtils.TypeHelpers;

namespace GnuClay.Engine.Inheritance
{
    public class InheritanceEngine : BaseGnuClayEngineComponent
    {
        public InheritanceEngine(GnuClayEngineComponentContext context)
            : base(context)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("InheritanceEngine");

            Clear();
        }

        private Dictionary<ulong, Dictionary<ulong, InheritanceInfo>> mInheritanceRegistry;

        private Dictionary<ulong, List<InheritanceItem>> mInheritanceCash;
        private Dictionary<ulong, Dictionary<ulong, double>> mInheritanceCashDict;

        [Serializable]
        private class Data
        {
            public Dictionary<ulong, Dictionary<ulong, InheritanceInfo>> mInheritanceRegistry;

            public Dictionary<ulong, List<InheritanceItem>> mInheritanceCash;
            public Dictionary<ulong, Dictionary<ulong, double>> mInheritanceCashDict;
        }

        private object mLockObj = new object();

        public void SetInheritance(ulong subKey, ulong superKey, double rank, InheritanceAspect aspect)
        {
            lock (mLockObj)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"SetInheritance subKey = {subKey} superKey = {superKey} rank = {rank} aspect = {aspect}");

                switch (aspect)
                {
                    case InheritanceAspect.WithOutClause:
                        break;

                    default: throw new NotSupportedException($"The value `{aspect}` of variable `aspect` is not supported.");
                }

                if (rank == 0)
                {
                    RemoveInheritance(subKey, superKey);
                    return;
                }

                if (IsOwnSuperClass(subKey, superKey))
                {
                    throw new CyclicInheritanceException(Context.DataDictionary.GetValue(subKey), Context.DataDictionary.GetValue(superKey));
                }

                if (mInheritanceRegistry.ContainsKey(subKey))
                {
                    NLog.LogManager.GetCurrentClassLogger().Info("SetInheritance mInheritanceRegistry.ContainsKey(subKey)");

                    var tmpDict = mInheritanceRegistry[subKey];

                    NLog.LogManager.GetCurrentClassLogger().Info($"SetInheritance tmpDict = {tmpDict.ToJson()}");

                    if (tmpDict.ContainsKey(superKey))
                    {
                        NLog.LogManager.GetCurrentClassLogger().Info("SetInheritance tmpDict.ContainsKey(superKey)");

                        var targetItem = tmpDict[superKey];

                        if (targetItem.Rank == rank && targetItem.Aspect == aspect)
                        {
                            return;
                        }

                        NLog.LogManager.GetCurrentClassLogger().Info("SetInheritance NEXT tmpDict.ContainsKey(superKey)");

                        targetItem.Rank = rank;
                        targetItem.Aspect = aspect;

                        ClearCash();
                    }
                    else
                    {
                        NLog.LogManager.GetCurrentClassLogger().Info("SetInheritance NOT tmpDict.ContainsKey(superKey)");

                        tmpDict.Add(superKey, new InheritanceInfo()
                        {
                            Rank = rank,
                            Aspect = aspect
                        });

                        ClearCash();
                    }
                }
                else
                {
                    NLog.LogManager.GetCurrentClassLogger().Info("SetInheritance Not mInheritanceRegistry.ContainsKey(subKey)");

                    var tmpDict = new Dictionary<ulong, InheritanceInfo>();
                    tmpDict.Add(superKey, new InheritanceInfo()
                    {
                        Rank = rank,
                        Aspect = aspect
                    });

                    mInheritanceRegistry.Add(subKey, tmpDict);

                    ClearCash();
                }
            }  
        }

        private void RemoveInheritance(ulong subKey, ulong superKey)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"RemoveInheritance subKey = {subKey} superKey = {superKey}");

            if (mInheritanceRegistry.ContainsKey(subKey))
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"RemoveInheritance mInheritanceRegistry.ContainsKey(subKey)");

                var tmpDict = mInheritanceRegistry[subKey];

                if(tmpDict.ContainsKey(superKey))
                {
                    NLog.LogManager.GetCurrentClassLogger().Info($"RemoveInheritance tmpDict.ContainsKey(superKey)");

                    tmpDict.Remove(superKey);

                    ClearCash();
                }            
            }                
        }

        private bool IsOwnSuperClass(ulong subKey, ulong superKey)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"IsOwnSuperClass subKey = {subKey} superKey = {superKey}");

            return NIsOwnSuperClass(subKey, superKey, new List<ulong>());
        }

        private bool NIsOwnSuperClass(ulong subKey, ulong superKey, List<ulong> visitedKeys)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"NIsOwnSuperClass subKey = {subKey} superKey = {superKey}");
            NLog.LogManager.GetCurrentClassLogger().Info($"NIsOwnSuperClass visitedKeys = {visitedKeys.ToJson()}");

            if(visitedKeys.Contains(superKey))
            {
                return false;
            }

            NLog.LogManager.GetCurrentClassLogger().Info($"NIsOwnSuperClass Next subKey = {subKey} superKey = {superKey}");

            visitedKeys.Add(superKey);

            if(mInheritanceRegistry.ContainsKey(superKey))
            {
                var targetDict = mInheritanceRegistry[superKey];

                if(targetDict.ContainsKey(subKey))
                {
                    return true;
                }

                foreach(var tmpItem in targetDict)
                {
                    NLog.LogManager.GetCurrentClassLogger().Info($"NIsOwnSuperClass Next tmpItem.Key = {tmpItem.Key}");

                    if(NIsOwnSuperClass(subKey, tmpItem.Key, visitedKeys))
                    {
                        return true;
                    }
                }     
            }

            return false;
        }

        private void ClearCash()
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"ClearCash");

            mInheritanceCash = new Dictionary<ulong, List<InheritanceItem>>();
            mInheritanceCashDict = new Dictionary<ulong, Dictionary<ulong, double>>();
        }

        public List<InheritanceItem> LoadListOfInheritance(ulong targetKey)
        {
            lock (mLockObj)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"LoadListOfInheritance targetKey = {targetKey}");

                if(mInheritanceCash.ContainsKey(targetKey))
                {
                    return mInheritanceCash[targetKey];
                }

                NLog.LogManager.GetCurrentClassLogger().Info($"LoadListOfInheritance NEXT targetKey = {targetKey}");

                var tmpContext = new CalculatingInheritanceItemsContext();



                throw new NotImplementedException();
            }
        }

        /*private void NLoadListOfInheritance(ulong targetKey, CalculatingInheritanceItemsContext context)
        {?????
            NLog.LogManager.GetCurrentClassLogger().Info("Save");

            throw new NotImplementedException();
        }*/

        public object Save()
        {
            lock (mLockObj)
            {
                NLog.LogManager.GetCurrentClassLogger().Info("Save");

                var tmpData = new Data();

                tmpData.mInheritanceRegistry = mInheritanceRegistry;

                tmpData.mInheritanceCash = mInheritanceCash;
                tmpData.mInheritanceCashDict = mInheritanceCashDict;

                return tmpData;
            }
        }

        public void Load(object value)
        {
            lock (mLockObj)
            {
                NLog.LogManager.GetCurrentClassLogger().Info("Load");

                var tmpData = (Data)value;

                mInheritanceRegistry = tmpData.mInheritanceRegistry;

                mInheritanceCash = tmpData.mInheritanceCash;
                mInheritanceCashDict = tmpData.mInheritanceCashDict;
            }
        }

        public void Clear()
        {
            lock (mLockObj)
            {
                NLog.LogManager.GetCurrentClassLogger().Info("Clear");

                mInheritanceRegistry = new Dictionary<ulong, Dictionary<ulong, InheritanceInfo>>();

                mInheritanceCash = new Dictionary<ulong, List<InheritanceItem>>();
                mInheritanceCashDict = new Dictionary<ulong, Dictionary<ulong, double>>();
            }
        }
    }
}
