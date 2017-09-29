using GnuClay.Engine.InternalCommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.CommonClientTypes.CommonData;

namespace GnuClay.Engine.Inheritance
{
    public class InheritanceEngine : BaseGnuClayEngineComponent
    {
        public InheritanceEngine(GnuClayEngineComponentContext context)
            : base(context)
        {
            Clear();
        }

        private Dictionary<ulong, Dictionary<ulong, InheritanceInfo>> mInheritanceRegistry;
        private Dictionary<ulong, Dictionary<ulong, InheritanceInfo>> mSubClassesRegistry;

        private Dictionary<ulong, List<InheritanceItem>> mInheritanceCash;
        private Dictionary<ulong, Dictionary<ulong, double>> mInheritanceCashDict;

        private Dictionary<ulong, List<InheritanceItem>> mSubClasesCash;
        private Dictionary<ulong, Dictionary<ulong, double>> mSubClassesCachDict;

        [Serializable]
        private class Data
        {
            public Dictionary<ulong, Dictionary<ulong, InheritanceInfo>> mInheritanceRegistry;
            public Dictionary<ulong, Dictionary<ulong, InheritanceInfo>> mSubClassesRegistry;

            public Dictionary<ulong, List<InheritanceItem>> mInheritanceCash;
            public Dictionary<ulong, Dictionary<ulong, double>> mInheritanceCashDict;

            public Dictionary<ulong, List<InheritanceItem>> mSubClasesCash;
            public Dictionary<ulong, Dictionary<ulong, double>> mSubClassesCachDict;
        }

        private object mLockObj = new object();

        private ulong UniversalTypeKey = 1;

        public void SetInheritance(ulong subKey, ulong superKey, double rank, InheritanceAspect aspect)
        {
            lock (mLockObj)
            {
                if(subKey == UniversalTypeKey)
                {
                    return;
                }

                if (superKey == UniversalTypeKey && (rank > 1 || aspect != InheritanceAspect.WithOutClause))
                {
                    return;
                }

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

                var mustAddSubClass = false;

                if (mInheritanceRegistry.ContainsKey(subKey))
                {
                    var tmpDict = mInheritanceRegistry[subKey];

                    if (tmpDict.ContainsKey(superKey))
                    {
                        var targetItem = tmpDict[superKey];

                        if (targetItem.Rank == rank && targetItem.Aspect == aspect)
                        {
                            return;
                        }

                        targetItem.Rank = rank;
                        targetItem.Aspect = aspect;

                        mustAddSubClass = true;
                    }
                    else
                    {
                        tmpDict.Add(superKey, new InheritanceInfo()
                        {
                            Rank = rank,
                            Aspect = aspect
                        });

                        mustAddSubClass = true;
                    }
                }
                else
                {
                    var tmpDict = new Dictionary<ulong, InheritanceInfo>();
                    tmpDict.Add(superKey, new InheritanceInfo()
                    {
                        Rank = rank,
                        Aspect = aspect
                    });

                    mInheritanceRegistry.Add(subKey, tmpDict);
               
                    mustAddSubClass = true;
                }

                if(mustAddSubClass)
                {
                    Context.LogicalStorage.RegEntity(superKey);
                    Context.LogicalStorage.RegEntity(subKey);

                    if (mSubClassesRegistry.ContainsKey(superKey))
                    {
                        var tmpDict = mSubClassesRegistry[superKey];

                        if(tmpDict.ContainsKey(subKey))
                        {                            
                            var targetItem = tmpDict[subKey];

                            targetItem.Rank = rank;
                            targetItem.Aspect = aspect;
                        }
                        else
                        {                            
                            tmpDict.Add(subKey, new InheritanceInfo()
                            {
                                Rank = rank,
                                Aspect = aspect
                            });
                        }                       
                    }
                    else
                    {
                        var tmpDict = new Dictionary<ulong, InheritanceInfo>();

                        tmpDict.Add(subKey, new InheritanceInfo()
                        {
                            Rank = rank,
                            Aspect = aspect
                        });

                        mSubClassesRegistry.Add(superKey, tmpDict);
                    }

                    ClearCash();
                }
            }  
        }

        private void RemoveInheritance(ulong subKey, ulong superKey)
        {            
            var mustClearCash = false;

            if (mInheritanceRegistry.ContainsKey(subKey))
            {                
                var tmpDict = mInheritanceRegistry[subKey];

                if(tmpDict.ContainsKey(superKey))
                {                    
                    tmpDict.Remove(superKey);

                    mustClearCash = true;
                }            
            }

            if(mSubClassesRegistry.ContainsKey(superKey))
            {                
                var tmpDict = mSubClassesRegistry[superKey];

                if(tmpDict.ContainsKey(subKey))
                {                    
                    tmpDict.Remove(subKey);

                    mustClearCash = true;
                }
            }  
            
            if(mustClearCash)
            {
                ClearCash();
            }      
        }

        private bool IsOwnSuperClass(ulong subKey, ulong superKey)
        {
            return NIsOwnSuperClass(subKey, superKey, new List<ulong>());
        }

        private bool NIsOwnSuperClass(ulong subKey, ulong superKey, List<ulong> visitedKeys)
        {
            if(visitedKeys.Contains(superKey))
            {
                return false;
            }

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
            mInheritanceCash = new Dictionary<ulong, List<InheritanceItem>>();
            mInheritanceCashDict = new Dictionary<ulong, Dictionary<ulong, double>>();

            mSubClasesCash = new Dictionary<ulong, List<InheritanceItem>>();
            mSubClassesCachDict = new Dictionary<ulong, Dictionary<ulong, double>>();
        }

        public List<InheritanceItem> LoadListOfSuperClasses(ulong targetKey)
        {
            lock (mLockObj)
            {
                if(mInheritanceCash.ContainsKey(targetKey))
                {
                    return mInheritanceCash[targetKey];
                }

                return CalculateListOfSuperClassesCashItems(targetKey);
            }
        }

        private List<InheritanceItem> CalculateListOfSuperClassesCashItems(ulong targetKey)
        {
            var resultList = new List<InheritanceItem>();

            NLoadListOfSuperClasses(targetKey, targetKey, resultList, 0, -1);

            if (_ListHelper.IsEmpty(resultList))
            {
                mInheritanceCash.Add(targetKey, new List<InheritanceItem>());
                mInheritanceCashDict.Add(targetKey, new Dictionary<ulong, double>());
                return resultList;
            }

            resultList = resultList.OrderByDescending(p => p.Rank).ThenBy(p => p.Distance).ToList();

            var filteredResultList = new List<InheritanceItem>();

            var tmpDict = new Dictionary<ulong, double>();

            var tmpExistsKeys = new List<ulong>();

            foreach (var item in resultList)
            {
                var tmpKey = item.SuperKey;

                if (tmpExistsKeys.Contains(tmpKey))
                {
                    continue;
                }

                tmpExistsKeys.Add(tmpKey);

                filteredResultList.Add(item);
                tmpDict.Add(tmpKey, item.Rank);
            }

            mInheritanceCash.Add(targetKey, filteredResultList);
            mInheritanceCashDict.Add(targetKey, tmpDict);

            return filteredResultList;
        }

        private void NLoadListOfSuperClasses(ulong subKey, ulong targetKey, List<InheritanceItem> resultList, int currentDistance, double currentRank)
        {
            if(currentRank > -1)
            {
                var tmpItem = new InheritanceItem();
                tmpItem.SubKey = subKey;
                tmpItem.SuperKey = targetKey;
                tmpItem.Rank = currentRank;
                tmpItem.Distance = currentDistance;
                resultList.Add(tmpItem);
            }

            if(targetKey == 1)
            {
                return;
            }

            if(mInheritanceRegistry.ContainsKey(targetKey))
            {
                currentDistance++;

                var tmpDict = mInheritanceRegistry[targetKey];

                foreach(var item in tmpDict)
                {
                    var tmpKey = item.Key;
                    var info = item.Value;

                    switch (info.Aspect)
                    {
                        case InheritanceAspect.WithOutClause:
                            break;

                        default: throw new NotSupportedException($"The value `{info.Aspect}` of variable `info.Aspect` is not supported.");
                    }

                    var targetRank = info.Rank;

                    if(currentRank > -1)
                    {
                        targetRank *= currentRank;
                    }

                    NLoadListOfSuperClasses(subKey, tmpKey, resultList, currentDistance, targetRank);
                }            
            }      
        }

        public double GetRank(ulong subKey, ulong superKey)
        {
            lock (mLockObj)
            {
                if(mInheritanceCashDict.ContainsKey(subKey))
                {
                    return GetRankFromCash(subKey, superKey);
                }

                CalculateListOfSuperClassesCashItems(subKey);

                return GetRankFromCash(subKey, superKey);
            }               
        }

        private double GetRankFromCash(ulong subKey, ulong superKey)
        {
            var tmpDict = mInheritanceCashDict[subKey];

            if (tmpDict.ContainsKey(superKey))
            {
                return tmpDict[superKey];
            }

            return 0;
        }

        public List<InheritanceItem> LoadListOfSubClasses(ulong targetKey)
        {
            lock(mLockObj)
            {
                if(mSubClasesCash.ContainsKey(targetKey))
                {
                    return mSubClasesCash[targetKey];
                }

                return CalculateListSubClasses(targetKey);
            }
        }

        private List<InheritanceItem> CalculateListSubClasses(ulong targetKey)
        {
            var resultList = new List<InheritanceItem>();

            NLoadListOfSubClasses(targetKey, targetKey, resultList, 0, -1);

            if (_ListHelper.IsEmpty(resultList))
            {
                mSubClasesCash.Add(targetKey, new List<InheritanceItem>());
                mSubClassesCachDict.Add(targetKey, new Dictionary<ulong, double>());
                return resultList;
            }

            resultList = resultList.OrderByDescending(p => p.Rank).ThenBy(p => p.Distance).ToList();

            var filteredResultList = new List<InheritanceItem>();

            var tmpDict = new Dictionary<ulong, double>();

            var tmpExistsKeys = new List<ulong>();

            foreach (var item in resultList)
            {
                var tmpKey = item.SubKey;

                if (tmpExistsKeys.Contains(tmpKey))
                {
                    continue;
                }

                tmpExistsKeys.Add(tmpKey);

                filteredResultList.Add(item);
                tmpDict.Add(tmpKey, item.Rank);
            }

            mSubClasesCash.Add(targetKey, filteredResultList);
            mSubClassesCachDict.Add(targetKey, tmpDict);

            return filteredResultList;
        }

        private void NLoadListOfSubClasses(ulong superKey, ulong targetKey, List<InheritanceItem> resultList, int currentDistance, double currentRank)
        {
            if (currentRank > -1)
            {
                var tmpItem = new InheritanceItem();
                tmpItem.SubKey = targetKey;
                tmpItem.SuperKey = superKey;
                tmpItem.Rank = currentRank;
                tmpItem.Distance = currentDistance;
                resultList.Add(tmpItem);
            }

            if(mSubClassesRegistry.ContainsKey(targetKey))
            {
                currentDistance++;

                var tmpDict = mSubClassesRegistry[targetKey];

                foreach(var item in tmpDict)
                {
                    var tmpKey = item.Key;
                    var info = item.Value;

                    switch (info.Aspect)
                    {
                        case InheritanceAspect.WithOutClause:
                            break;

                        default: throw new NotSupportedException($"The value `{info.Aspect}` of variable `info.Aspect` is not supported.");
                    }

                    var targetRank = info.Rank;

                    if (currentRank > -1)
                    {
                        targetRank *= currentRank;
                    }

                    NLoadListOfSubClasses(superKey, tmpKey, resultList, currentDistance, targetRank);
                }
            }          
        }

        public List<InheritanceItem> LoadAllItems()
        {
            lock (mLockObj)
            {
                var result = new List<InheritanceItem>();

                foreach (var item in mInheritanceRegistry)
                {
                    var subKey = item.Key;

                    foreach(var subItem in item.Value)
                    {
                        var tmpObj = subItem.Value;

                        var aspect = tmpObj.Aspect;

                        switch (aspect)
                        {
                            case InheritanceAspect.WithOutClause:
                                break;

                            default: throw new ArgumentOutOfRangeException(nameof(aspect), aspect.ToString());
                        }

                        var tmpItem = new InheritanceItem();
                        tmpItem.SubKey = subKey;
                        tmpItem.SuperKey = subItem.Key;
                        tmpItem.Rank = tmpObj.Rank;
                        tmpItem.Distance = 1;

                        result.Add(tmpItem);
                    }
                }

                return result;
            }
        }

        public object Save()
        {
            lock (mLockObj)
            {
                var tmpData = new Data();

                tmpData.mInheritanceRegistry = mInheritanceRegistry;
                tmpData.mSubClassesRegistry = mSubClassesRegistry;

                tmpData.mInheritanceCash = mInheritanceCash;
                tmpData.mInheritanceCashDict = mInheritanceCashDict;

                tmpData.mSubClasesCash = mSubClasesCash;
                tmpData.mSubClassesCachDict = mSubClassesCachDict;

                return tmpData;
            }
        }

        public void Load(object value)
        {
            lock (mLockObj)
            {
                var tmpData = (Data)value;

                mInheritanceRegistry = tmpData.mInheritanceRegistry;
                mSubClassesRegistry = tmpData.mSubClassesRegistry;

                mInheritanceCash = tmpData.mInheritanceCash;
                mInheritanceCashDict = tmpData.mInheritanceCashDict;

                mSubClasesCash = tmpData.mSubClasesCash;
                mSubClassesCachDict = tmpData.mSubClassesCachDict;
            }
        }

        public void Clear()
        {
            lock (mLockObj)
            {
                mInheritanceRegistry = new Dictionary<ulong, Dictionary<ulong, InheritanceInfo>>();
                mSubClassesRegistry = new Dictionary<ulong, Dictionary<ulong, InheritanceInfo>>();

                mInheritanceCash = new Dictionary<ulong, List<InheritanceItem>>();
                mInheritanceCashDict = new Dictionary<ulong, Dictionary<ulong, double>>();

                mSubClasesCash = new Dictionary<ulong, List<InheritanceItem>>();
                mSubClassesCachDict = new Dictionary<ulong, Dictionary<ulong, double>>();
            }
        }

        public List<ExecutorsQueueItem> LoadExecutorsQueueItems(ulong targetKey)
        {
            lock (mLockObj)
            {
                var tmpObjectsList = new List<ExecutorsQueueItem>();

                tmpObjectsList.Add(new ExecutorsQueueItem()
                {
                    TypeKey = targetKey,
                    Rank = 2
                });

                var tmpInheritanceList = Context.InheritanceEngine.LoadListOfSuperClasses(targetKey);

                foreach (var tmpInheritanceItem in tmpInheritanceList)
                {
                    tmpObjectsList.Add(new ExecutorsQueueItem()
                    {
                        TypeKey = tmpInheritanceItem.SuperKey,
                        Rank = tmpInheritanceItem.Rank * tmpInheritanceItem.Distance
                    });
                }

                tmpObjectsList = tmpObjectsList.OrderByDescending(p => p.Rank).ToList();

                return tmpObjectsList;
            }
        }
    }
}
