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
        //private Dictionary<string, List<string>> mNounClassesDict;

        public void Run()
        {
            LogInstance.Log("Begin");

            var rootNounsList = mRootNounsSource.ReadAll();

            mWordIdDict = rootNounsList.ToDictionary(p => p.WordNum, p => p);

            LogInstance.Log($"mWordIdDict.Count = {mWordIdDict.Count}");

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

            //foreach (var classId in classesIdList)
            //{
            //    var word = mWordIdDict[classId];

            //    LogInstance.Log($"word = {word}");
            //}

            var cg = new ConceptualGraph();

            var conceptsDict = new Dictionary<int, RelationCGNode>();

            foreach (var classId in classesIdList)
            {
                var word = mWordIdDict[classId];

                LogInstance.Log($"word = {word}");

                RelationCGNode wordConcept = null;
                
                if (conceptsDict.ContainsKey(word.WordNum))
                {
                    wordConcept = conceptsDict[word.WordNum];
                }
                else
                {
                    wordConcept = new RelationCGNode();
                    conceptsDict[word.WordNum] = wordConcept;
                    wordConcept.Parent = cg;
                    wordConcept.Name = $"{word.Word} ({word.WordNum})";
                }

                if(word.ParentWordNum > 0)
                {
                    var parentWord = mWordIdDict[word.ParentWordNum];

                    RelationCGNode parentConcept = null;

                    if (conceptsDict.ContainsKey(parentWord.WordNum))
                    {
                        parentConcept = conceptsDict[parentWord.WordNum];
                    }
                    else
                    {
                        parentConcept = new RelationCGNode();
                        conceptsDict[parentWord.WordNum] = parentConcept;
                        parentConcept.Parent = cg;
                        parentConcept.Name = $"{parentWord.Word} ({parentWord.WordNum})";
                    }

                    wordConcept.AddOutputNode(parentConcept);
                }
            }

            DotConverter.DumpToFile(cg, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "1.dot"));
        }
    }
}
