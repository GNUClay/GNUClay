using MyNPCLib;
using MyNPCLib.SimpleWordsDict;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TmpSandBox.VarOfSentences
{
    public class StateMachineOfSentenceGenerator
    {
        public void Run(List<TstSentence> sentencesList)
        {
            LogInstance.Log("Begin");

            var maxLength = sentencesList.Max(p => p.WordsList.Count);

            LogInstance.Log($"maxLength = {maxLength}");

            var totalWordsList = new List<List<TstItemOfSentence>>();

            foreach(var sentence in sentencesList)
            {
                totalWordsList.Add(sentence.WordsList);
                mInitStatesList.Add(sentence.ToDisplayStr());
            }
           
            LogInstance.Log($"totalWordsList.Count = {totalWordsList.Count}");

            var listOfKinds = new List<TstKindOfItemOfSentence>();

            ProcessN(0, string.Empty, listOfKinds, totalWordsList);

            LogInstance.Log($"mNameOfStateList.Count = {mNameOfStateList.Count}");

            var listNewAndOldNameOfStateList = new List<KeyValuePair<string, string>>();

            var initNameOfStateList = mNameOfStateList.ToList();

            mNameOfStateList = new List<string>();

            foreach (var nameOfState in initNameOfStateList)
            {
                LogInstance.Log($"nameOfState = {nameOfState}");

                var isInit = false;
                var isParent = false;

                if (mParentToChildStatesDict.ContainsKey(nameOfState))
                {
                    LogInstance.Log("IsParent");
                    isParent = true;
                }

                if (mInitStatesList.Contains(nameOfState))
                {
                    LogInstance.Log("IsInit");
                    isInit = true;
                }

                var newNameOfState = nameOfState;

                if (isInit || isParent)
                {
                    if(isInit && isParent)
                    {
                        newNameOfState = $"{newNameOfState}_TransOrFin";
                    }
                    else
                    {
                        if(isInit)
                        {
                            newNameOfState = $"{newNameOfState}_Fin";
                        }
                        else
                        {
                            newNameOfState = $"{newNameOfState}_Trans";
                        }
                    }
                }
                else
                {
                    newNameOfState = $"{newNameOfState}_Trans";
                }

                LogInstance.Log($"newNameOfState = {newNameOfState}");

                if(newNameOfState != nameOfState)
                {
                    listNewAndOldNameOfStateList.Add(new KeyValuePair<string, string>(nameOfState, newNameOfState));
                }

                mNameOfStateList.Add(newNameOfState);
            }

            LogInstance.Log($"listNewAndOldNameOfStateList.Count = {listNewAndOldNameOfStateList.Count}");

            foreach(var listNewAndOldNameOfStateItem in listNewAndOldNameOfStateList)
            {
                var nameOfState = listNewAndOldNameOfStateItem.Key;
                var newNameOfState = listNewAndOldNameOfStateItem.Value;

                if(mParentToChildStatesDict.ContainsKey(nameOfState))
                {
                    var childList = mParentToChildStatesDict[nameOfState];
                    mParentToChildStatesDict.Remove(nameOfState);
                    mParentToChildStatesDict[newNameOfState] = childList;
                }
            }

            var listNewAndOldNameOfStateDict = listNewAndOldNameOfStateList.ToDictionary(p => p.Key, p => p.Value);

            var parentToChildStatesKeysList = mParentToChildStatesDict.Keys.ToList();

            foreach (var parentToChildStatesKey in parentToChildStatesKeysList)
            {
                var childList = mParentToChildStatesDict[parentToChildStatesKey];

                var newChildList = new List<string>();

                foreach(var child in childList)
                {
                    var newChild = child;

                    if (listNewAndOldNameOfStateDict.ContainsKey(child))
                    {
                        newChild = listNewAndOldNameOfStateDict[child];
                    }

                    newChildList.Add(newChild);

                    mChildToParentDict[newChild] = parentToChildStatesKey;
                }

                mParentToChildStatesDict[parentToChildStatesKey] = newChildList;
            }

            var targetDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ATNNodes");

            LogInstance.Log($"targetDirectory = {targetDirectory}");

            if (Directory.Exists(targetDirectory))
            {
                Directory.Delete(targetDirectory, true);
            }

            Directory.CreateDirectory(targetDirectory);

            var generator = new ATNNodeGenerator(targetDirectory);

            foreach (var nameOfState in mNameOfStateList)
            {
                var parentState = GetParent(nameOfState);
                var subStatesList = GetSubStates(nameOfState);

                generator.CreateAndSaveToFile(nameOfState, parentState, subStatesList);
            }

            //var sb = new StringBuilder();

            //var n = 0;

            //foreach (var nameOfState in mNameOfStateList)
            //{
            //    LogInstance.Log($"nameOfState = {nameOfState}");

            //    n++;

            //    if(n == mNameOfStateList.Count)
            //    {
            //        sb.AppendLine(nameOfState);
            //    }
            //    else
            //    {
            //        sb.AppendLine($"{nameOfState},");
            //    }
            //}

            //LogInstance.Log($"sb.ToString() = {sb.ToString()}");

            LogInstance.Log("End");
        }

        private List<string> mInitStatesList = new List<string>();
        private List<string> mNameOfStateList = new List<string>();
        private Dictionary<string, List<string>> mParentToChildStatesDict = new Dictionary<string, List<string>>();
        private Dictionary<string, string> mChildToParentDict = new Dictionary<string, string>();

        public List<string> GetSubStates(string state)
        {
            if(mParentToChildStatesDict.ContainsKey(state))
            {
                return mParentToChildStatesDict[state];
            }

            return new List<string>();
        }

        public string GetParent(string state)
        {
            if(mChildToParentDict.ContainsKey(state))
            {
                return mChildToParentDict[state];
            }

            return "Init";
        }

        private void AddToParentState(string parentState, string state)
        {
            if(string.IsNullOrWhiteSpace(parentState))
            {
                return;
            }

            if(mParentToChildStatesDict.ContainsKey(parentState))
            {
                mParentToChildStatesDict[parentState].Add(state);
                return;
            }

            var listOfStates = new List<string>() { state };
            mParentToChildStatesDict[parentState] = listOfStates;
        }

        private void ProcessN(int n, string parentCondition, List<TstKindOfItemOfSentence> listOfKinds, List<List<TstItemOfSentence>> wordsList)
        {
            LogInstance.Log($"n = {n} wordsList.Count = {wordsList.Count}");

            LogInstance.Log($"parentCondition = {parentCondition}");

            var stateStr = ListOfKindsToDisplay(listOfKinds);
            LogInstance.Log($"stateStr = {stateStr}");

            if(!string.IsNullOrWhiteSpace(stateStr))
            {
                mNameOfStateList.Add(stateStr);

                AddToParentState(parentCondition, stateStr);
            }

            var kvpItemsList = new List<KeyValuePair<TstKindOfItemOfSentence, List<TstItemOfSentence>>>();

            foreach(var item in wordsList)
            {
                var kind = GetCell(n, item);

                //LogInstance.Log($"kind = {kind}");

                if(kind == TstKindOfItemOfSentence.Unknown)
                {
                    continue;
                }

                kvpItemsList.Add(new KeyValuePair<TstKindOfItemOfSentence, List<TstItemOfSentence>>(kind, item));
            }

            var kvpItemsDict = kvpItemsList.GroupBy(p => p.Key).ToDictionary(p => p.Key, p => p.Select(x => x.Value).ToList());

            LogInstance.Log($"n = {n} kvpItemsDict.Count = {kvpItemsDict.Count}");

            foreach(var kvpItemsDictKVPItem in kvpItemsDict)
            {
                var key = kvpItemsDictKVPItem.Key;

                LogInstance.Log($"n = {n} key = {key} kvpItemsDictKVPItem.Value.Count = {kvpItemsDictKVPItem.Value.Count}");

                var newListOfKinds = listOfKinds.ToList();
                newListOfKinds.Add(key);

                ProcessN(n + 1, stateStr, newListOfKinds, kvpItemsDictKVPItem.Value);
            }
        }

        private TstKindOfItemOfSentence GetCell(int n, List<TstItemOfSentence> rowList)
        {
            //LogInstance.Log($"n = {n} rowList.Count = {rowList.Count}");

            if(n < rowList.Count)
            {
                return rowList[n].Kind;
            }

            return TstKindOfItemOfSentence.Unknown;
        }

        private string ListOfKindsToDisplay(List<TstKindOfItemOfSentence> listOfKinds)
        {
            if(listOfKinds.Count == 0)
            {
                return string.Empty;
            }

            var sb = new StringBuilder();
            foreach (var kind in listOfKinds)
            {
                sb.Append($"{kind}_");
            }
            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }
    }
}
