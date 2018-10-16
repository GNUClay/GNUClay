using MyNPCLib.SimpleWordsDict;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DictionaryGenerator
{
    public class WordsFactory
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
        }

        private RootNounsWordNetSource mRootNounsSource;
        private RootVerbsWordNetSource mRootVerbsSource;
        private RootAdjWordNetSource mRootAdjSource;
        private RootAdvWordNetSource mRootAdvSource;

        private NounAntiStemmer mNounAntiStemmer;
        private VerbAntiStemmer mVerbAntiStemmer;
        private AdjAntiStemmer mAdjAntiStemmer;
        private AdvAntiStemmer mAdvAntiStemmer;

        private Dictionary<string, List<RootNounSourceWordItem>> mRootNounDict;
        private Dictionary<string, List<RootVerbSourceWordItem>> mRootVerbsDict;
        private Dictionary<string, List<RootAdjSourceWordItem>> mRootAdjsDict;
        private Dictionary<string, List<RootAdvSourceWordItem>> mRootAdvsDict;

        private Dictionary<string, List<string>> mNounClassesDict;

        private int mTotalCount;

        private WordsDictData mWordsDictData;

        public void Run()
        {
            var totalNamesList = new List<string>();

            var rootNounsList = mRootNounsSource.ReadAll();

            var rootNounClassesFactory = new RootNounClassesFactory(rootNounsList);
            mNounClassesDict = rootNounClassesFactory.Result;

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Run rootNounsList.Count = {rootNounsList.Count}");
#endif
            var namesList = mRootNounsSource.ReadNormalWords(rootNounsList).Select(p => p.Word).Distinct().OrderBy(p => p).ToList();

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Run namesList.Count = {namesList.Count}");
#endif
            totalNamesList.AddRange(namesList);

            mRootNounDict = rootNounsList.GroupBy(p => p.Word).ToDictionary(p => p.Key, p => p.ToList());

            var rootVerbsList = mRootVerbsSource.ReadAll();

            namesList = mRootVerbsSource.ReadNormalWords(rootVerbsList).Select(p => p.Word).Distinct().OrderBy(p => p).ToList();

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Run namesList.Count = {namesList.Count}");
#endif
            totalNamesList.AddRange(namesList);

            mRootVerbsDict = rootVerbsList.GroupBy(p => p.Word).ToDictionary(p => p.Key, p => p.ToList());

            var rootAdjsList = mRootAdjSource.ReadAll();

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Run rootAdjsList.Count = {rootAdjsList.Count}");
#endif
            namesList = mRootAdjSource.ReadNormalWords(rootAdjsList).Select(p => p.Word).Distinct().OrderBy(p => p).ToList();

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Run namesList.Count = {namesList.Count}");
#endif
            totalNamesList.AddRange(namesList);

            mRootAdjsDict = rootAdjsList.GroupBy(p => p.Word).ToDictionary(p => p.Key, p => p.ToList());

            var rootAdvsList = mRootAdvSource.ReadAll();

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Run rootAdvsList.Count = {rootAdvsList.Count}");
#endif
            namesList = mRootAdvSource.ReadNormalWords(rootAdvsList).Select(p => p.Word).Distinct().OrderBy(p => p).ToList();

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Run namesList.Count = {namesList.Count}");
#endif
            totalNamesList.AddRange(namesList);

            mRootAdvsDict = rootAdvsList.GroupBy(p => p.Word).ToDictionary(p => p.Key, p => p.ToList());

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Run totalNamesList.Count = {totalNamesList.Count}");
#endif
            totalNamesList = totalNamesList.Distinct().OrderBy(p => p).ToList();

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Run totalNamesList.Count (2) = {totalNamesList.Count}");
#endif

            mWordsDictData = new WordsDictData();
            mWordsDictData.WordsDict = new Dictionary<string, WordFrame>();

            foreach (var rootName in totalNamesList)
            {
                ProcessRootWordName(rootName);
            }

            ProcessAllPronouns();
            ProcessAllPrepositions();
            ProcessAllConjunctions();
            ProcessAllInterjections();
            ProcessAllArticles();
            ProcessAllNumerals();

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Run mTotalCount = {mTotalCount}");
            NLog.LogManager.GetCurrentClassLogger().Info($"Run mWordsDictData = {mWordsDictData}");       
#endif
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

            var rootWordFrame = new WordFrame();
            mWordsDictData.WordsDict[rootWord] = rootWordFrame;
            rootWordFrame.Word = rootWord;
            rootWordFrame.GrammaticalWordFrames = new List<BaseGrammaticalWordFrame>();

            if (mRootNounDict.ContainsKey(rootWord))
            {
                ProcessNoun(rootWord, rootWordFrame);
            }

            if (mRootVerbsDict.ContainsKey(rootWord))
            {
                ProcessVerb(rootWord, rootWordFrame);
            }

            if (mRootAdjsDict.ContainsKey(rootWord))
            {
                ProcessAdj(rootWord, rootWordFrame);
            }

            if (mRootAdvsDict.ContainsKey(rootWord))
            {
                ProcessAdv(rootWord, rootWordFrame);
            }
        }

        private void ProcessNoun(string rootWord, WordFrame rootWordFrame)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessNoun rootWord = {rootWord}");
#endif

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

            var isCountable = logicalMeaning.Contains("logicalMeaning") || logicalMeaning.Contains("causal_agent");

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessNoun isCountable = {isCountable}");
#endif

            mTotalCount++;

            var rootGrammaticalWordFrame = new NounGrammaticalWordFrame()
            {
                Number = GrammaticalNumberOfWord.Singular,
                IsCountable = isCountable,
                LogicalMeaning = logicalMeaning.ToList()
            };

            rootWordFrame.GrammaticalWordFrames.Add(rootGrammaticalWordFrame);

            var multipleForms = mNounAntiStemmer.GetMultipleForm(rootWord);

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessNoun multipleForms = {multipleForms}");

            var wordFrame = GetWordFrame(multipleForms);

            var secondGrammaticalWordFrame = new NounGrammaticalWordFrame()
            {
                RootWord = rootWord,
                Number = GrammaticalNumberOfWord.Plural,
                IsCountable = isCountable,
                LogicalMeaning = logicalMeaning.ToList()
            };

            wordFrame.GrammaticalWordFrames.Add(secondGrammaticalWordFrame);

            mTotalCount++;
        }

        private void ProcessVerb(string rootWord, WordFrame rootWordFrame)
        {
            if (rootWord == "be")
            {
                ProcessBe(rootWordFrame);
                return;
            }

            if(rootWord == "can")
            {
                ProcessCan(rootWordFrame);
                return;
            }

            if (rootWord == "could")
            {
                ProcessCould(rootWordFrame);
                return;
            }

            if (rootWord == "may")
            {
                ProcessMay(rootWordFrame);
                return;
            }

            if (rootWord == "must")
            {
                ProcessMust(rootWordFrame);
                return;
            }

            if (rootWord == "would")
            {
                ProcessWould(rootWordFrame);
                return;
            }

            if (rootWord == "should")
            {
                ProcessShould(rootWordFrame);
                return;
            }

            if(rootWord == "shell")
            {
                ProcessShell(rootWordFrame);
                return;
            }
            
            if (rootWord == "will")
            {
                ProcessWill(rootWordFrame);
                return;
            }

            if (rootWord == "have")
            {
                ProcessHave(rootWordFrame);
                return;
            }

            if(rootWord == "do")
            {
                ProcessDo(rootWordFrame);
                return;
            }

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessVerb rootWord = {rootWord}");
#endif
            mTotalCount++;

            var rootGrammaticalWordFrame = new VerbGrammaticalWordFrame()
            {
                LogicalMeaning = new List<string>()
            };

            rootWordFrame.GrammaticalWordFrames.Add(rootGrammaticalWordFrame);

            var pastFormsList = mVerbAntiStemmer.GetPastForms(rootWord);

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessVerb pastFormsList = {string.Join(',', pastFormsList)}");

            foreach(var pastForm in pastFormsList)
            {
                var wordFrame = GetWordFrame(pastForm);
                var secondGrammaticalWordFrame = new VerbGrammaticalWordFrame();
                secondGrammaticalWordFrame.Tense = GrammaticalTenses.Past;
                secondGrammaticalWordFrame.VerbType = VerbType.Form_2;
                secondGrammaticalWordFrame.RootWord = rootWord;
                wordFrame.GrammaticalWordFrames.Add(secondGrammaticalWordFrame);
            }

            var particleFormsList = mVerbAntiStemmer.GetParticleForms(rootWord);

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessVerb particleFormsList = {string.Join(',', particleFormsList)}");

            foreach(var particleForm in pastFormsList)
            {
                var wordFrame = GetWordFrame(particleForm);
                var secondGrammaticalWordFrame = new VerbGrammaticalWordFrame();
                secondGrammaticalWordFrame.VerbType = VerbType.Form_3;
                secondGrammaticalWordFrame.RootWord = rootWord;
                wordFrame.GrammaticalWordFrames.Add(secondGrammaticalWordFrame);
            }

            mTotalCount += particleFormsList.Count;

            var ingForm = mVerbAntiStemmer.GetIngForm(rootWord);

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessVerb ingForm = {ingForm}");

            mTotalCount++;

            {
                var wordFrame = GetWordFrame(ingForm);
                var secondGrammaticalWordFrame = new NounGrammaticalWordFrame();
                secondGrammaticalWordFrame.Number = GrammaticalNumberOfWord.Singular;
                secondGrammaticalWordFrame.IsGerund = true;
                secondGrammaticalWordFrame.RootWord = rootWord;
                wordFrame.GrammaticalWordFrames.Add(secondGrammaticalWordFrame);
            }

            var presentThirdPersonForm = mVerbAntiStemmer.GetThirdPersonSingularPresent(rootWord);

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessVerb presentThirdPersonForm = {presentThirdPersonForm}");

            mTotalCount++;

            {
                var wordFrame = GetWordFrame(presentThirdPersonForm);
                var secondGrammaticalWordFrame = new VerbGrammaticalWordFrame();
                secondGrammaticalWordFrame.Tense = GrammaticalTenses.Present;
                secondGrammaticalWordFrame.Person = GrammaticalPerson.Third;
                secondGrammaticalWordFrame.RootWord = rootWord;
                wordFrame.GrammaticalWordFrames.Add(secondGrammaticalWordFrame);
            }
        }

        private void ProcessBe(WordFrame rootWordFrame)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessBe");
#endif

            var rootGrammaticalWordFrame = new VerbGrammaticalWordFrame()
            {
                IsFormOfToBe = true
            };

            rootWordFrame.GrammaticalWordFrames.Add(rootGrammaticalWordFrame);

            var rootWord = "be";

            var word = "been";
            var wordFrame = GetWordFrame(word);

            var secondGrammaticalWordFrame = new VerbGrammaticalWordFrame()
            {
                IsFormOfToBe = true,
                VerbType = VerbType.Form_3
            };
            secondGrammaticalWordFrame.RootWord = rootWord;
            wordFrame.GrammaticalWordFrames.Add(secondGrammaticalWordFrame);

            word = "am";

            wordFrame = GetWordFrame(word);
            secondGrammaticalWordFrame = new VerbGrammaticalWordFrame()
            {
                IsFormOfToBe = true,
                Tense = GrammaticalTenses.Present,
                Number = GrammaticalNumberOfWord.Singular,
                Person = GrammaticalPerson.First
            };
            secondGrammaticalWordFrame.RootWord = rootWord;
            wordFrame.GrammaticalWordFrames.Add(secondGrammaticalWordFrame);

            word = "is";
            wordFrame = GetWordFrame(word);
            secondGrammaticalWordFrame = new VerbGrammaticalWordFrame()
            {
                IsFormOfToBe = true,
                Tense = GrammaticalTenses.Present,
                Number = GrammaticalNumberOfWord.Singular,
                Person = GrammaticalPerson.Second
            };
            secondGrammaticalWordFrame.RootWord = rootWord;
            wordFrame.GrammaticalWordFrames.Add(secondGrammaticalWordFrame);

            word = "are";
            wordFrame = GetWordFrame(word);
            secondGrammaticalWordFrame = new VerbGrammaticalWordFrame()
            {
                IsFormOfToBe = true,
                Tense = GrammaticalTenses.Present,
                Number = GrammaticalNumberOfWord.Plural,
                Person = GrammaticalPerson.Third
            };
            secondGrammaticalWordFrame.RootWord = rootWord;
            wordFrame.GrammaticalWordFrames.Add(secondGrammaticalWordFrame);

            word = "was";
            wordFrame = GetWordFrame(word);
            secondGrammaticalWordFrame = new VerbGrammaticalWordFrame()
            {
                IsFormOfToBe = true,
                Tense = GrammaticalTenses.Past,
                Number = GrammaticalNumberOfWord.Singular
            };
            secondGrammaticalWordFrame.RootWord = rootWord;
            wordFrame.GrammaticalWordFrames.Add(secondGrammaticalWordFrame);

            word = "were";
            wordFrame = GetWordFrame(word);
            secondGrammaticalWordFrame = new VerbGrammaticalWordFrame()
            {
                IsFormOfToBe = true,
                Tense = GrammaticalTenses.Past,
                Number = GrammaticalNumberOfWord.Plural
            };
            secondGrammaticalWordFrame.RootWord = rootWord;
            wordFrame.GrammaticalWordFrames.Add(secondGrammaticalWordFrame);

            word = "being";

            wordFrame = GetWordFrame(word);
            var secondGrammaticalWordFrame_1 = new NounGrammaticalWordFrame();
            secondGrammaticalWordFrame_1.Number = GrammaticalNumberOfWord.Singular;
            secondGrammaticalWordFrame_1.IsGerund = true;
            secondGrammaticalWordFrame_1.RootWord = rootWord;
            wordFrame.GrammaticalWordFrames.Add(secondGrammaticalWordFrame_1);
        }

        private void ProcessCan(WordFrame rootWordFrame)
        {
            var rootGrammaticalWordFrame = new VerbGrammaticalWordFrame()
            {
                Tense = GrammaticalTenses.Present,
                IsModal = true
            };

            rootWordFrame.GrammaticalWordFrames.Add(rootGrammaticalWordFrame);
        }

        private void ProcessCould(WordFrame rootWordFrame)
        {
            var rootGrammaticalWordFrame = new VerbGrammaticalWordFrame()
            {
                Tense = GrammaticalTenses.Past,
                IsModal = true
            };

            rootWordFrame.GrammaticalWordFrames.Add(rootGrammaticalWordFrame);
        }

        private void ProcessMay(WordFrame rootWordFrame)
        {
            var rootGrammaticalWordFrame = new VerbGrammaticalWordFrame()
            {
                Tense = GrammaticalTenses.Present,
                IsModal = true
            };

            rootWordFrame.GrammaticalWordFrames.Add(rootGrammaticalWordFrame);
        }

        private void ProcessMust(WordFrame rootWordFrame)
        {
            var rootGrammaticalWordFrame = new VerbGrammaticalWordFrame()
            {
                Tense = GrammaticalTenses.Present,
                IsModal = true
            };

            rootWordFrame.GrammaticalWordFrames.Add(rootGrammaticalWordFrame);
        }

        private void ProcessWould(WordFrame rootWordFrame)
        {
            var rootGrammaticalWordFrame = new VerbGrammaticalWordFrame()
            {
                Tense = GrammaticalTenses.Past,
                IsModal = true
            };

            rootWordFrame.GrammaticalWordFrames.Add(rootGrammaticalWordFrame);
        }

        private void ProcessShell(WordFrame rootWordFrame)
        {
            var rootGrammaticalWordFrame = new VerbGrammaticalWordFrame()
            {
                Tense = GrammaticalTenses.Present,
                IsModal = true
            };

            rootWordFrame.GrammaticalWordFrames.Add(rootGrammaticalWordFrame);
        }

        private void ProcessShould(WordFrame rootWordFrame)
        {
            var rootGrammaticalWordFrame = new VerbGrammaticalWordFrame()
            {
                Tense = GrammaticalTenses.Past,
                IsModal = true
            };

            rootWordFrame.GrammaticalWordFrames.Add(rootGrammaticalWordFrame);
        }

        private void ProcessWill(WordFrame rootWordFrame)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessWill");
#endif

            var rootGrammaticalWordFrame = new VerbGrammaticalWordFrame()
            {
                RootWord = "be",
                IsFormOfToBe = true,
                Tense = GrammaticalTenses.Future
            };

            rootWordFrame.GrammaticalWordFrames.Add(rootGrammaticalWordFrame);
        }

        private void ProcessHave(WordFrame rootWordFrame)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessHave");
#endif

            var rootGrammaticalWordFrame = new VerbGrammaticalWordFrame()
            {
                IsFormOfToHave = true
            };

            rootWordFrame.GrammaticalWordFrames.Add(rootGrammaticalWordFrame);

            var rootWord = "have";
            var word = "has";

            var wordFrame = GetWordFrame(word);
            var secondGrammaticalWordFrame = new VerbGrammaticalWordFrame()
            {
                IsFormOfToHave = true,
                Tense = GrammaticalTenses.Present,
                Person = GrammaticalPerson.Third
            };
            secondGrammaticalWordFrame.RootWord = rootWord;
            wordFrame.GrammaticalWordFrames.Add(secondGrammaticalWordFrame);

            word = "had";

            wordFrame = GetWordFrame(word);
            secondGrammaticalWordFrame = new VerbGrammaticalWordFrame()
            {
                IsFormOfToHave = true,
                Tense = GrammaticalTenses.Past,
                VerbType = VerbType.Form_2             
            };

            secondGrammaticalWordFrame.RootWord = rootWord;
            wordFrame.GrammaticalWordFrames.Add(secondGrammaticalWordFrame);

            secondGrammaticalWordFrame = new VerbGrammaticalWordFrame()
            {
                IsFormOfToHave = true,
                VerbType = VerbType.Form_3
            };
            secondGrammaticalWordFrame.RootWord = rootWord;
            wordFrame.GrammaticalWordFrames.Add(secondGrammaticalWordFrame);

            word = "having";

            wordFrame = GetWordFrame(word);
            var secondGrammaticalWordFrame_1 = new NounGrammaticalWordFrame();
            secondGrammaticalWordFrame_1.Number = GrammaticalNumberOfWord.Singular;
            secondGrammaticalWordFrame_1.IsGerund = true;
            secondGrammaticalWordFrame_1.RootWord = rootWord;
            wordFrame.GrammaticalWordFrames.Add(secondGrammaticalWordFrame_1);
        }

        private void ProcessDo(WordFrame rootWordFrame)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessDo");
#endif

            var rootGrammaticalWordFrame = new VerbGrammaticalWordFrame()
            {
                IsFormOfToDo = true
            };

            var rootWord = "do";
            var word = "does";

            var wordFrame = GetWordFrame(word);
            var secondGrammaticalWordFrame = new VerbGrammaticalWordFrame()
            {
                IsFormOfToDo = true,
                Tense = GrammaticalTenses.Present,
                Person = GrammaticalPerson.Third
            };
            secondGrammaticalWordFrame.RootWord = rootWord;
            wordFrame.GrammaticalWordFrames.Add(secondGrammaticalWordFrame);

            word = "did";
            wordFrame = GetWordFrame(word);

            secondGrammaticalWordFrame = new VerbGrammaticalWordFrame()
            {
                IsFormOfToDo = true,
                Tense = GrammaticalTenses.Past,
                VerbType = VerbType.Form_2
            };

            secondGrammaticalWordFrame.RootWord = rootWord;
            wordFrame.GrammaticalWordFrames.Add(secondGrammaticalWordFrame);

            word = "done";
            wordFrame = GetWordFrame(word);

            secondGrammaticalWordFrame = new VerbGrammaticalWordFrame()
            {
                IsFormOfToDo = true,
                VerbType = VerbType.Form_3
            };
            secondGrammaticalWordFrame.RootWord = rootWord;
            wordFrame.GrammaticalWordFrames.Add(secondGrammaticalWordFrame);

            word = "doing";

            wordFrame = GetWordFrame(word);
            var secondGrammaticalWordFrame_1 = new NounGrammaticalWordFrame();
            secondGrammaticalWordFrame_1.Number = GrammaticalNumberOfWord.Singular;
            secondGrammaticalWordFrame_1.IsGerund = true;
            secondGrammaticalWordFrame_1.RootWord = rootWord;
            wordFrame.GrammaticalWordFrames.Add(secondGrammaticalWordFrame_1);
        }

        private void ProcessAdj(string rootWord, WordFrame rootWordFrame)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessAdj rootWord = {rootWord}");
#endif
            mTotalCount++;

            var rootGrammaticalWordFrame = new AdjectiveGrammaticalWordFrame();

            rootWordFrame.GrammaticalWordFrames.Add(rootGrammaticalWordFrame);

            var comparativeForm = mAdjAntiStemmer.GetComparativeForm(rootWord);

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessAdj comparativeForm = {comparativeForm}");
            mTotalCount++;

            var wordFrame = GetWordFrame(comparativeForm);
            var secondGrammaticalWordFrame = new AdjectiveGrammaticalWordFrame();
            secondGrammaticalWordFrame.Comparison = GrammaticalComparison.Comparative;
            secondGrammaticalWordFrame.RootWord = rootWord;
            wordFrame.GrammaticalWordFrames.Add(secondGrammaticalWordFrame);

            var superlativeForm = mAdjAntiStemmer.GetSuperlativeForm(rootWord);

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessAdj superlativeForm = {superlativeForm}");
            mTotalCount++;

            wordFrame = GetWordFrame(superlativeForm);
            secondGrammaticalWordFrame = new AdjectiveGrammaticalWordFrame();
            secondGrammaticalWordFrame.Comparison = GrammaticalComparison.Superlative;
            secondGrammaticalWordFrame.RootWord = rootWord;
            wordFrame.GrammaticalWordFrames.Add(secondGrammaticalWordFrame);
        }

        private void ProcessAdv(string rootWord, WordFrame rootWordFrame)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessAdv rootWord = {rootWord}");
#endif
            mTotalCount++;

            var rootGrammaticalWordFrame = new AdverbGrammaticalWordFrame();

            rootWordFrame.GrammaticalWordFrames.Add(rootGrammaticalWordFrame);

            var comparativeForm = mAdvAntiStemmer.GetComparativeForm(rootWord);

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessAdv comparativeForm = {comparativeForm}");

            if(!string.IsNullOrWhiteSpace(comparativeForm))
            {
                mTotalCount++;

                var wordFrame = GetWordFrame(comparativeForm);
                var secondGrammaticalWordFrame = new AdverbGrammaticalWordFrame();
                secondGrammaticalWordFrame.Comparison = GrammaticalComparison.Comparative;
                secondGrammaticalWordFrame.RootWord = rootWord;
                wordFrame.GrammaticalWordFrames.Add(secondGrammaticalWordFrame);
            }

            var superlativeForm = mAdvAntiStemmer.GetSuperlativeForm(rootWord);

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessAdv superlativeForm = {superlativeForm}");

            if (!string.IsNullOrWhiteSpace(superlativeForm))
            {
                mTotalCount++;

                var wordFrame = GetWordFrame(superlativeForm);
                var secondGrammaticalWordFrame = new AdverbGrammaticalWordFrame();
                secondGrammaticalWordFrame.Comparison = GrammaticalComparison.Superlative;
                secondGrammaticalWordFrame.RootWord = rootWord;
                wordFrame.GrammaticalWordFrames.Add(secondGrammaticalWordFrame);
            }
        }

        private void ProcessAllPronouns()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessAllPronouns");
#endif
        }

        private void ProcessAllPrepositions()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessAllPrepositions");
#endif
        }

        private void ProcessAllConjunctions()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessAllConjunctions");
#endif
        }

        private void ProcessAllInterjections()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessAllInterjections");
#endif
        }

        private void ProcessAllArticles()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessAllArticles");
#endif
        }

        private void ProcessAllNumerals()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessAllNumerals");
#endif
        }
    }
}
