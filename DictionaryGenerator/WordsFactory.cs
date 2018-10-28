using MyNPCLib.SimpleWordsDict;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;

namespace DictionaryGenerator
{
    public partial class WordsFactory
    {
        public WordsFactory()
        {
            mRootNounsSource = new RootNounsWordNetSource();
            mRootVerbsSource = new RootVerbsWordNetSource();
            mRootAdjSource = new RootAdjWordNetSource();
            mRootAdvSource = new RootAdvWordNetSource();

            mNounAntiStemmer = new NounAntiStemmer();
            mVerbAntiStemmer = new VerbAntiStemmer();
            mAdjAntiStemmer = new AdjAntiStemmer();
            mAdvAntiStemmer = new AdvAntiStemmer();

            mMayHaveGerundOrInfinitiveAfterSelfSource = new MayHaveGerundOrInfinitiveAfterSelfSource();

            mVerbLogicalMeaningsSource = new VerbLogicalMeaningsSource();

            mAdjLogicalMeaningsSource = new AdjLogicalMeaningsSource();
            mAdvLogicalMeaningsSource = new AdvLogicalMeaningsSource();
        }

        private RootNounsWordNetSource mRootNounsSource;
        private RootVerbsWordNetSource mRootVerbsSource;
        private RootAdjWordNetSource mRootAdjSource;
        private RootAdvWordNetSource mRootAdvSource;

        private NounAntiStemmer mNounAntiStemmer;
        private VerbAntiStemmer mVerbAntiStemmer;
        private AdjAntiStemmer mAdjAntiStemmer;
        private AdvAntiStemmer mAdvAntiStemmer;

        private MayHaveGerundOrInfinitiveAfterSelfSource mMayHaveGerundOrInfinitiveAfterSelfSource;

        private VerbLogicalMeaningsSource mVerbLogicalMeaningsSource;
        private AdjLogicalMeaningsSource mAdjLogicalMeaningsSource;
        private AdvLogicalMeaningsSource mAdvLogicalMeaningsSource;

        private Dictionary<string, List<RootNounSourceWordItem>> mRootNounDict;
        private Dictionary<string, List<RootVerbSourceWordItem>> mRootVerbsDict;
        private Dictionary<string, List<RootAdjSourceWordItem>> mRootAdjsDict;
        private Dictionary<string, List<RootAdvSourceWordItem>> mRootAdvsDict;

        private WordSplitter mWordSplitter;

        private Dictionary<string, List<string>> mNounClassesDict;

        private int mTotalCount;

        private WordsDictData mWordsDictData;
        private WordsDictData mWordsDictDataOfName;

        public void Run()
        {
            var usualWordsList = new List<string>();
            var namesWordsList = new List<string>();
            var digitsWordsList = new List<string>();
            var complexWordsList = new List<string>();

            var rootNounsList = mRootNounsSource.ReadAll();

            var rootNounClassesFactory = new RootNounClassesFactory(rootNounsList);
            mNounClassesDict = rootNounClassesFactory.Result;

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Run rootNounsList.Count = {rootNounsList.Count}");
#endif
            ReaderOfRootSourceWordItemHelper.SeparateWords(rootNounsList, ref usualWordsList, ref namesWordsList, ref digitsWordsList, ref complexWordsList);

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"TSTSeparateWords usualWordsList.Count = {usualWordsList.Count}");
            NLog.LogManager.GetCurrentClassLogger().Info($"TSTSeparateWords namesWordsList.Count = {namesWordsList.Count}");
            NLog.LogManager.GetCurrentClassLogger().Info($"TSTSeparateWords digitsWordsList.Count = {digitsWordsList.Count}");
            NLog.LogManager.GetCurrentClassLogger().Info($"TSTSeparateWords complexWordsList.Count = {complexWordsList.Count}");
#endif

            mRootNounDict = rootNounsList.GroupBy(p => p.Word).ToDictionary(p => p.Key, p => p.ToList());

            var rootVerbsList = mRootVerbsSource.ReadAll();

            ReaderOfRootSourceWordItemHelper.SeparateWords(rootVerbsList, ref usualWordsList, ref namesWordsList, ref digitsWordsList, ref complexWordsList);

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"TSTSeparateWords usualWordsList.Count = {usualWordsList.Count}");
            NLog.LogManager.GetCurrentClassLogger().Info($"TSTSeparateWords namesWordsList.Count = {namesWordsList.Count}");
            NLog.LogManager.GetCurrentClassLogger().Info($"TSTSeparateWords digitsWordsList.Count = {digitsWordsList.Count}");
            NLog.LogManager.GetCurrentClassLogger().Info($"TSTSeparateWords complexWordsList.Count = {complexWordsList.Count}");
#endif

            mRootVerbsDict = rootVerbsList.GroupBy(p => p.Word).ToDictionary(p => p.Key, p => p.ToList());

            var rootAdjsList = mRootAdjSource.ReadAll();

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Run rootAdjsList.Count = {rootAdjsList.Count}");
#endif

            ReaderOfRootSourceWordItemHelper.SeparateWords(rootAdjsList, ref usualWordsList, ref namesWordsList, ref digitsWordsList, ref complexWordsList);

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"TSTSeparateWords usualWordsList.Count = {usualWordsList.Count}");
            NLog.LogManager.GetCurrentClassLogger().Info($"TSTSeparateWords namesWordsList.Count = {namesWordsList.Count}");
            NLog.LogManager.GetCurrentClassLogger().Info($"TSTSeparateWords digitsWordsList.Count = {digitsWordsList.Count}");
            NLog.LogManager.GetCurrentClassLogger().Info($"TSTSeparateWords complexWordsList.Count = {complexWordsList.Count}");
#endif

            mRootAdjsDict = rootAdjsList.GroupBy(p => p.Word).ToDictionary(p => p.Key, p => p.ToList());

            var rootAdvsList = mRootAdvSource.ReadAll();

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Run rootAdvsList.Count = {rootAdvsList.Count}");
#endif

            ReaderOfRootSourceWordItemHelper.SeparateWords(rootAdvsList, ref usualWordsList, ref namesWordsList, ref digitsWordsList, ref complexWordsList);

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"TSTSeparateWords usualWordsList.Count = {usualWordsList.Count}");
            NLog.LogManager.GetCurrentClassLogger().Info($"TSTSeparateWords namesWordsList.Count = {namesWordsList.Count}");
            NLog.LogManager.GetCurrentClassLogger().Info($"TSTSeparateWords digitsWordsList.Count = {digitsWordsList.Count}");
            NLog.LogManager.GetCurrentClassLogger().Info($"TSTSeparateWords complexWordsList.Count = {complexWordsList.Count}");
#endif

            mRootAdvsDict = rootAdvsList.GroupBy(p => p.Word).ToDictionary(p => p.Key, p => p.ToList());

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Run usualWordsList.Count = {usualWordsList.Count}");
#endif

            mWordSplitter = new WordSplitter(mRootNounDict, mRootVerbsDict, mRootAdjsDict, mRootAdvsDict);

            mWordsDictData = new WordsDictData();
            mWordsDictData.WordsDict = new Dictionary<string, WordFrame>();
            //mWordsDictData.NamesList = new List<string>();

            mWordsDictDataOfName = new WordsDictData();
            mWordsDictDataOfName.WordsDict = new Dictionary<string, WordFrame>();
            //mWordsDictDataOfName.NamesList = new List<string>();

            ProcessUsualWords(usualWordsList);
            ProcessNames(namesWordsList);
            //ProcessDigits(digitsWordsList);
            ProcessComplexPhrases(complexWordsList);

            SimpleSaveDict("main.dict", mWordsDictData);
            SimpleSaveDict("names.dict", mWordsDictDataOfName);

#if DEBUG
            //NLog.LogManager.GetCurrentClassLogger().Info($"Run mTotalCount = {mTotalCount}");
            NLog.LogManager.GetCurrentClassLogger().Info($"Run mWordsDictData.WordsDict.Count = {mWordsDictData.WordsDict.Count}");
            //NLog.LogManager.GetCurrentClassLogger().Info($"Run mWordsDictData = {mWordsDictData}");
            NLog.LogManager.GetCurrentClassLogger().Info($"Run mWordsDictDataOfName.WordsDict.Count = {mWordsDictDataOfName.WordsDict.Count}");
            //NLog.LogManager.GetCurrentClassLogger().Info($"Run mWordsDictDataOfName = {mWordsDictDataOfName}");
#endif
        }

        private void SimpleSaveDict(string localPath, WordsDictData dict)
        {
            var rootPath = AppDomain.CurrentDomain.BaseDirectory;

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"SimpleSaveDict rootPath = {rootPath}");
#endif

            var fullPath = Path.Combine(rootPath, localPath);

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"SimpleSaveDict fullPath = {fullPath}");
#endif
            var serializationEngine = new WordsDictSerializationEngine();
            serializationEngine.SaveToFile(dict, fullPath);


            //if(File.Exists(fullPath))
            //{
            //    File.Delete(fullPath);
            //}

            //var binaryFormatter = new BinaryFormatter();

            //using (var fs = File.OpenWrite(fullPath))
            //{
            //    binaryFormatter.Serialize(fs, dict);
            //    fs.Flush();
            //}
        }

        /*
         VERBS THAT ARE NOT USUALLY USED IN THE CONTINUOUS FORM
The verbs in the list below are normally used in the simple form because they refer to states, rather than actions or processes.

SENSES / PERCEPTION
to feel*
to hear
to see*
to smell
to taste
OPINION
to assume
to believe
to consider
to doubt
to feel (= to think)
to find (= to consider)
to suppose
to think*
MENTAL STATES
to forget
to imagine
to know
to mean
to notice
to recognise
to remember
to understand
EMOTIONS / DESIRES
to envy
to fear
to dislike
to hate
to hope
to like
to love
to mind
to prefer
to regret
to want
to wish
MEASUREMENT
to contain
to cost
to hold
to measure
to weigh
OTHERS
to look (=resemble)
to seem
to be (in most cases)
to have (when it means "to possess")*
             */

        private void ProcessUsualWords(List<string> totalNamesList)
        {
            ProcessAllPronouns();
            ProcessAllPrepositions();
            ProcessAllConjunctions();
            ProcessAllInterjections();
            ProcessAllArticles();
            ProcessAllNumerals();

            foreach (var rootName in totalNamesList)
            {
                ProcessRootWordName(rootName);
            }
        }

        private WordFrame GetWordFrame(string word)
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

        private void AddGrammaticalWordFrame(string word, BaseGrammaticalWordFrame grammaticalWordFrame)
        {
            if(string.IsNullOrWhiteSpace(word))
            {
                throw new ArgumentNullException(nameof(word));
            }

            if(grammaticalWordFrame == null)
            {
                throw new ArgumentNullException(nameof(grammaticalWordFrame));
            }

            var wordFrame = GetWordFrame(word);
            wordFrame.GrammaticalWordFrames.Add(grammaticalWordFrame);
        }

        private void ProcessRootWordName(string rootWord)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessRootWordName rootWord = {rootWord}");
#endif

            var rez = Regex.Match(rootWord, @"\(\w+\)");
            var rezStr = rez.ToString();

            if (!string.IsNullOrWhiteSpace(rezStr))
            {
                rootWord = rootWord.Replace(rezStr, string.Empty);
            }

            if (mRootNounDict.ContainsKey(rootWord))
            {
                ProcessNoun(rootWord);
            }

            if (mRootVerbsDict.ContainsKey(rootWord))
            {
                ProcessVerb(rootWord);
            }

            if (mRootAdjsDict.ContainsKey(rootWord))
            {
                ProcessAdj(rootWord);
            }

            if (mRootAdvsDict.ContainsKey(rootWord))
            {
                ProcessAdv(rootWord);
            }
        }

        private bool IsNumeral(string word)
        {
            if(mWordsDictData.WordsDict.ContainsKey(word))
            {
                return mWordsDictData.WordsDict[word].GrammaticalWordFrames.Any(p => p.IsNumeral);
            }

            return false;
        }

        private void ProcessNoun(string rootWord)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessNoun rootWord = {rootWord}");
#endif

            if(IsNumeral(rootWord))
            {
#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info("ProcessNoun IsNumeral(rootWord) return; !!!!!");
#endif
                return;
            }

            List<string> logicalMeaning = null;

            if(mNounClassesDict.ContainsKey(rootWord))
            {
                logicalMeaning = mNounClassesDict[rootWord];
            }
            else
            {
                logicalMeaning = new List<string>();
            }

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessNoun logicalMeaning.Count = {logicalMeaning.Count}");

            foreach (var className in logicalMeaning)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessNoun className = {className}");
            }
#endif

            var isCountable = logicalMeaning.Contains("object") || logicalMeaning.Contains("causal_agent");

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessNoun isCountable = {isCountable}");
#endif

            mTotalCount++;

            AddGrammaticalWordFrame(rootWord, new NounGrammaticalWordFrame()
            {
                Number = GrammaticalNumberOfWord.Singular,
                IsCountable = isCountable,
                LogicalMeaning = logicalMeaning.ToList()
            });

            var possesiveSingular = mNounAntiStemmer.GetPossesiveForSingular(rootWord);

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessNoun possesiveSingular = {possesiveSingular}");
#endif

            AddGrammaticalWordFrame(possesiveSingular, new NounGrammaticalWordFrame()
            {
                RootWord = rootWord,
                Number = GrammaticalNumberOfWord.Singular,
                IsCountable = isCountable,
                LogicalMeaning = logicalMeaning.ToList(),
                IsPossessive = true
            });

            var multipleForms = mNounAntiStemmer.GetPluralForm(rootWord);

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessNoun multipleForms = {multipleForms}");
#endif
            AddGrammaticalWordFrame(multipleForms, new NounGrammaticalWordFrame()
            {
                RootWord = rootWord,
                Number = GrammaticalNumberOfWord.Plural,
                IsCountable = isCountable,
                LogicalMeaning = logicalMeaning.ToList()
            });

            mTotalCount++;

            var possesivePlural = mNounAntiStemmer.GetPossesiveForPlural(multipleForms);

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessNoun possesivePlural = {possesivePlural}");
#endif

            AddGrammaticalWordFrame(possesivePlural, new NounGrammaticalWordFrame()
            {
                RootWord = rootWord,
                Number = GrammaticalNumberOfWord.Plural,
                IsCountable = isCountable,
                LogicalMeaning = logicalMeaning.ToList(),
                IsPossessive = true
            });
        }

        private void ProcessVerb(string rootWord)
        {
            if (rootWord == "be")
            {
                ProcessBe(rootWord);
                return;
            }

            if(rootWord == "can")
            {
                ProcessCan(rootWord);
                return;
            }

            if (rootWord == "could")
            {
                ProcessCould(rootWord);
                return;
            }

            if (rootWord == "may")
            {
                ProcessMay(rootWord);
                return;
            }

            if (rootWord == "must")
            {
                ProcessMust(rootWord);
                return;
            }

            if (rootWord == "would")
            {
                ProcessWould(rootWord);
                return;
            }

            if (rootWord == "should")
            {
                ProcessShould(rootWord);
                return;
            }

            if(rootWord == "shell")
            {
                ProcessShell(rootWord);
                return;
            }
            
            if (rootWord == "will")
            {
                ProcessWill(rootWord);
                return;
            }

            if (rootWord == "have")
            {
                ProcessHave(rootWord);
                return;
            }

            if(rootWord == "do")
            {
                ProcessDo(rootWord);
                return;
            }

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessVerb rootWord = {rootWord}");
#endif
            mTotalCount++;

            var mayHaveGerundOrInfinitiveAfterSelf = mMayHaveGerundOrInfinitiveAfterSelfSource.ContainsWord(rootWord);
            var rootLogicalMeaningsList = mVerbLogicalMeaningsSource.GetLogicalMeanings(rootWord);

            AddGrammaticalWordFrame(rootWord, new VerbGrammaticalWordFrame()
            {
                LogicalMeaning = rootLogicalMeaningsList.ToList(),
                MayHaveGerundOrInfinitiveAfterSelf = mayHaveGerundOrInfinitiveAfterSelf
            });

            var pastFormsList = mVerbAntiStemmer.GetPastForms(rootWord);

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessVerb pastFormsList = {string.Join(',', pastFormsList)}");

            foreach(var pastForm in pastFormsList)
            {
                AddGrammaticalWordFrame(pastForm, new VerbGrammaticalWordFrame()
                {
                    Tense = GrammaticalTenses.Past,
                    VerbType = VerbType.Form_2,
                    RootWord = rootWord,
                    LogicalMeaning = rootLogicalMeaningsList.ToList(),
                    MayHaveGerundOrInfinitiveAfterSelf = mayHaveGerundOrInfinitiveAfterSelf
                });
            }

            var particleFormsList = mVerbAntiStemmer.GetParticleForms(rootWord);

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessVerb particleFormsList = {string.Join(',', particleFormsList)}");

            foreach(var particleForm in pastFormsList)
            {
                AddGrammaticalWordFrame(particleForm, new VerbGrammaticalWordFrame()
                {
                    VerbType = VerbType.Form_3,
                    RootWord = rootWord,
                    LogicalMeaning = rootLogicalMeaningsList.ToList(),
                    MayHaveGerundOrInfinitiveAfterSelf = mayHaveGerundOrInfinitiveAfterSelf
                });
            }

            mTotalCount += particleFormsList.Count;

            var ingForm = mVerbAntiStemmer.GetIngForm(rootWord);

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessVerb ingForm = {ingForm}");

            mTotalCount++;

            AddGrammaticalWordFrame(ingForm, new NounGrammaticalWordFrame()
            {
                Number = GrammaticalNumberOfWord.Singular,
                IsGerund = true,
                RootWord = rootWord,
                LogicalMeaning = rootLogicalMeaningsList.ToList()
            });

            var presentThirdPersonForm = mVerbAntiStemmer.GetThirdPersonSingularPresent(rootWord);

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessVerb presentThirdPersonForm = {presentThirdPersonForm}");

            mTotalCount++;

            AddGrammaticalWordFrame(presentThirdPersonForm, new VerbGrammaticalWordFrame()
            {
                Tense = GrammaticalTenses.Present,
                Person = GrammaticalPerson.Third,
                RootWord = rootWord,
                LogicalMeaning = rootLogicalMeaningsList.ToList(),
                MayHaveGerundOrInfinitiveAfterSelf = mayHaveGerundOrInfinitiveAfterSelf
            });
        }

        private void ProcessBe(string rootWord)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessBe");
#endif

            AddGrammaticalWordFrame(rootWord, new VerbGrammaticalWordFrame()
            {
                IsFormOfToBe = true
            });

            var word = "been";

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
        }

        private void ProcessCan(string rootWord)
        {
            AddGrammaticalWordFrame(rootWord, new VerbGrammaticalWordFrame()
            {
                Tense = GrammaticalTenses.Present,
                IsModal = true
            });
        }

        private void ProcessCould(string rootWord)
        {
            AddGrammaticalWordFrame(rootWord, new VerbGrammaticalWordFrame()
            {
                Tense = GrammaticalTenses.Past,
                IsModal = true
            });
        }

        private void ProcessMay(string rootWord)
        {
            AddGrammaticalWordFrame(rootWord, new VerbGrammaticalWordFrame()
            {
                Tense = GrammaticalTenses.Present,
                IsModal = true
            });
        }

        private void ProcessMust(string rootWord)
        {
            AddGrammaticalWordFrame(rootWord, new VerbGrammaticalWordFrame()
            {
                Tense = GrammaticalTenses.Present,
                IsModal = true
            });
        }

        private void ProcessWould(string rootWord)
        {
            AddGrammaticalWordFrame(rootWord, new VerbGrammaticalWordFrame()
            {
                Tense = GrammaticalTenses.Past,
                IsModal = true
            });
        }

        private void ProcessShell(string rootWord)
        {
            AddGrammaticalWordFrame(rootWord, new VerbGrammaticalWordFrame()
            {
                Tense = GrammaticalTenses.Present,
                IsModal = true
            });

            AddGrammaticalWordFrame(rootWord, new VerbGrammaticalWordFrame()
            {
                Tense = GrammaticalTenses.Future,
                IsModal = false
            });
        }

        private void ProcessShould(string rootWord)
        {
            AddGrammaticalWordFrame(rootWord, new VerbGrammaticalWordFrame()
            {
                Tense = GrammaticalTenses.Past,
                IsModal = true
            });
        }

        private void ProcessWill(string rootWord)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessWill");
#endif

            AddGrammaticalWordFrame(rootWord, new VerbGrammaticalWordFrame()
            {
                RootWord = "be",
                IsFormOfToBe = true,
                Tense = GrammaticalTenses.Future
            });
        }

        private void ProcessHave(string rootWord)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessHave");
#endif

            AddGrammaticalWordFrame(rootWord, new VerbGrammaticalWordFrame()
            {
                Tense = GrammaticalTenses.Present,
                IsFormOfToHave = true
            });

            var word = "has";
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

        private void ProcessDo(string rootWord)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessDo");
#endif

            AddGrammaticalWordFrame(rootWord, new VerbGrammaticalWordFrame()
            {
                Tense = GrammaticalTenses.Present,
                IsFormOfToDo = true
            });

            var word = "does";
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

        private void ProcessAdj(string rootWord)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessAdj rootWord = {rootWord}");
#endif
            mTotalCount++;

            var rootLogicalMeaningsList = mAdjLogicalMeaningsSource.GetLogicalMeanings(rootWord);

            AddGrammaticalWordFrame(rootWord, new AdjectiveGrammaticalWordFrame()
            {
                LogicalMeaning = rootLogicalMeaningsList.ToList()
            });

            var comparativeForm = mAdjAntiStemmer.GetComparativeForm(rootWord);

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessAdj comparativeForm = {comparativeForm}");
            mTotalCount++;

            AddGrammaticalWordFrame(comparativeForm, new AdjectiveGrammaticalWordFrame()
            {
                Comparison = GrammaticalComparison.Comparative,
                RootWord = rootWord,
                LogicalMeaning = rootLogicalMeaningsList.ToList()
            });

            var superlativeForm = mAdjAntiStemmer.GetSuperlativeForm(rootWord);

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessAdj superlativeForm = {superlativeForm}");
            mTotalCount++;

            AddGrammaticalWordFrame(superlativeForm, new AdjectiveGrammaticalWordFrame()
            {
                Comparison = GrammaticalComparison.Superlative,
                RootWord = rootWord,
                LogicalMeaning = rootLogicalMeaningsList.ToList()
            });
        }

        private void ProcessAdv(string rootWord)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessAdv rootWord = {rootWord}");
#endif

            if (IsNumeral(rootWord))
            {
#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info("ProcessAdv IsNumeral(rootWord) return; !!!!!");
#endif
                return;
            }

            mTotalCount++;

            var rootLogicalMeaningsList = mAdvLogicalMeaningsSource.GetLogicalMeanings(rootWord);

            AddGrammaticalWordFrame(rootWord, new AdverbGrammaticalWordFrame()
            {
                LogicalMeaning = rootLogicalMeaningsList.ToList()
            });

            var comparativeForm = mAdvAntiStemmer.GetComparativeForm(rootWord);

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessAdv comparativeForm = {comparativeForm}");

            if(!string.IsNullOrWhiteSpace(comparativeForm))
            {
                mTotalCount++;

                AddGrammaticalWordFrame(comparativeForm, new AdverbGrammaticalWordFrame()
                {
                    Comparison = GrammaticalComparison.Comparative,
                    RootWord = rootWord,
                    LogicalMeaning = rootLogicalMeaningsList.ToList()
                });
            }

            var superlativeForm = mAdvAntiStemmer.GetSuperlativeForm(rootWord);

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessAdv superlativeForm = {superlativeForm}");

            if (!string.IsNullOrWhiteSpace(superlativeForm))
            {
                mTotalCount++;

                AddGrammaticalWordFrame(superlativeForm, new AdverbGrammaticalWordFrame()
                {
                    Comparison = GrammaticalComparison.Superlative,
                    RootWord = rootWord,
                    LogicalMeaning = rootLogicalMeaningsList.ToList()
                });
            }
        }
    }
}
