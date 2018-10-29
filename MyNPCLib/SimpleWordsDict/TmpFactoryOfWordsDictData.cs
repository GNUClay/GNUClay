using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyNPCLib.SimpleWordsDict
{
    public static class TmpFactoryOfWordsDictData
    {
        static TmpFactoryOfWordsDictData()
        {
            mWordsDictData = new WordsDictData();
            mWordsDictData.WordsDict = new Dictionary<string, WordFrame>();
            //mWordsDictData.NamesList = new List<string>();

            DefineCommonClasses();
            DefineWords();

            CalculateFullMeaningsDict();
            PrepareRootWords();
        }

        private static void DefineMeaning(string word, string meaning)
        {
            DefineMeanings(word, new List<string>() { meaning });
        }

        private static void DefineMeanings(string word, List<string> listOfMeanings)
        {
            if(mTmpMeaningsDict.ContainsKey(word))
            {
                var tmplistOfMeanings = mTmpMeaningsDict[word];
                tmplistOfMeanings.AddRange(listOfMeanings);
                tmplistOfMeanings = tmplistOfMeanings.Distinct().ToList();
                mTmpMeaningsDict[word] = tmplistOfMeanings;
            }
            else
            {
                mTmpMeaningsDict[word] = listOfMeanings;
            }
        }

        private static void CalculateFullMeaningsDict()
        {
#if DEBUG
            //LogInstance.Log($"mTmpMeaningsDict.Count = {mTmpMeaningsDict.Count}");
#endif

            var mMeaningsDict = new Dictionary<string, IList<string>>();

            foreach (var tmpMeaningsDictKVPItem in mTmpMeaningsDict)
            {
                var word = tmpMeaningsDictKVPItem.Key;
#if DEBUG
                //LogInstance.Log($"word = {word}");
#endif
                
                var wasVisited = new List<string>();
                wasVisited.Add(word);
                var tmplistOfMeanings = tmpMeaningsDictKVPItem.Value;

                NCalculateFullMeaningsDict(word, ref tmplistOfMeanings, wasVisited);

                tmplistOfMeanings = tmplistOfMeanings.Distinct().ToList();
#if DEBUG
                //LogInstance.Log($"tmplistOfMeanings.Count = {tmplistOfMeanings.Count}");
                //foreach(var meaning in tmplistOfMeanings)
                //{
                //    LogInstance.Log($"meaning = {meaning}");
                //}
#endif
                mMeaningsDict[word] = tmplistOfMeanings;
            }

            var wordsDict = mWordsDictData.WordsDict;

            foreach(var wordsDictKVPItem in wordsDict)
            {
                var wordFrame = wordsDictKVPItem.Value;

                foreach(var grammaticalWordFrame in wordFrame.GrammaticalWordFrames)
                {
#if DEBUG
                    //LogInstance.Log($"grammaticalWordFrame = {grammaticalWordFrame}");
#endif

                    var logicalMeaningsList = grammaticalWordFrame.LogicalMeaning;

                    if (logicalMeaningsList.IsEmpty())
                    {
                        continue;
                    }

                    var completeLogicalMeaningsList = new List<string>();

                    foreach (var logicalMeaning in logicalMeaningsList)
                    {
#if DEBUG
                        //LogInstance.Log($"logicalMeaning = {logicalMeaning}");
#endif

                        completeLogicalMeaningsList.Add(logicalMeaning);

                        if (mMeaningsDict.ContainsKey(logicalMeaning))
                        {
                            var targetLogicalMeaningsList = mMeaningsDict[logicalMeaning];
                            completeLogicalMeaningsList.AddRange(targetLogicalMeaningsList);
                        }
                    }

                    completeLogicalMeaningsList = completeLogicalMeaningsList.Distinct().ToList();
#if DEBUG
                    //LogInstance.Log($"completeLogicalMeaningsList.Count = {completeLogicalMeaningsList.Count}");
                    //foreach (var meaning in completeLogicalMeaningsList)
                    //{
                    //    LogInstance.Log($"meaning = {meaning}");
                    //}
#endif

                    grammaticalWordFrame.FullLogicalMeaning = completeLogicalMeaningsList;
                }
            }
        }

        private static void NCalculateFullMeaningsDict(string word, ref List<string> listOfMeanings, List<string> wasVisited)
        {
#if DEBUG
            //LogInstance.Log($"word = {word}");
#endif

            var tmpSourceListOfMeanings = listOfMeanings.ToList();
            foreach (var meaning in tmpSourceListOfMeanings)
            {
#if DEBUG
                //LogInstance.Log($"meaning = {meaning}");
#endif

                if(wasVisited.Contains(meaning))
                {
                    continue;
                }

#if DEBUG
                //LogInstance.Log($"NEXT meaning = {meaning}");
#endif

                if(mTmpMeaningsDict.ContainsKey(meaning))
                {
                    var tmplistOfMeanings = mTmpMeaningsDict[meaning];
                    listOfMeanings.AddRange(tmplistOfMeanings);
                    wasVisited.Add(meaning);

                    NCalculateFullMeaningsDict(meaning, ref listOfMeanings, wasVisited);
                }
            }
        }

        private static void PrepareRootWords()
        {
            foreach(var wordsDictDataKVPItem in mWordsDictData.WordsDict)
            {
                var wordFrame = wordsDictDataKVPItem.Value;
                var wordName = wordFrame.Word;

                foreach(var grammaticalWordFrame in wordFrame.GrammaticalWordFrames)
                {
                    if(string.IsNullOrWhiteSpace(grammaticalWordFrame.RootWord))
                    {
                        grammaticalWordFrame.RootWord = wordName;
                    }
                }
            }
        }

        private static WordsDictData mWordsDictData;
        public static WordsDictData Data => mWordsDictData;
        private static Dictionary<string, List<string>> mTmpMeaningsDict = new Dictionary<string, List<string>>();

        private static void DefineCommonClasses()
        {
            DefineMeaning("act", "event");
            DefineMeaning("animate", "entity");
            DefineMeaning("phisobj", "entity");
            DefineMeanings("animal", new List<string>() { "animate", "phisobj" });
            DefineMeaning("moving", "act");
            DefineMeaning("place", "phisobj");
        }

        private static WordFrame GetWordFrame(string word)
        {
            if (mWordsDictData.WordsDict.ContainsKey(word))
            {
                return mWordsDictData.WordsDict[word];
            }

            var wordFrame = new WordFrame();
            mWordsDictData.WordsDict[word] = wordFrame;
            wordFrame.Word = word;
            wordFrame.GrammaticalWordFrames = new List<BaseGrammaticalWordFrame>();

            return wordFrame;
        }

        private static void AddGrammaticalWordFrame(string word, BaseGrammaticalWordFrame grammaticalWordFrame)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                throw new ArgumentNullException(nameof(word));
            }

            if (grammaticalWordFrame == null)
            {
                throw new ArgumentNullException(nameof(grammaticalWordFrame));
            }

            var wordFrame = GetWordFrame(word);
            wordFrame.GrammaticalWordFrames.Add(grammaticalWordFrame);
        }

        private static void DefineWords()
        {
            DefineSpecialWords();
            DefineUsualWords();
        }

        private static void DefineSpecialWords()
        {
            DefineToBeWords();
            DefineToDoWords();
            DefineToHaveWords();
            DefineModalWerbs();
            DefinePronouns();
            DefineArticles();
            DefineAdverbs();
            ProcessAllPrepositions();
            ProcessAllConjunctions();
            //ProcessAllNumerals();
        }

        private static void DefineToBeWords()
        {
            var word = "be";
            var rootWord = word;

            AddGrammaticalWordFrame(word, new VerbGrammaticalWordFrame()
            {
                Tense = GrammaticalTenses.Present,
                IsFormOfToBe = true
            });

            word = "been";
            AddGrammaticalWordFrame(word, new VerbGrammaticalWordFrame()
            {
                IsFormOfToBe = true,
                VerbType = VerbType.Form_3,
                RootWord = rootWord
            });

            word = "am";
            AddGrammaticalWordFrame(word, new VerbGrammaticalWordFrame()
            {
                IsFormOfToBe = true,
                Tense = GrammaticalTenses.Present,
                Number = GrammaticalNumberOfWord.Singular,
                Person = GrammaticalPerson.First,
                RootWord = rootWord
            });

            word = "is";
            AddGrammaticalWordFrame(word, new VerbGrammaticalWordFrame()
            {
                IsFormOfToBe = true,
                Tense = GrammaticalTenses.Present,
                Number = GrammaticalNumberOfWord.Singular,
                Person = GrammaticalPerson.Second,
                RootWord = rootWord
            });

            word = "are";
            AddGrammaticalWordFrame(word, new VerbGrammaticalWordFrame()
            {
                IsFormOfToBe = true,
                Tense = GrammaticalTenses.Present,
                Number = GrammaticalNumberOfWord.Plural,
                Person = GrammaticalPerson.Third,
                RootWord = rootWord
            });

            word = "was";
            AddGrammaticalWordFrame(word, new VerbGrammaticalWordFrame()
            {
                IsFormOfToBe = true,
                Tense = GrammaticalTenses.Past,
                Number = GrammaticalNumberOfWord.Singular,
                RootWord = rootWord
            });

            word = "were";
            AddGrammaticalWordFrame(word, new VerbGrammaticalWordFrame()
            {
                IsFormOfToBe = true,
                Tense = GrammaticalTenses.Past,
                Number = GrammaticalNumberOfWord.Plural,
                RootWord = rootWord
            });

            word = "being";
            AddGrammaticalWordFrame(word, new NounGrammaticalWordFrame()
            {
                Number = GrammaticalNumberOfWord.Singular,
                IsGerund = true,
                RootWord = rootWord
            });

            word = "will";
            AddGrammaticalWordFrame(word, new VerbGrammaticalWordFrame()
            {
                RootWord = rootWord,
                IsFormOfToBe = true,
                Tense = GrammaticalTenses.Future
            });
        }

        private static void DefineToDoWords()
        {
            var word = "do";
            var rootWord = word;

            AddGrammaticalWordFrame(word, new VerbGrammaticalWordFrame()
            {
                Tense = GrammaticalTenses.Present,
                IsFormOfToDo = true,
                LogicalMeaning = new List<string>()
                {
                    "act"
                }
            });

            word = "does";
            AddGrammaticalWordFrame(word, new VerbGrammaticalWordFrame()
            {
                IsFormOfToDo = true,
                Tense = GrammaticalTenses.Present,
                Person = GrammaticalPerson.Third,
                RootWord = rootWord
            });

            word = "did";
            AddGrammaticalWordFrame(word, new VerbGrammaticalWordFrame()
            {
                IsFormOfToDo = true,
                Tense = GrammaticalTenses.Past,
                VerbType = VerbType.Form_2,
                RootWord = rootWord
            });

            word = "done";
            AddGrammaticalWordFrame(word, new VerbGrammaticalWordFrame()
            {
                IsFormOfToDo = true,
                VerbType = VerbType.Form_3,
                RootWord = rootWord
            });

            word = "doing";
            AddGrammaticalWordFrame(word, new NounGrammaticalWordFrame()
            {
                Number = GrammaticalNumberOfWord.Singular,
                IsGerund = true,
                RootWord = rootWord
            });
        }

        private static void DefineToHaveWords()
        {
            var word = "have";
            var rootWord = word;
            AddGrammaticalWordFrame(word, new VerbGrammaticalWordFrame()
            {
                Tense = GrammaticalTenses.Present,
                IsFormOfToHave = true
            });

            word = "has";
            AddGrammaticalWordFrame(word, new VerbGrammaticalWordFrame()
            {
                IsFormOfToHave = true,
                Tense = GrammaticalTenses.Present,
                Person = GrammaticalPerson.Third,
                RootWord = rootWord
            });

            word = "had";
            AddGrammaticalWordFrame(word, new VerbGrammaticalWordFrame()
            {
                IsFormOfToHave = true,
                Tense = GrammaticalTenses.Past,
                VerbType = VerbType.Form_2,
                RootWord = rootWord
            });

            AddGrammaticalWordFrame(word, new VerbGrammaticalWordFrame()
            {
                IsFormOfToHave = true,
                VerbType = VerbType.Form_3,
                RootWord = rootWord
            });

            word = "having";
            AddGrammaticalWordFrame(word, new NounGrammaticalWordFrame()
            {
                Number = GrammaticalNumberOfWord.Singular,
                IsGerund = true,
                RootWord = rootWord
            });
        }

        private static void DefineModalWerbs()
        {
            var word = "can";
            var rootWord = word;
            AddGrammaticalWordFrame(word, new VerbGrammaticalWordFrame()
            {
                Tense = GrammaticalTenses.Present,
                IsModal = true
            });

            word = "could";
            AddGrammaticalWordFrame(word, new VerbGrammaticalWordFrame()
            {
                Tense = GrammaticalTenses.Past,
                IsModal = true,
                RootWord = rootWord
            });

            word = "may";
            rootWord = word;
            AddGrammaticalWordFrame(word, new VerbGrammaticalWordFrame()
            {
                Tense = GrammaticalTenses.Present,
                IsModal = true
            });

            word = "might";
            AddGrammaticalWordFrame(word, new VerbGrammaticalWordFrame()
            {
                Tense = GrammaticalTenses.Past,
                IsModal = true,
                RootWord = rootWord
            });

            word = "must";
            AddGrammaticalWordFrame(word, new VerbGrammaticalWordFrame()
            {
                Tense = GrammaticalTenses.Present,
                IsModal = true
            });

            word = "would";
            AddGrammaticalWordFrame(word, new VerbGrammaticalWordFrame()
            {
                Tense = GrammaticalTenses.Past,
                IsModal = true,
                RootWord = "will"
            });

            word = "shell";
            rootWord = word;
            AddGrammaticalWordFrame(word, new VerbGrammaticalWordFrame()
            {
                Tense = GrammaticalTenses.Present,
                IsModal = true
            });

            AddGrammaticalWordFrame(word, new VerbGrammaticalWordFrame()
            {
                Tense = GrammaticalTenses.Future,
                IsModal = false,
                IsRare = true
            });

            word = "should";
            AddGrammaticalWordFrame(word, new VerbGrammaticalWordFrame()
            {
                Tense = GrammaticalTenses.Past,
                IsModal = true,
                RootWord = rootWord
            });
        }

        private static void DefinePronouns()
        {
            var wordName = "i";
            var rootWord = wordName;
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                TypeOfPronoun = TypeOfPronoun.Personal,
                Case = CaseOfPersonalPronoun.Subject,
                Person = GrammaticalPerson.First,
                Number = GrammaticalNumberOfWord.Singular,
                LogicalMeaning = new List<string>()
                {
                    "animate"
                }
            });

            wordName = "me";
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                RootWord = rootWord,
                TypeOfPronoun = TypeOfPronoun.Personal,
                Case = CaseOfPersonalPronoun.Object,
                Person = GrammaticalPerson.First,
                Number = GrammaticalNumberOfWord.Singular,
                LogicalMeaning = new List<string>()
                {
                    "animate"
                }
            });

            wordName = "my";
            AddGrammaticalWordFrame(wordName, new ArticleGrammaticalWordFrame()
            {
                RootWord = rootWord,
                Kind = KindOfArticle.Definite
            });

            wordName = "mine";
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                RootWord = rootWord,
                TypeOfPronoun = TypeOfPronoun.Possessive,
                Case = CaseOfPersonalPronoun.Undefined,
                Person = GrammaticalPerson.First,
                Number = GrammaticalNumberOfWord.Singular,
                LogicalMeaning = new List<string>()
            });

            wordName = "myself";
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                RootWord = rootWord,
                TypeOfPronoun = TypeOfPronoun.Reflexive,
                Case = CaseOfPersonalPronoun.Undefined,
                Person = GrammaticalPerson.First,
                Number = GrammaticalNumberOfWord.Singular,
                LogicalMeaning = new List<string>()
            });

            wordName = "you";
            rootWord = wordName;
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                TypeOfPronoun = TypeOfPronoun.Personal,
                Case = CaseOfPersonalPronoun.Subject,
                Person = GrammaticalPerson.Second,
                Number = GrammaticalNumberOfWord.Neuter,
                LogicalMeaning = new List<string>()
                {
                    "animate"
                }
            });

            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                TypeOfPronoun = TypeOfPronoun.Personal,
                Case = CaseOfPersonalPronoun.Object,
                Person = GrammaticalPerson.Second,
                Number = GrammaticalNumberOfWord.Neuter,
                LogicalMeaning = new List<string>()
                {
                    "animate"
                }
            });

            wordName = "your";
            AddGrammaticalWordFrame(wordName, new ArticleGrammaticalWordFrame()
            {
                RootWord = rootWord,
                Kind = KindOfArticle.Definite
            });

            wordName = "yours";
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                RootWord = rootWord,
                TypeOfPronoun = TypeOfPronoun.Possessive,
                Case = CaseOfPersonalPronoun.Undefined,
                Person = GrammaticalPerson.Second,
                Number = GrammaticalNumberOfWord.Neuter,
                LogicalMeaning = new List<string>()
            });

            wordName = "yourself";
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                RootWord = rootWord,
                TypeOfPronoun = TypeOfPronoun.Reflexive,
                Case = CaseOfPersonalPronoun.Undefined,
                Person = GrammaticalPerson.Second,
                Number = GrammaticalNumberOfWord.Singular,
                LogicalMeaning = new List<string>()
            });

            wordName = "yourselves";
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                RootWord = rootWord,
                TypeOfPronoun = TypeOfPronoun.Reflexive,
                Case = CaseOfPersonalPronoun.Undefined,
                Person = GrammaticalPerson.Second,
                Number = GrammaticalNumberOfWord.Plural,
                LogicalMeaning = new List<string>()
            });

            wordName = "he";
            rootWord = wordName;
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                TypeOfPronoun = TypeOfPronoun.Personal,
                Case = CaseOfPersonalPronoun.Subject,
                Person = GrammaticalPerson.Third,
                Number = GrammaticalNumberOfWord.Singular,
                Gender = GrammaticalGender.Masculine,
                LogicalMeaning = new List<string>()
                {
                    "animate"
                }
            });

            wordName = "him";
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                RootWord = rootWord,
                TypeOfPronoun = TypeOfPronoun.Personal,
                Case = CaseOfPersonalPronoun.Object,
                Person = GrammaticalPerson.Third,
                Number = GrammaticalNumberOfWord.Singular,
                Gender = GrammaticalGender.Masculine,
                LogicalMeaning = new List<string>()
                {
                    "animate"
                }
            });

            wordName = "his";
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                RootWord = rootWord,
                TypeOfPronoun = TypeOfPronoun.Possessive,
                Case = CaseOfPersonalPronoun.Undefined,
                Person = GrammaticalPerson.Third,
                Number = GrammaticalNumberOfWord.Singular,
                Gender = GrammaticalGender.Masculine,
                LogicalMeaning = new List<string>()
            });

            wordName = "himself";
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                RootWord = rootWord,
                TypeOfPronoun = TypeOfPronoun.Reflexive,
                Case = CaseOfPersonalPronoun.Undefined,
                Person = GrammaticalPerson.Third,
                Number = GrammaticalNumberOfWord.Singular,
                Gender = GrammaticalGender.Masculine,
                LogicalMeaning = new List<string>()
            });

            wordName = "she";
            rootWord = wordName;
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                TypeOfPronoun = TypeOfPronoun.Personal,
                Case = CaseOfPersonalPronoun.Subject,
                Person = GrammaticalPerson.Third,
                Number = GrammaticalNumberOfWord.Singular,
                Gender = GrammaticalGender.Feminine,
                LogicalMeaning = new List<string>()
                {
                    "animate"
                }
            });

            wordName = "her";
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                RootWord = rootWord,
                TypeOfPronoun = TypeOfPronoun.Personal,
                Case = CaseOfPersonalPronoun.Object,
                Person = GrammaticalPerson.Third,
                Number = GrammaticalNumberOfWord.Singular,
                Gender = GrammaticalGender.Feminine,
                LogicalMeaning = new List<string>()
                {
                    "animate"
                }
            });

            AddGrammaticalWordFrame(wordName, new ArticleGrammaticalWordFrame()
            {
                RootWord = rootWord,
                Kind = KindOfArticle.Definite
            });

            wordName = "hers";
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                RootWord = rootWord,
                TypeOfPronoun = TypeOfPronoun.Possessive,
                Case = CaseOfPersonalPronoun.Undefined,
                Person = GrammaticalPerson.Third,
                Number = GrammaticalNumberOfWord.Singular,
                Gender = GrammaticalGender.Feminine,
                LogicalMeaning = new List<string>()
            });

            wordName = "herself";
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                RootWord = rootWord,
                TypeOfPronoun = TypeOfPronoun.Reflexive,
                Case = CaseOfPersonalPronoun.Undefined,
                Person = GrammaticalPerson.Third,
                Number = GrammaticalNumberOfWord.Singular,
                Gender = GrammaticalGender.Feminine,
                LogicalMeaning = new List<string>()
            });

            wordName = "it";
            rootWord = wordName;
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                TypeOfPronoun = TypeOfPronoun.Personal,
                Case = CaseOfPersonalPronoun.Subject,
                Person = GrammaticalPerson.Third,
                Number = GrammaticalNumberOfWord.Singular,
                LogicalMeaning = new List<string>()
                {
                    "animate"
                }
            });

            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                RootWord = rootWord,
                TypeOfPronoun = TypeOfPronoun.Personal,
                Case = CaseOfPersonalPronoun.Object,
                Person = GrammaticalPerson.Third,
                Number = GrammaticalNumberOfWord.Singular,
                LogicalMeaning = new List<string>()
                {
                    "animate"
                }
            });

            wordName = "its";
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                RootWord = rootWord,
                TypeOfPronoun = TypeOfPronoun.Possessive,
                Case = CaseOfPersonalPronoun.Undefined,
                Person = GrammaticalPerson.Third,
                Number = GrammaticalNumberOfWord.Singular,
                LogicalMeaning = new List<string>()
            });

            wordName = "itself";
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                RootWord = rootWord,
                TypeOfPronoun = TypeOfPronoun.Reflexive,
                Case = CaseOfPersonalPronoun.Undefined,
                Person = GrammaticalPerson.Third,
                Number = GrammaticalNumberOfWord.Singular,
                LogicalMeaning = new List<string>()
            });

            wordName = "we";
            rootWord = wordName;
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                TypeOfPronoun = TypeOfPronoun.Personal,
                Case = CaseOfPersonalPronoun.Subject,
                Person = GrammaticalPerson.First,
                Number = GrammaticalNumberOfWord.Plural,
                LogicalMeaning = new List<string>()
                {
                    "animate"
                }
            });

            wordName = "us";
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                RootWord = rootWord,
                TypeOfPronoun = TypeOfPronoun.Personal,
                Case = CaseOfPersonalPronoun.Object,
                Person = GrammaticalPerson.First,
                Number = GrammaticalNumberOfWord.Plural,
                LogicalMeaning = new List<string>()
                {
                    "animate"
                }
            });

            wordName = "our";
            AddGrammaticalWordFrame(wordName, new ArticleGrammaticalWordFrame()
            {
                RootWord = rootWord,
                Kind = KindOfArticle.Definite
            });

            wordName = "ours";
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                RootWord = rootWord,
                TypeOfPronoun = TypeOfPronoun.Possessive,
                Case = CaseOfPersonalPronoun.Undefined,
                Person = GrammaticalPerson.First,
                Number = GrammaticalNumberOfWord.Plural,
                LogicalMeaning = new List<string>()
            });

            wordName = "ourselves";
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                RootWord = rootWord,
                TypeOfPronoun = TypeOfPronoun.Reflexive,
                Case = CaseOfPersonalPronoun.Undefined,
                Person = GrammaticalPerson.First,
                Number = GrammaticalNumberOfWord.Plural,
                LogicalMeaning = new List<string>()
            });

            wordName = "they";
            rootWord = wordName;
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                TypeOfPronoun = TypeOfPronoun.Personal,
                Case = CaseOfPersonalPronoun.Subject,
                Person = GrammaticalPerson.Third,
                LogicalMeaning = new List<string>()
                {
                    "animate"
                }
            });

            wordName = "them";
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                RootWord = rootWord,
                TypeOfPronoun = TypeOfPronoun.Personal,
                Case = CaseOfPersonalPronoun.Object,
                Person = GrammaticalPerson.Third,
                LogicalMeaning = new List<string>()
                {
                    "animate"
                }
            });

            wordName = "their";
            AddGrammaticalWordFrame(wordName, new ArticleGrammaticalWordFrame()
            {
                RootWord = rootWord,
                Kind = KindOfArticle.Definite
            });

            wordName = "theirs";
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                RootWord = rootWord,
                TypeOfPronoun = TypeOfPronoun.Possessive,
                Case = CaseOfPersonalPronoun.Undefined,
                Person = GrammaticalPerson.Third,
                Number = GrammaticalNumberOfWord.Neuter,
                LogicalMeaning = new List<string>()
                {
                    "animate"
                }
            });

            wordName = "themselves";
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                RootWord = rootWord,
                TypeOfPronoun = TypeOfPronoun.Reflexive,
                Case = CaseOfPersonalPronoun.Undefined,
                Person = GrammaticalPerson.Third,
                LogicalMeaning = new List<string>()
                {
                    "animate"
                }
            });

            wordName = "this";
            rootWord = wordName;
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                TypeOfPronoun = TypeOfPronoun.Demonstrative,
                Number = GrammaticalNumberOfWord.Singular,
                LogicalMeaning = new List<string>()
                {
                    "object",
                    "near_object"
                }
            });

            wordName = "these";
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                RootWord = rootWord,
                TypeOfPronoun = TypeOfPronoun.Demonstrative,
                Number = GrammaticalNumberOfWord.Plural,
                LogicalMeaning = new List<string>()
                {
                    "object",
                    "near_object"
                }
            });

            wordName = "that";
            rootWord = wordName;
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                TypeOfPronoun = TypeOfPronoun.Demonstrative,
                Number = GrammaticalNumberOfWord.Singular,
                LogicalMeaning = new List<string>()
                {
                    "object",
                    "far_object"
                }
            });

            wordName = "those";
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                RootWord = rootWord,
                TypeOfPronoun = TypeOfPronoun.Demonstrative,
                Number = GrammaticalNumberOfWord.Plural,
                LogicalMeaning = new List<string>()
                {
                    "object",
                    "far_object"
                }
            });

            wordName = "former";
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                TypeOfPronoun = TypeOfPronoun.Demonstrative
            });

            wordName = "latter";
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                TypeOfPronoun = TypeOfPronoun.Demonstrative
            });

            wordName = "who";
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                TypeOfPronoun = TypeOfPronoun.Demonstrative,
                IsQuestionWord = true,
                LogicalMeaning = new List<string>()
                {
                    "animate"
                }
            });

            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                TypeOfPronoun = TypeOfPronoun.Interrogative,
                IsQuestionWord = true,
                LogicalMeaning = new List<string>()
                {
                    "animate"
                }
            });

            wordName = "whom";
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                TypeOfPronoun = TypeOfPronoun.Demonstrative,
                IsQuestionWord = true,
                LogicalMeaning = new List<string>()
                {
                    "object",
                    "as_possesive"
                }
            });

            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                TypeOfPronoun = TypeOfPronoun.Interrogative,
                IsQuestionWord = true,
                LogicalMeaning = new List<string>()
                {
                    "object",
                    "as_possesive"
                }
            });

            wordName = "which";
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                TypeOfPronoun = TypeOfPronoun.Demonstrative,
                IsQuestionWord = true,
                LogicalMeaning = new List<string>()
                {
                    "object"
                }
            });

            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                TypeOfPronoun = TypeOfPronoun.Interrogative,
                IsQuestionWord = true,
                LogicalMeaning = new List<string>()
                {
                    "object"
                }
            });

            wordName = "when";
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                TypeOfPronoun = TypeOfPronoun.Demonstrative,
                IsQuestionWord = true,
                LogicalMeaning = new List<string>()
                {
                    "time"
                }
            });

            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                TypeOfPronoun = TypeOfPronoun.Interrogative,
                IsQuestionWord = true,
                LogicalMeaning = new List<string>()
                {
                    "time"
                }
            });

            wordName = "where";
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                TypeOfPronoun = TypeOfPronoun.Demonstrative,
                IsQuestionWord = true,
                LogicalMeaning = new List<string>()
                {
                    "place"
                }
            });

            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                TypeOfPronoun = TypeOfPronoun.Interrogative,
                IsQuestionWord = true,
                LogicalMeaning = new List<string>()
                {
                    "place"
                }
            });

            wordName = "something";
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                TypeOfPronoun = TypeOfPronoun.Indefinite,
                LogicalMeaning = new List<string>()
                {
                    "object",
                    "thing"
                }
            });

            wordName = "anything";
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                TypeOfPronoun = TypeOfPronoun.Indefinite,
                LogicalMeaning = new List<string>()
                {
                    "object",
                    "thing"
                }
            });

            wordName = "nothing";
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                TypeOfPronoun = TypeOfPronoun.Indefinite,
                IsNegation = true,
                LogicalMeaning = new List<string>()
                {
                    "object",
                    "thing"
                }
            });

            wordName = "somewhere";
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                TypeOfPronoun = TypeOfPronoun.Indefinite,
                LogicalMeaning = new List<string>()
                {
                    "object",
                    "about_place"
                }
            });

            wordName = "anywhere";
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                TypeOfPronoun = TypeOfPronoun.Indefinite,
                LogicalMeaning = new List<string>()
                {
                    "object",
                    "about_place"
                }
            });

            wordName = "nowhere";
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                TypeOfPronoun = TypeOfPronoun.Indefinite,
                IsNegation = true,
                LogicalMeaning = new List<string>()
                {
                    "object",
                    "about_place"
                }
            });

            wordName = "someone";
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                TypeOfPronoun = TypeOfPronoun.Indefinite,
                LogicalMeaning = new List<string>()
                {
                    "object",
                    "people"
                }
            });

            wordName = "anyone";
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                TypeOfPronoun = TypeOfPronoun.Indefinite,
                LogicalMeaning = new List<string>()
                {
                    "object",
                    "people"
                }
            });

            wordName = "what";
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                TypeOfPronoun = TypeOfPronoun.Interrogative,
                IsQuestionWord = true,
                LogicalMeaning = new List<string>()
                {
                    "object"
                }
            });

            wordName = "whose";
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                TypeOfPronoun = TypeOfPronoun.Interrogative,
                IsQuestionWord = true,
                LogicalMeaning = new List<string>()
                {
                    "object",
                    "as_possesive"
                }
            });

            wordName = "why";
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                TypeOfPronoun = TypeOfPronoun.Interrogative,
                IsQuestionWord = true,
                LogicalMeaning = new List<string>()
                {
                    "reason"
                }
            });

            wordName = "how";
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                TypeOfPronoun = TypeOfPronoun.Interrogative,
                IsQuestionWord = true,
                LogicalMeaning = new List<string>()
                {
                    "way"
                }
            });
        }

        private static void DefineArticles()
        {
            var word = "the";
            AddGrammaticalWordFrame(word, new ArticleGrammaticalWordFrame()
            {
                Kind = KindOfArticle.Definite
            });

            word = "a";
            AddGrammaticalWordFrame(word, new ArticleGrammaticalWordFrame()
            {
                Number = GrammaticalNumberOfWord.Singular,
                Kind = KindOfArticle.Indefinite
            });

            word = "an";
            AddGrammaticalWordFrame(word, new ArticleGrammaticalWordFrame()
            {
                Number = GrammaticalNumberOfWord.Singular,
                Kind = KindOfArticle.Indefinite
            });

            word = "no";
            AddGrammaticalWordFrame(word, new ArticleGrammaticalWordFrame()
            {
                Kind = KindOfArticle.Negative
            });
        }

        private static void ProcessAllPrepositions()
        {
#if DEBUG
            //NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessAllPrepositions");
#endif

            var word = "aboard";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "about";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "above";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "absent";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "across";
            var rootWord = word;
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "cross";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                RootWord = rootWord,
                IsArchaic = true
            });

            word = "after";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "against";
            rootWord = word;
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "'gainst";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                RootWord = rootWord
            });

            word = "gainst";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                RootWord = rootWord,
                IsArchaic = true,
                IsPoetic = true
            });

            word = "again";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                RootWord = rootWord
            });

            word = "gain";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                RootWord = rootWord,
                IsArchaic = true
            });

            word = "along";
            rootWord = word;
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "'long";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                RootWord = rootWord,
                IsAbbreviation = true
            });

            word = "alongst";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                RootWord = rootWord,
                IsArchaic = true
            });

            word = "alongside";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "amid";
            rootWord = word;
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "amidst";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                RootWord = rootWord
            });

            word = "mid";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                RootWord = rootWord
            });

            word = "midst";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                RootWord = rootWord,
                IsArchaic = true,
                IsPoetic = true
            });

            word = "among";
            rootWord = word;
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "amongst";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                RootWord = rootWord
            });

            word = "'mong";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                RootWord = rootWord
            });

            word = "mong";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                RootWord = rootWord
            });

            word = "'mongst";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                RootWord = rootWord,
                IsAbbreviation = true
            });

            word = "apropos";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                IsRare = true
            });

            word = "apud";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "around";
            rootWord = word;
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "'round";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                RootWord = rootWord
            });

            word = "round";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                RootWord = rootWord,
                IsAbbreviation = true
            });

            word = "as";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "astride";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "at";
            rootWord = word;
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "@";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                RootWord = rootWord,
                IsAbbreviation = true
            });

            word = "atop";
            rootWord = word;
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "ontop";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                RootWord = rootWord
            });

            word = "bar";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "before";
            rootWord = word;
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "afore";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                RootWord = rootWord
            });

            word = "tofore";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                RootWord = rootWord,
                IsArchaic = true,
                IsDialectal = true
            });

            word = "B4";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                RootWord = rootWord,
                IsAbbreviation = true
            });

            word = "behind";
            rootWord = word;
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "ahind";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                RootWord = rootWord,
                IsArchaic = true,
                IsDialectal = true
            });

            word = "below";
            rootWord = word;
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "ablow";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                RootWord = rootWord
            });

            word = "allow";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                RootWord = rootWord,
                IsDialectal = true
            });

            word = "beneath";
            rootWord = word;
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "'neath";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                RootWord = rootWord
            });

            word = "neath";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                RootWord = rootWord,
                IsPoetic = true
            });

            word = "beside";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "besides";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "between";
            rootWord = word;
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "atween";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                RootWord = rootWord,
                IsArchaic = true,
                IsDialectal = true
            });

            word = "beyond";
            rootWord = word;
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "ayond ";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                RootWord = rootWord,
                IsArchaic = true,
                IsDialectal = true
            });

            word = "but";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "by";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "chez";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                IsRare = true
            });

            word = "circa";
            rootWord = word;
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "c.";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                RootWord = rootWord,
                IsAbbreviation = true
            });

            word = "ca.";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                RootWord = rootWord,
                IsAbbreviation = true
            });

            word = "come";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "dehors";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "despite";
            rootWord = word;
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "spite";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                RootWord = rootWord,
                IsAbbreviation = true
            });

            word = "down";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "during";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "except";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "for";
            rootWord = word;
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "4";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                RootWord = rootWord,
                IsAbbreviation = true
            });

            word = "from";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "in";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "inside";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "into";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "less";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "like";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "minus";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "near";
            rootWord = word;
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "nearer";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                RootWord = rootWord,
                Comparison = GrammaticalComparison.Comparative
            });

            word = "nearest ";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                RootWord = rootWord,
                Comparison = GrammaticalComparison.Superlative
            });

            word = "anear";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                RootWord = rootWord,
                IsArchaic = true
            });

            word = "notwithstanding";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            AddGrammaticalWordFrame(word, new PostpositionGrammaticalWordFrame()
            {
            });

            word = "of";
            rootWord = word;
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "o'";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                RootWord = rootWord,
                IsPoetic = true,
                IsDialectal = true
            });

            word = "off";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "on";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            AddGrammaticalWordFrame(word, new PostpositionGrammaticalWordFrame()
            {
            });

            word = "onto";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "opposite";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "out";
            rootWord = word;
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "outen";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                RootWord = rootWord,
                IsArchaic = true,
                IsDialectal = true
            });

            word = "outside";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "over";
            rootWord = word;
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "o'er";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                RootWord = rootWord,
                IsPoetic = true
            });

            word = "pace";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "past";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "per";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "plus";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "post";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "pre";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "pro";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "qua";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "re";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "sans";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "save";
            rootWord = word;
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "sauf";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                RootWord = rootWord,
                IsArchaic = true
            });

            word = "short";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            AddGrammaticalWordFrame(word, new PostpositionGrammaticalWordFrame()
            {
            });

            word = "since";
            rootWord = word;
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "sithence";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                RootWord = rootWord,
                IsArchaic = true
            });

            word = "than";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "through";
            rootWord = word;
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            AddGrammaticalWordFrame(word, new PostpositionGrammaticalWordFrame()
            {
            });

            word = "thru";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                RootWord = rootWord,
                IsAbbreviation = true
            });

            word = "throughout";
            rootWord = word;
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "thruout";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                RootWord = rootWord,
                IsAbbreviation = true
            });

            word = "till";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "to";
            rootWord = word;
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                ConditionalLogicalMeaning = new Dictionary<string, IList<string>>()
                {
                    {
                        "go", new List<string>() {
                            "direction"
                        }
                    }
                }
            });

            word = "2";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                RootWord = rootWord,
                IsAbbreviation = true
            });

            word = "toward";
            rootWord = word;
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "towards";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                RootWord = rootWord
            });

            word = "under";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "underneath";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "unlike";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "until";
            rootWord = word;
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "'til";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                RootWord = rootWord,
                IsAbbreviation = true
            });

            word = "til";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                RootWord = rootWord,
                IsAbbreviation = true
            });

            word = "unto";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "up";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "upon";
            rootWord = word;
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "'pon";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                RootWord = rootWord,
                IsAbbreviation = true
            });

            word = "pon";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                RootWord = rootWord,
                IsAbbreviation = true
            });

            word = "upside";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "versus";
            rootWord = word;
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "vs.";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                RootWord = rootWord,
                IsAbbreviation = true
            });

            word = "v.";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                RootWord = rootWord,
                IsAbbreviation = true
            });

            word = "via";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "vice";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "vis-à-vis";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "with";
            rootWord = word;
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "w/";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                RootWord = rootWord,
                IsAbbreviation = true
            });

            word = "wi'";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                RootWord = rootWord,
                IsAbbreviation = true
            });

            word = "c̄";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                RootWord = rootWord,
                IsAbbreviation = true
            });

            word = "within";
            rootWord = word;
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "w/i";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                RootWord = rootWord,
                IsAbbreviation = true
            });

            word = "without";
            rootWord = word;
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "w/o";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                RootWord = rootWord,
                IsAbbreviation = true
            });

            word = "worth";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            word = "next";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
            });

            //------
            word = "ago";
            AddGrammaticalWordFrame(word, new PostpositionGrammaticalWordFrame()
            {
            });

            word = "apart";
            AddGrammaticalWordFrame(word, new PostpositionGrammaticalWordFrame()
            {
            });

            word = "aside";
            rootWord = word;
            AddGrammaticalWordFrame(word, new PostpositionGrammaticalWordFrame()
            {
            });

            word = "aslant";
            AddGrammaticalWordFrame(word, new PostpositionGrammaticalWordFrame()
            {
                RootWord = rootWord,
                IsArchaic = true
            });

            word = "away";
            AddGrammaticalWordFrame(word, new PostpositionGrammaticalWordFrame()
            {
            });

            word = "hence";
            AddGrammaticalWordFrame(word, new PostpositionGrammaticalWordFrame()
            {
            });

            word = "withal";
            AddGrammaticalWordFrame(word, new PostpositionGrammaticalWordFrame()
            {
                IsArchaic = true
            });
        }

        private static void ProcessAllConjunctions()
        {
#if DEBUG
            //NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessAllConjunctions");
#endif

            var word = "and";
            AddGrammaticalWordFrame(word, new ConjunctionGrammaticalWordFrame()
            {
                Kind = KindOfConjunction.Coordinating
            });

            word = "but";
            AddGrammaticalWordFrame(word, new ConjunctionGrammaticalWordFrame()
            {
                Kind = KindOfConjunction.Coordinating
            });

            word = "for";
            AddGrammaticalWordFrame(word, new ConjunctionGrammaticalWordFrame()
            {
                Kind = KindOfConjunction.Coordinating
            });

            word = "nor";
            AddGrammaticalWordFrame(word, new ConjunctionGrammaticalWordFrame()
            {
                Kind = KindOfConjunction.Coordinating
            });

            word = "or";
            AddGrammaticalWordFrame(word, new ConjunctionGrammaticalWordFrame()
            {
                Kind = KindOfConjunction.Coordinating
            });

            word = "so";
            AddGrammaticalWordFrame(word, new ConjunctionGrammaticalWordFrame()
            {
                Kind = KindOfConjunction.Coordinating
            });

            word = "yet";
            AddGrammaticalWordFrame(word, new ConjunctionGrammaticalWordFrame()
            {
                Kind = KindOfConjunction.Coordinating
            });

            word = "though";
            AddGrammaticalWordFrame(word, new ConjunctionGrammaticalWordFrame()
            {
                Kind = KindOfConjunction.Subordinating,
                SecondKind = SecondKindOfConjunction.Concession
            });

            word = "although";
            AddGrammaticalWordFrame(word, new ConjunctionGrammaticalWordFrame()
            {
                Kind = KindOfConjunction.Subordinating,
                SecondKind = SecondKindOfConjunction.Concession
            });

            word = "while";
            AddGrammaticalWordFrame(word, new ConjunctionGrammaticalWordFrame()
            {
                Kind = KindOfConjunction.Subordinating,
                SecondKind = SecondKindOfConjunction.Concession
            });

            word = "if";
            AddGrammaticalWordFrame(word, new ConjunctionGrammaticalWordFrame()
            {
                Kind = KindOfConjunction.Subordinating,
                SecondKind = SecondKindOfConjunction.Condition
            });

            word = "unless";
            AddGrammaticalWordFrame(word, new ConjunctionGrammaticalWordFrame()
            {
                Kind = KindOfConjunction.Subordinating,
                SecondKind = SecondKindOfConjunction.Condition
            });

            word = "until";
            AddGrammaticalWordFrame(word, new ConjunctionGrammaticalWordFrame()
            {
                Kind = KindOfConjunction.Subordinating,
                SecondKind = SecondKindOfConjunction.Condition
            });

            word = "lest";
            AddGrammaticalWordFrame(word, new ConjunctionGrammaticalWordFrame()
            {
                Kind = KindOfConjunction.Subordinating,
                SecondKind = SecondKindOfConjunction.Condition
            });

            word = "than";
            AddGrammaticalWordFrame(word, new ConjunctionGrammaticalWordFrame()
            {
                Kind = KindOfConjunction.Subordinating,
                SecondKind = SecondKindOfConjunction.Comparison
            });

            word = "whether";
            AddGrammaticalWordFrame(word, new ConjunctionGrammaticalWordFrame()
            {
                Kind = KindOfConjunction.Subordinating,
                SecondKind = SecondKindOfConjunction.Comparison
            });

            word = "whereas";
            AddGrammaticalWordFrame(word, new ConjunctionGrammaticalWordFrame()
            {
                Kind = KindOfConjunction.Subordinating,
                SecondKind = SecondKindOfConjunction.Comparison
            });

            word = "after";
            AddGrammaticalWordFrame(word, new ConjunctionGrammaticalWordFrame()
            {
                Kind = KindOfConjunction.Subordinating,
                SecondKind = SecondKindOfConjunction.Time
            });

            word = "before";
            AddGrammaticalWordFrame(word, new ConjunctionGrammaticalWordFrame()
            {
                Kind = KindOfConjunction.Subordinating,
                SecondKind = SecondKindOfConjunction.Time
            });

            word = "once";
            AddGrammaticalWordFrame(word, new ConjunctionGrammaticalWordFrame()
            {
                Kind = KindOfConjunction.Subordinating,
                SecondKind = SecondKindOfConjunction.Time
            });

            word = "since";
            AddGrammaticalWordFrame(word, new ConjunctionGrammaticalWordFrame()
            {
                Kind = KindOfConjunction.Subordinating,
                SecondKind = SecondKindOfConjunction.Time
            });

            word = "till";
            AddGrammaticalWordFrame(word, new ConjunctionGrammaticalWordFrame()
            {
                Kind = KindOfConjunction.Subordinating,
                SecondKind = SecondKindOfConjunction.Time
            });

            word = "until";
            AddGrammaticalWordFrame(word, new ConjunctionGrammaticalWordFrame()
            {
                Kind = KindOfConjunction.Subordinating,
                SecondKind = SecondKindOfConjunction.Time
            });

            word = "when";
            AddGrammaticalWordFrame(word, new ConjunctionGrammaticalWordFrame()
            {
                Kind = KindOfConjunction.Subordinating,
                SecondKind = SecondKindOfConjunction.Time
            });

            word = "whenever";
            AddGrammaticalWordFrame(word, new ConjunctionGrammaticalWordFrame()
            {
                Kind = KindOfConjunction.Subordinating,
                SecondKind = SecondKindOfConjunction.Time
            });

            word = "while";
            AddGrammaticalWordFrame(word, new ConjunctionGrammaticalWordFrame()
            {
                Kind = KindOfConjunction.Subordinating,
                SecondKind = SecondKindOfConjunction.Time
            });

            word = "because";
            AddGrammaticalWordFrame(word, new ConjunctionGrammaticalWordFrame()
            {
                Kind = KindOfConjunction.Subordinating,
                SecondKind = SecondKindOfConjunction.Reason
            });

            word = "since";
            AddGrammaticalWordFrame(word, new ConjunctionGrammaticalWordFrame()
            {
                Kind = KindOfConjunction.Subordinating,
                SecondKind = SecondKindOfConjunction.Reason
            });

            word = "why";
            AddGrammaticalWordFrame(word, new ConjunctionGrammaticalWordFrame()
            {
                Kind = KindOfConjunction.Subordinating,
                SecondKind = SecondKindOfConjunction.Reason
            });

            word = "that";
            AddGrammaticalWordFrame(word, new ConjunctionGrammaticalWordFrame()
            {
                Kind = KindOfConjunction.Subordinating,
                SecondKind = SecondKindOfConjunction.Adjective
            });

            word = "what";
            AddGrammaticalWordFrame(word, new ConjunctionGrammaticalWordFrame()
            {
                Kind = KindOfConjunction.Subordinating,
                SecondKind = SecondKindOfConjunction.Adjective,
                IsQuestionWord = true
            });

            word = "whatever";
            AddGrammaticalWordFrame(word, new ConjunctionGrammaticalWordFrame()
            {
                Kind = KindOfConjunction.Subordinating,
                SecondKind = SecondKindOfConjunction.Adjective,
                IsQuestionWord = true
            });

            word = "which";
            AddGrammaticalWordFrame(word, new ConjunctionGrammaticalWordFrame()
            {
                Kind = KindOfConjunction.Subordinating,
                SecondKind = SecondKindOfConjunction.Adjective,
                IsQuestionWord = true
            });

            word = "whichever";
            AddGrammaticalWordFrame(word, new ConjunctionGrammaticalWordFrame()
            {
                Kind = KindOfConjunction.Subordinating,
                SecondKind = SecondKindOfConjunction.Adjective,
                IsQuestionWord = true
            });

            word = "who";
            AddGrammaticalWordFrame(word, new ConjunctionGrammaticalWordFrame()
            {
                Kind = KindOfConjunction.Subordinating,
                SecondKind = SecondKindOfConjunction.RelativePronoun,
                IsQuestionWord = true
            });

            word = "whoever";
            AddGrammaticalWordFrame(word, new ConjunctionGrammaticalWordFrame()
            {
                Kind = KindOfConjunction.Subordinating,
                SecondKind = SecondKindOfConjunction.RelativePronoun,
                IsQuestionWord = true
            });

            word = "whom";
            AddGrammaticalWordFrame(word, new ConjunctionGrammaticalWordFrame()
            {
                Kind = KindOfConjunction.Subordinating,
                SecondKind = SecondKindOfConjunction.RelativePronoun,
                IsQuestionWord = true
            });

            word = "whomever";
            AddGrammaticalWordFrame(word, new ConjunctionGrammaticalWordFrame()
            {
                Kind = KindOfConjunction.Subordinating,
                SecondKind = SecondKindOfConjunction.RelativePronoun,
                IsQuestionWord = true
            });

            word = "whose";
            AddGrammaticalWordFrame(word, new ConjunctionGrammaticalWordFrame()
            {
                Kind = KindOfConjunction.Subordinating,
                SecondKind = SecondKindOfConjunction.RelativePronoun,
                IsQuestionWord = true
            });

            word = "how";
            AddGrammaticalWordFrame(word, new ConjunctionGrammaticalWordFrame()
            {
                Kind = KindOfConjunction.Subordinating,
                SecondKind = SecondKindOfConjunction.Manner,
                IsQuestionWord = true
            });

            word = "where";
            AddGrammaticalWordFrame(word, new ConjunctionGrammaticalWordFrame()
            {
                Kind = KindOfConjunction.Subordinating,
                SecondKind = SecondKindOfConjunction.Place,
                IsQuestionWord = true
            });

            word = "wherever";
            AddGrammaticalWordFrame(word, new ConjunctionGrammaticalWordFrame()
            {
                Kind = KindOfConjunction.Subordinating,
                SecondKind = SecondKindOfConjunction.Place,
                IsQuestionWord = true
            });
        }




        private static void DefineAdverbs()
        {
            var word = "not";
            AddGrammaticalWordFrame(word, new AdverbGrammaticalWordFrame()
            {
                IsDeterminer = true,
                IsNegation = true
            });
        }

        private static void DefineUsualWords()
        {
            DefineUsualNouns();
            DefineUsualVerbs();
            DefineUsualAdjectives();
            DefineUsualPrepositions();
            DefineNames();
        }

        private static void DefineUsualNouns()
        {
            var word = "dog";
            AddGrammaticalWordFrame(word, new NounGrammaticalWordFrame()
            {
                Number = GrammaticalNumberOfWord.Singular,
                IsCountable = true,
                LogicalMeaning = new List<string>()
                {
                    "animate"
                }
            });

            word = "waypoint";
            AddGrammaticalWordFrame(word, new NounGrammaticalWordFrame()
            {
                Number = GrammaticalNumberOfWord.Singular,
                IsCountable = true,
                LogicalMeaning = new List<string>()
                {
                    "place"
                }
            });

            word = "work";
            AddGrammaticalWordFrame(word, new NounGrammaticalWordFrame() {
                Number = GrammaticalNumberOfWord.Singular
            });

            word = "pleasure";
            AddGrammaticalWordFrame(word, new NounGrammaticalWordFrame()
            {
                Number = GrammaticalNumberOfWord.Singular
            });

            word = "meeting";
            AddGrammaticalWordFrame(word, new NounGrammaticalWordFrame()
            {
                Number = GrammaticalNumberOfWord.Singular
            });
        }

        private static void DefineUsualVerbs()
        {
            var word = "know";
            var rootWord = word;
            AddGrammaticalWordFrame(word, new VerbGrammaticalWordFrame()
            {
                Tense = GrammaticalTenses.Present,
                LogicalMeaning = new List<string>()
                {
                    "state"
                }
            });

            word = "go";
            rootWord = word;
            AddGrammaticalWordFrame(word, new VerbGrammaticalWordFrame()
            {
                Tense = GrammaticalTenses.Present,
                LogicalMeaning = new List<string>()
                {
                    "act",
                    "moving"
                }
            });

            word = "play";
            rootWord = word;
            AddGrammaticalWordFrame(word, new VerbGrammaticalWordFrame()
            {
                Tense = GrammaticalTenses.Present,
                LogicalMeaning = new List<string>()
                {
                    "act"
                }
            });

            word = "start";
            rootWord = word;
            AddGrammaticalWordFrame(word, new VerbGrammaticalWordFrame()
            {
                Tense = GrammaticalTenses.Present,
                LogicalMeaning = new List<string>()
                {
                    "state"
                }
            });

            word = "starts";
            AddGrammaticalWordFrame(word, new VerbGrammaticalWordFrame()
            {
                Tense = GrammaticalTenses.Present,
                Person = GrammaticalPerson.First,
                RootWord = rootWord,
                LogicalMeaning = new List<string>()
                {
                    "state"
                }
            });
        }

        private static void DefineUsualAdjectives()
        {
            var word = "sorry";
            AddGrammaticalWordFrame(word, new AdjectiveGrammaticalWordFrame());

            word = "green";
            AddGrammaticalWordFrame(word, new AdjectiveGrammaticalWordFrame()
            {
                LogicalMeaning = new List<string>()
                {
                    "color"
                }
            });
        }

        private static void DefineUsualPrepositions()
        {
            /*var word = "to";
            AddGrammaticalWordFrame(word, new PrepositionGrammaticalWordFrame()
            {
                ConditionalLogicalMeaning = new Dictionary<string, IList<string>>()
                {
                    {
                        "go", new List<string>() {
                            "direction"
                        }
                    }
                }
            });*/


        }

        private static void DefineNames()
        {
            DefineHumanNames();
        }

        private static void DefineHumanNames()
        {
            var word = "Tom";
            AddGrammaticalWordFrame(word, new NounGrammaticalWordFrame()
            {
                IsName = true,
                IsCountable = true,
                Number = GrammaticalNumberOfWord.Singular,
                Gender = GrammaticalGender.Masculine,
                LogicalMeaning = new List<string>()
                {
                    "animate"
                }
            });
        }
    }
}
