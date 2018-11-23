using MyNPCLib;
using MyNPCLib.CG;
using MyNPCLib.Dot;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DictionaryGenerator
{
    public class ClassDiscovering
    {
        public ClassDiscovering()
        {
            mRootNounsSource = new RootNounsWordNetSource();
        }

        private RootNounsWordNetSource mRootNounsSource;
        private Dictionary<int, RootNounSourceWordItem> mWordIdDict;
        private Dictionary<string, List<string>> mNounClassesDict;

        public void Run()
        {
            LogInstance.Log("Begin");

            var rootNounsList = mRootNounsSource.ReadAll();

            var rootNounClassesFactory = new RootNounClassesFactory(rootNounsList);
            mNounClassesDict = rootNounClassesFactory.Result;

            mWordIdDict = rootNounsList.ToDictionary(p => p.WordNum, p => p);

            LogInstance.Log($"mWordIdDict.Count = {mWordIdDict.Count}");

            var parentWordsDict = rootNounsList.GroupBy(p => p.ParentWordNum).ToDictionary(p => p.Key, p => p.ToList());

            LogInstance.Log($"parentWordsDict.Count = {parentWordsDict.Count}");

            var initWordsListList = mWordIdDict.Keys.ToList();
            var classesIdList = new List<int>();

            foreach (var rootNoun in rootNounsList)
            {
                //LogInstance.Log($"rootNoun = {rootNoun}");

                if (rootNoun.ParentWordNum > 0)
                {
                    classesIdList.Add(rootNoun.ParentWordNum);
                }
            }

            classesIdList = classesIdList.Distinct().ToList();

            LogInstance.Log($"classesIdList.Count = {classesIdList.Count}");

            //classesIdList = classesIdList.Take(100).ToList();

            foreach (var classId in classesIdList)
            {
                var word = mWordIdDict[classId];

                if(word.ParentWordNum == 0)
                {
                    if(word.IsName)
                    {
                        continue;
                    }

                    LogInstance.Log($"word = {word}");

                    var childrenList_1 = parentWordsDict[word.WordNum];

                    LogInstance.Log($"childrenList_1.Count = {childrenList_1.Count}");

                    foreach(var child_1 in childrenList_1)
                    {
                        LogInstance.Log($"child_1 = {child_1}");

                        if(parentWordsDict.ContainsKey(child_1.WordNum))
                        {
                            var childrenList_2 = parentWordsDict[child_1.WordNum];

                            LogInstance.Log($"childrenList_2.Count = {childrenList_2.Count}");

                            foreach (var child_2 in childrenList_2)
                            {
                                LogInstance.Log($"child_2 = {child_2}");

                                if(parentWordsDict.ContainsKey(child_2.WordNum))
                                {
                                    var childrenList_3 = parentWordsDict[child_2.WordNum];

                                    LogInstance.Log($"childrenList_3.Count = {childrenList_3.Count}");

                                    foreach (var child_3 in childrenList_3)
                                    {
                                        LogInstance.Log($"child_3 = {child_3}");
                                    }
                                }
                                LogInstance.Log("===========================================================================================================");
                            }
                        }

                        LogInstance.Log("-----------------------------------------------------------------------------------------------------------");
                    }
                }
            }

            var livingThingsList = new List<string>();

            foreach (var wordClessesKVPItem in mNounClassesDict)
            {
                if (wordClessesKVPItem.Value.Contains("causal_agent"))//causal_agent //living_thing
                {
                    //LogInstance.Log($"wordClessesKVPItem.Key = {wordClessesKVPItem.Key}");
                    livingThingsList.Add(wordClessesKVPItem.Key);
                }
            }

            LogInstance.Log($"livingThingsList.Count = {livingThingsList.Count}");

            livingThingsList = livingThingsList.OrderBy(p => p).ToList();

            foreach (var livingThing in livingThingsList)
            {
                LogInstance.Log($"livingThing = {livingThing}");
            }

            LogInstance.Log("dog");
            var dogsClassesList = mNounClassesDict["dog"];
            LogInstance.Log($"dogsClassesList.Count = {dogsClassesList.Count}");

            foreach (var dogsClass in dogsClassesList)
            {
                LogInstance.Log($"dogsClass = {dogsClass}");
            }

            LogInstance.Log("cat");
            var catsClassesList = mNounClassesDict["cat"];
            LogInstance.Log($"catsClassesList.Count = {catsClassesList.Count}");

            foreach (var catsClass in catsClassesList)
            {
                LogInstance.Log($"catsClass = {catsClass}");
            }

            LogInstance.Log("falcon");
            var falconsClassesList = mNounClassesDict["falcon"];
            LogInstance.Log($"falconsClassesList.Count = {falconsClassesList.Count}");

            foreach (var falconsClass in falconsClassesList)
            {
                LogInstance.Log($"falconsClass = {falconsClass}");
            }

            LogInstance.Log("elephant");
            var elephantsClassesList = mNounClassesDict["elephant"];
            LogInstance.Log($"elephantsClassesList.Count = {elephantsClassesList.Count}");

            foreach (var elephantsClass in elephantsClassesList)
            {
                LogInstance.Log($"elephantsClass = {elephantsClass}");
            }

            LogInstance.Log("person");
            var personsClassesList = mNounClassesDict["person"];
            LogInstance.Log($"personsClassesList.Count = {personsClassesList.Count}");

            foreach (var personsClass in personsClassesList)
            {
                LogInstance.Log($"personsClass = {personsClass}");
            }

            //var cg = new ConceptualGraph();

            //var conceptsDict = new Dictionary<int, RelationCGNode>();

            //foreach (var classId in classesIdList)
            //{
            //    var word = mWordIdDict[classId];

            //    LogInstance.Log($"word = {word}");

            //    RelationCGNode wordConcept = null;

            //    if (conceptsDict.ContainsKey(word.WordNum))
            //    {
            //        wordConcept = conceptsDict[word.WordNum];
            //    }
            //    else
            //    {
            //        wordConcept = new RelationCGNode();
            //        conceptsDict[word.WordNum] = wordConcept;
            //        wordConcept.Parent = cg;
            //        wordConcept.Name = $"{word.Word} ({word.WordNum})";
            //    }

            //    if(word.ParentWordNum > 0)
            //    {
            //        var parentWord = mWordIdDict[word.ParentWordNum];

            //        RelationCGNode parentConcept = null;

            //        if (conceptsDict.ContainsKey(parentWord.WordNum))
            //        {
            //            parentConcept = conceptsDict[parentWord.WordNum];
            //        }
            //        else
            //        {
            //            parentConcept = new RelationCGNode();
            //            conceptsDict[parentWord.WordNum] = parentConcept;
            //            parentConcept.Parent = cg;
            //            parentConcept.Name = $"{parentWord.Word} ({parentWord.WordNum})";
            //        }

            //        wordConcept.AddOutputNode(parentConcept);
            //    }
            //}

            //DotConverter.DumpToFile(cg, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "1.dot"));
        }
    }
}
