using GnuClay.Engine.InternalCommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.CommonClientTypes.Inheritance;

namespace GnuClay.Engine.Inheritance
{
    public class InheritanceEngine : BaseGnuClayEngineComponent
    {
        public InheritanceEngine(GnuClayEngineComponentContext context)
            : base(context)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("constructor");

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
                //NLog.LogManager.GetCurrentClassLogger().Info($"SetInheritance subKey = {subKey} superKey = {superKey} rank = {rank} aspect = {aspect}");

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
                    //NLog.LogManager.GetCurrentClassLogger().Info("SetInheritance mInheritanceRegistry.ContainsKey(subKey)");

                    var tmpDict = mInheritanceRegistry[subKey];

                    //NLog.LogManager.GetCurrentClassLogger().Info($"SetInheritance tmpDict = {tmpDict.ToJson()}");

                    if (tmpDict.ContainsKey(superKey))
                    {
                        //NLog.LogManager.GetCurrentClassLogger().Info("SetInheritance tmpDict.ContainsKey(superKey)");

                        var targetItem = tmpDict[superKey];

                        if (targetItem.Rank == rank && targetItem.Aspect == aspect)
                        {
                            return;
                        }

                        //NLog.LogManager.GetCurrentClassLogger().Info("SetInheritance NEXT tmpDict.ContainsKey(superKey)");

                        targetItem.Rank = rank;
                        targetItem.Aspect = aspect;

                        mustAddSubClass = true;
                    }
                    else
                    {
                        //NLog.LogManager.GetCurrentClassLogger().Info("SetInheritance NOT tmpDict.ContainsKey(superKey)");

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
                    //NLog.LogManager.GetCurrentClassLogger().Info("SetInheritance Not mInheritanceRegistry.ContainsKey(subKey)");

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
                        //NLog.LogManager.GetCurrentClassLogger().Info("SetInheritance mSubClassesRegistry.ContainsKey(superKey)");

                        var tmpDict = mSubClassesRegistry[superKey];

                        //NLog.LogManager.GetCurrentClassLogger().Info($"SetInheritance tmpDict (2) = {tmpDict.ToJson()}");

                        if(tmpDict.ContainsKey(subKey))
                        {
                            //NLog.LogManager.GetCurrentClassLogger().Info("SetInheritance tmpDict.ContainsKey(subKey)");

                            var targetItem = tmpDict[subKey];

                            targetItem.Rank = rank;
                            targetItem.Aspect = aspect;
                        }
                        else
                        {
                            //NLog.LogManager.GetCurrentClassLogger().Info("SetInheritance tmpDict.ContainsKey(subKey)");

                            tmpDict.Add(subKey, new InheritanceInfo()
                            {
                                Rank = rank,
                                Aspect = aspect
                            });
                        }                       
                    }
                    else
                    {
                        //NLog.LogManager.GetCurrentClassLogger().Info("SetInheritance NOT mSubClassesRegistry.ContainsKey(superKey)");

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
            //NLog.LogManager.GetCurrentClassLogger().Info($"RemoveInheritance subKey = {subKey} superKey = {superKey}");

            var mustClearCash = false;

            if (mInheritanceRegistry.ContainsKey(subKey))
            {
                //NLog.LogManager.GetCurrentClassLogger().Info($"RemoveInheritance mInheritanceRegistry.ContainsKey(subKey)");

                var tmpDict = mInheritanceRegistry[subKey];

                if(tmpDict.ContainsKey(superKey))
                {
                    //NLog.LogManager.GetCurrentClassLogger().Info($"RemoveInheritance tmpDict.ContainsKey(superKey)");

                    tmpDict.Remove(superKey);

                    mustClearCash = true;
                }            
            }

            if(mSubClassesRegistry.ContainsKey(superKey))
            {
                //NLog.LogManager.GetCurrentClassLogger().Info($"RemoveInheritance mSubClassesRegistry.ContainsKey(superKey)");

                var tmpDict = mSubClassesRegistry[superKey];

                if(tmpDict.ContainsKey(subKey))
                {
                    //NLog.LogManager.GetCurrentClassLogger().Info($"RemoveInheritance tmpDict.ContainsKey(subKey)");

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
            //NLog.LogManager.GetCurrentClassLogger().Info($"IsOwnSuperClass subKey = {subKey} superKey = {superKey}");

            return NIsOwnSuperClass(subKey, superKey, new List<ulong>());
        }

        private bool NIsOwnSuperClass(ulong subKey, ulong superKey, List<ulong> visitedKeys)
        {
            //NLog.LogManager.GetCurrentClassLogger().Info($"NIsOwnSuperClass subKey = {subKey} superKey = {superKey}");
            //NLog.LogManager.GetCurrentClassLogger().Info($"NIsOwnSuperClass visitedKeys = {visitedKeys.ToJson()}");

            if(visitedKeys.Contains(superKey))
            {
                return false;
            }

            //NLog.LogManager.GetCurrentClassLogger().Info($"NIsOwnSuperClass Next subKey = {subKey} superKey = {superKey}");

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
                    //NLog.LogManager.GetCurrentClassLogger().Info($"NIsOwnSuperClass Next tmpItem.Key = {tmpItem.Key}");

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
            //NLog.LogManager.GetCurrentClassLogger().Info($"ClearCash");

            mInheritanceCash = new Dictionary<ulong, List<InheritanceItem>>();
            mInheritanceCashDict = new Dictionary<ulong, Dictionary<ulong, double>>();

            mSubClasesCash = new Dictionary<ulong, List<InheritanceItem>>();
            mSubClassesCachDict = new Dictionary<ulong, Dictionary<ulong, double>>();
        }

        public List<InheritanceItem> LoadListOfSuperClasses(ulong targetKey)
        {
            lock (mLockObj)
            {
                //NLog.LogManager.GetCurrentClassLogger().Info($"LoadListOfSuperClasses targetKey = {targetKey}");

                if(mInheritanceCash.ContainsKey(targetKey))
                {
                    return mInheritanceCash[targetKey];
                }

                //NLog.LogManager.GetCurrentClassLogger().Info($"LoadListOfSuperClasses NEXT targetKey = {targetKey}");

                return CalculateListOfSuperClassesCashItems(targetKey);
            }
        }

        private List<InheritanceItem> CalculateListOfSuperClassesCashItems(ulong targetKey)
        {
            //NLog.LogManager.GetCurrentClassLogger().Info($"CalculateListOfSuperClassesCashItems targetKey = {targetKey}");

            var resultList = new List<InheritanceItem>();

            NLoadListOfSuperClasses(targetKey, targetKey, resultList, 0, -1);

            if (_ListHelper.IsEmpty(resultList))
            {
                mInheritanceCash.Add(targetKey, new List<InheritanceItem>());
                mInheritanceCashDict.Add(targetKey, new Dictionary<ulong, double>());
                return resultList;
            }

            //NLog.LogManager.GetCurrentClassLogger().Info($"CalculateListOfSuperClassesCashItems NEXT NEXT targetKey = {targetKey}");

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
            //NLog.LogManager.GetCurrentClassLogger().Info($"NLoadListOfSuperClasses subKey = {subKey} targetKey = {targetKey} currentDistance = {currentDistance} currentRank = {currentRank}");

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

                    //NLog.LogManager.GetCurrentClassLogger().Info($"NLoadListOfSuperClasses subKey = {subKey} tmpKey = {tmpKey}");

                    NLoadListOfSuperClasses(subKey, tmpKey, resultList, currentDistance, targetRank);
                }            
            }      
        }

        public double GetRank(ulong subKey, ulong superKey)
        {
            lock (mLockObj)
            {
                //NLog.LogManager.GetCurrentClassLogger().Info($"GetRank subKey = {subKey} superKey = {superKey}");

                if(mInheritanceCashDict.ContainsKey(subKey))
                {
                    return GetRankFromCash(subKey, superKey);
                }

                //NLog.LogManager.GetCurrentClassLogger().Info($"GetRank NEXT subKey = {subKey} superKey = {superKey}");

                CalculateListOfSuperClassesCashItems(subKey);

                return GetRankFromCash(subKey, superKey);
            }               
        }

        private double GetRankFromCash(ulong subKey, ulong superKey)
        {
            //NLog.LogManager.GetCurrentClassLogger().Info($"GetRankFromCash subKey = {subKey} superKey = {superKey}");

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
                //NLog.LogManager.GetCurrentClassLogger().Info($"LoadListOfSubClasses targetKey = {targetKey}");

                if(mSubClasesCash.ContainsKey(targetKey))
                {
                    return mSubClasesCash[targetKey];
                }

                return CalculateListSubClasses(targetKey);
            }
        }

        private List<InheritanceItem> CalculateListSubClasses(ulong targetKey)
        {
            //NLog.LogManager.GetCurrentClassLogger().Info($"CalculateListSubClasses targetKey = {targetKey}");

            var resultList = new List<InheritanceItem>();

            NLoadListOfSubClasses(targetKey, targetKey, resultList, 0, -1);

            if (_ListHelper.IsEmpty(resultList))
            {
                mSubClasesCash.Add(targetKey, new List<InheritanceItem>());
                mSubClassesCachDict.Add(targetKey, new Dictionary<ulong, double>());
                return resultList;
            }

            //NLog.LogManager.GetCurrentClassLogger().Info("CalculateListSubClasses NEXT");

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
            //NLog.LogManager.GetCurrentClassLogger().Info($"NLoadListOfSubClasses superKey = {superKey} targetKey = {targetKey} currentDistance = {currentDistance} currentRank = {currentRank}");

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
                //NLog.LogManager.GetCurrentClassLogger().Info("NLoadListOfSubClasses NEXT");

                currentDistance++;

                var tmpDict = mSubClassesRegistry[targetKey];

                foreach(var item in tmpDict)
                {
                    //NLog.LogManager.GetCurrentClassLogger().Info($"NLoadListOfSubClasses item = {item.ToJson()}");

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
                //NLog.LogManager.GetCurrentClassLogger().Info("LoadAllItems");

                var result = new List<InheritanceItem>();

                foreach (var item in mInheritanceRegistry)
                {
                    var subKey = item.Key;

                    foreach(var subItem in item.Value)
                    {
                        //NLog.LogManager.GetCurrentClassLogger().Info($"LoadAllItems subKey = {subKey} subItem = {subItem}");

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
                NLog.LogManager.GetCurrentClassLogger().Info("Save");

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
                NLog.LogManager.GetCurrentClassLogger().Info("Load");

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
                NLog.LogManager.GetCurrentClassLogger().Info("Clear");

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
                NLog.LogManager.GetCurrentClassLogger().Info($"LoadExecutorsQueueItems targetKey = {targetKey}");

                var tmpObjectsList = new List<ExecutorsQueueItem>();

                tmpObjectsList.Add(new ExecutorsQueueItem()
                {
                    TypeKey = targetKey,
                    Rank = 2
                });

                var tmpInheritanceList = Context.InheritanceEngine.LoadListOfSuperClasses(targetKey);

                NLog.LogManager.GetCurrentClassLogger().Info($"LoadExecutorsQueueItems tmpInheritanceList.Count = {tmpInheritanceList.Count}");

                foreach (var tmpInheritanceItem in tmpInheritanceList)
                {
                    NLog.LogManager.GetCurrentClassLogger().Info($"LoadExecutorsQueueItems tmpInheritanceItem = {tmpInheritanceItem}");

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
