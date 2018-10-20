using MyNPCLib.SimpleWordsDict;
using System;
using System.Collections.Generic;
using System.Text;

namespace DictionaryGenerator
{
    public partial class WordsFactory
    {
        private void ProcessAllPronouns()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessAllPronouns");
#endif

            var wordName = "i";
            var currentRootWord = wordName;
            mWordsDictData.WordsDict[wordName] = new WordFrame()
            {
                Word = wordName,
                GrammaticalWordFrames = new List<BaseGrammaticalWordFrame>()
                {
                    new PronounGrammaticalWordFrame()
                    {
                        TypeOfPronoun = TypeOfPronoun.Personal,
                        Case = CaseOfPersonalPronoun.Subject,
                        Person = GrammaticalPerson.First,
                        Number = GrammaticalNumberOfWord.Singular,
                        LogicalMeaning = new List<string>()
                        {
                            "object"
                        }
                    }
                }
            };

            wordName = "me";
            mWordsDictData.WordsDict[wordName] = new WordFrame()
            {
                Word = wordName,
                GrammaticalWordFrames = new List<BaseGrammaticalWordFrame>()
                {
                    new PronounGrammaticalWordFrame()
                    {
                        RootWord = currentRootWord,
                        TypeOfPronoun = TypeOfPronoun.Personal,
                        Case = CaseOfPersonalPronoun.Object,
                        Person = GrammaticalPerson.First,
                        Number = GrammaticalNumberOfWord.Singular,
                        LogicalMeaning = new List<string>()
                        {
                            "object"
                        }
                    }
                }
            };

            wordName = "my";
            mWordsDictData.WordsDict[wordName] = new WordFrame()
            {
                Word = wordName,
                GrammaticalWordFrames = new List<BaseGrammaticalWordFrame>()
                {
                    new ArticleGrammaticalWordFrame()
                    {
                        RootWord = currentRootWord,
                        Kind = KindOfArticle.Definite
                    }
                }
            };

            wordName = "mine";
            mWordsDictData.WordsDict[wordName] = new WordFrame()
            {
                Word = wordName,
                GrammaticalWordFrames = new List<BaseGrammaticalWordFrame>()
                {
                    new PronounGrammaticalWordFrame()
                    {
                        RootWord = currentRootWord,
                        TypeOfPronoun = TypeOfPronoun.Possessive,
                        Case = CaseOfPersonalPronoun.Undefined,
                        Person = GrammaticalPerson.First,
                        Number = GrammaticalNumberOfWord.Singular,
                        LogicalMeaning = new List<string>()
                    }
                }
            };

            wordName = "myself";
            mWordsDictData.WordsDict[wordName] = new WordFrame()
            {
                Word = wordName,
                GrammaticalWordFrames = new List<BaseGrammaticalWordFrame>()
                {
                    new PronounGrammaticalWordFrame()
                    {
                        RootWord = currentRootWord,
                        TypeOfPronoun = TypeOfPronoun.Reflexive,
                        Case = CaseOfPersonalPronoun.Undefined,
                        Person = GrammaticalPerson.First,
                        Number = GrammaticalNumberOfWord.Singular,
                        LogicalMeaning = new List<string>()
                    }
                }
            };

            wordName = "you";
            currentRootWord = wordName;
            mWordsDictData.WordsDict[wordName] = new WordFrame()
            {
                Word = wordName,
                GrammaticalWordFrames = new List<BaseGrammaticalWordFrame>()
                {
                    new PronounGrammaticalWordFrame()
                    {
                        TypeOfPronoun = TypeOfPronoun.Personal,
                        Case = CaseOfPersonalPronoun.Subject,
                        Person = GrammaticalPerson.Second,
                        Number = GrammaticalNumberOfWord.Neuter,
                        LogicalMeaning = new List<string>()
                        {
                            "object"
                        }
                    },
                    new PronounGrammaticalWordFrame()
                    {
                        TypeOfPronoun = TypeOfPronoun.Personal,
                        Case = CaseOfPersonalPronoun.Object,
                        Person = GrammaticalPerson.Second,
                        Number = GrammaticalNumberOfWord.Neuter,
                        LogicalMeaning = new List<string>()
                        {
                            "object"
                        }
                    }
                }
            };

            wordName = "your";
            mWordsDictData.WordsDict[wordName] = new WordFrame()
            {
                Word = wordName,
                GrammaticalWordFrames = new List<BaseGrammaticalWordFrame>()
                {
                    new ArticleGrammaticalWordFrame()
                    {
                        RootWord = currentRootWord,
                        Kind = KindOfArticle.Definite
                    }
                }
            };

            wordName = "yours";
            mWordsDictData.WordsDict[wordName] = new WordFrame()
            {
                Word = wordName,
                GrammaticalWordFrames = new List<BaseGrammaticalWordFrame>()
                {
                    new PronounGrammaticalWordFrame()
                    {
                        RootWord = currentRootWord,
                        TypeOfPronoun = TypeOfPronoun.Possessive,
                        Case = CaseOfPersonalPronoun.Undefined,
                        Person = GrammaticalPerson.Second,
                        Number = GrammaticalNumberOfWord.Neuter,
                        LogicalMeaning = new List<string>()
                    }
                }
            };

            wordName = "yourself";
            mWordsDictData.WordsDict[wordName] = new WordFrame()
            {
                Word = wordName,
                GrammaticalWordFrames = new List<BaseGrammaticalWordFrame>()
                {
                    new PronounGrammaticalWordFrame()
                    {
                        RootWord = currentRootWord,
                        TypeOfPronoun = TypeOfPronoun.Reflexive,
                        Case = CaseOfPersonalPronoun.Undefined,
                        Person = GrammaticalPerson.Second,
                        Number = GrammaticalNumberOfWord.Singular,
                        LogicalMeaning = new List<string>()
                    }
                }
            };

            wordName = "yourselves";
            mWordsDictData.WordsDict[wordName] = new WordFrame()
            {
                Word = wordName,
                GrammaticalWordFrames = new List<BaseGrammaticalWordFrame>()
                {
                    new PronounGrammaticalWordFrame()
                    {
                        RootWord = currentRootWord,
                        TypeOfPronoun = TypeOfPronoun.Reflexive,
                        Case = CaseOfPersonalPronoun.Undefined,
                        Person = GrammaticalPerson.Second,
                        Number = GrammaticalNumberOfWord.Plural,
                        LogicalMeaning = new List<string>()
                    }
                }
            };

            wordName = "he";
            currentRootWord = wordName;
            mWordsDictData.WordsDict[wordName] = new WordFrame()
            {
                Word = wordName,
                GrammaticalWordFrames = new List<BaseGrammaticalWordFrame>()
                {
                    new PronounGrammaticalWordFrame()
                    {
                        TypeOfPronoun = TypeOfPronoun.Personal,
                        Case = CaseOfPersonalPronoun.Subject,
                        Person = GrammaticalPerson.Third,
                        Number = GrammaticalNumberOfWord.Singular,
                        Gender = GrammaticalGender.Masculine,
                        LogicalMeaning = new List<string>()
                        {
                            "object"
                        }
                    }
                }
            };

            wordName = "him";
            mWordsDictData.WordsDict[wordName] = new WordFrame()
            {
                Word = wordName,
                GrammaticalWordFrames = new List<BaseGrammaticalWordFrame>()
                {
                    new PronounGrammaticalWordFrame()
                    {
                        RootWord = currentRootWord,
                        TypeOfPronoun = TypeOfPronoun.Personal,
                        Case = CaseOfPersonalPronoun.Object,
                        Person = GrammaticalPerson.Third,
                        Number = GrammaticalNumberOfWord.Singular,
                        Gender = GrammaticalGender.Masculine,
                        LogicalMeaning = new List<string>()
                        {
                            "object"
                        }
                    }
                }
            };

            wordName = "his";
            mWordsDictData.WordsDict[wordName] = new WordFrame()
            {
                Word = wordName,
                GrammaticalWordFrames = new List<BaseGrammaticalWordFrame>()
                {
                    new PronounGrammaticalWordFrame()
                    {
                        RootWord = currentRootWord,
                        TypeOfPronoun = TypeOfPronoun.Possessive,
                        Case = CaseOfPersonalPronoun.Undefined,
                        Person = GrammaticalPerson.Third,
                        Number = GrammaticalNumberOfWord.Singular,
                        Gender = GrammaticalGender.Masculine,
                        LogicalMeaning = new List<string>()
                    }
                }
            };

            wordName = "himself";
            mWordsDictData.WordsDict[wordName] = new WordFrame()
            {
                Word = wordName,
                GrammaticalWordFrames = new List<BaseGrammaticalWordFrame>()
                {
                    new PronounGrammaticalWordFrame()
                    {
                        RootWord = currentRootWord,
                        TypeOfPronoun = TypeOfPronoun.Reflexive,
                        Case = CaseOfPersonalPronoun.Undefined,
                        Person = GrammaticalPerson.Third,
                        Number = GrammaticalNumberOfWord.Singular,
                        Gender = GrammaticalGender.Masculine,
                        LogicalMeaning = new List<string>()
                    }
                }
            };

            wordName = "she";
            currentRootWord = wordName;
            mWordsDictData.WordsDict[wordName] = new WordFrame()
            {
                Word = wordName,
                GrammaticalWordFrames = new List<BaseGrammaticalWordFrame>()
                {
                    new PronounGrammaticalWordFrame()
                    {
                        TypeOfPronoun = TypeOfPronoun.Personal,
                        Case = CaseOfPersonalPronoun.Subject,
                        Person = GrammaticalPerson.Third,
                        Number = GrammaticalNumberOfWord.Singular,
                        Gender = GrammaticalGender.Feminine,
                        LogicalMeaning = new List<string>()
                        {
                            "object"
                        }
                    }
                }
            };

            wordName = "her";
            mWordsDictData.WordsDict[wordName] = new WordFrame()
            {
                Word = wordName,
                GrammaticalWordFrames = new List<BaseGrammaticalWordFrame>()
                {
                    new PronounGrammaticalWordFrame()
                    {
                        RootWord = currentRootWord,
                        TypeOfPronoun = TypeOfPronoun.Personal,
                        Case = CaseOfPersonalPronoun.Object,
                        Person = GrammaticalPerson.Third,
                        Number = GrammaticalNumberOfWord.Singular,
                        Gender = GrammaticalGender.Feminine,
                        LogicalMeaning = new List<string>()
                        {
                            "object"
                        }
                    },
                    new ArticleGrammaticalWordFrame()
                    {
                        RootWord = currentRootWord,
                        Kind = KindOfArticle.Definite
                    }
                }
            };

            wordName = "hers";
            mWordsDictData.WordsDict[wordName] = new WordFrame()
            {
                Word = wordName,
                GrammaticalWordFrames = new List<BaseGrammaticalWordFrame>()
                {
                    new PronounGrammaticalWordFrame()
                    {
                        RootWord = currentRootWord,
                        TypeOfPronoun = TypeOfPronoun.Possessive,
                        Case = CaseOfPersonalPronoun.Undefined,
                        Person = GrammaticalPerson.Third,
                        Number = GrammaticalNumberOfWord.Singular,
                        Gender = GrammaticalGender.Feminine,
                        LogicalMeaning = new List<string>()
                    }
                }
            };

            wordName = "herself";
            mWordsDictData.WordsDict[wordName] = new WordFrame()
            {
                Word = wordName,
                GrammaticalWordFrames = new List<BaseGrammaticalWordFrame>()
                {
                    new PronounGrammaticalWordFrame()
                    {
                        RootWord = currentRootWord,
                        TypeOfPronoun = TypeOfPronoun.Reflexive,
                        Case = CaseOfPersonalPronoun.Undefined,
                        Person = GrammaticalPerson.Third,
                        Number = GrammaticalNumberOfWord.Singular,
                        Gender = GrammaticalGender.Feminine,
                        LogicalMeaning = new List<string>()
                    }
                }
            };

            wordName = "it";
            currentRootWord = wordName;
            mWordsDictData.WordsDict[wordName] = new WordFrame()
            {
                Word = wordName,
                GrammaticalWordFrames = new List<BaseGrammaticalWordFrame>()
                {
                    new PronounGrammaticalWordFrame()
                    {
                        TypeOfPronoun = TypeOfPronoun.Personal,
                        Case = CaseOfPersonalPronoun.Subject,
                        Person = GrammaticalPerson.Third,
                        Number = GrammaticalNumberOfWord.Singular,
                        LogicalMeaning = new List<string>()
                        {
                            "object"
                        }
                    },
                    new PronounGrammaticalWordFrame()
                    {
                        RootWord = currentRootWord,
                        TypeOfPronoun = TypeOfPronoun.Personal,
                        Case = CaseOfPersonalPronoun.Object,
                        Person = GrammaticalPerson.Third,
                        Number = GrammaticalNumberOfWord.Singular,
                        LogicalMeaning = new List<string>()
                        {
                            "object"
                        }
                    }
                }
            };

            wordName = "its";
            mWordsDictData.WordsDict[wordName] = new WordFrame()
            {
                Word = wordName,
                GrammaticalWordFrames = new List<BaseGrammaticalWordFrame>()
                {
                    new PronounGrammaticalWordFrame()
                    {
                        RootWord = currentRootWord,
                        TypeOfPronoun = TypeOfPronoun.Possessive,
                        Case = CaseOfPersonalPronoun.Undefined,
                        Person = GrammaticalPerson.Third,
                        Number = GrammaticalNumberOfWord.Singular,
                        LogicalMeaning = new List<string>()
                    }
                }
            };

            wordName = "itself";
            mWordsDictData.WordsDict[wordName] = new WordFrame()
            {
                Word = wordName,
                GrammaticalWordFrames = new List<BaseGrammaticalWordFrame>()
                {
                    new PronounGrammaticalWordFrame()
                    {
                        RootWord = currentRootWord,
                        TypeOfPronoun = TypeOfPronoun.Reflexive,
                        Case = CaseOfPersonalPronoun.Undefined,
                        Person = GrammaticalPerson.Third,
                        Number = GrammaticalNumberOfWord.Singular,
                        LogicalMeaning = new List<string>()
                    }
                }
            };

            wordName = "we";
            currentRootWord = wordName;
            mWordsDictData.WordsDict[wordName] = new WordFrame()
            {
                Word = wordName,
                GrammaticalWordFrames = new List<BaseGrammaticalWordFrame>()
                {
                    new PronounGrammaticalWordFrame()
                    {
                        TypeOfPronoun = TypeOfPronoun.Personal,
                        Case = CaseOfPersonalPronoun.Subject,
                        Person = GrammaticalPerson.First,
                        Number = GrammaticalNumberOfWord.Plural,
                        LogicalMeaning = new List<string>()
                        {
                            "object"
                        }
                    }
                }
            };

            wordName = "us";
            mWordsDictData.WordsDict[wordName] = new WordFrame()
            {
                Word = wordName,
                GrammaticalWordFrames = new List<BaseGrammaticalWordFrame>()
                {
                    new PronounGrammaticalWordFrame()
                    {
                        RootWord = currentRootWord,
                        TypeOfPronoun = TypeOfPronoun.Personal,
                        Case = CaseOfPersonalPronoun.Object,
                        Person = GrammaticalPerson.First,
                        Number = GrammaticalNumberOfWord.Plural,
                        LogicalMeaning = new List<string>()
                        {
                            "object"
                        }
                    }
                }
            };

            wordName = "our";
            mWordsDictData.WordsDict[wordName] = new WordFrame()
            {
                Word = wordName,
                GrammaticalWordFrames = new List<BaseGrammaticalWordFrame>()
                {
                    new ArticleGrammaticalWordFrame()
                    {
                        RootWord = currentRootWord,
                        Kind = KindOfArticle.Definite
                    }
                }
            };

            wordName = "ours";
            mWordsDictData.WordsDict[wordName] = new WordFrame()
            {
                Word = wordName,
                GrammaticalWordFrames = new List<BaseGrammaticalWordFrame>()
                {
                    new PronounGrammaticalWordFrame()
                    {
                        RootWord = currentRootWord,
                        TypeOfPronoun = TypeOfPronoun.Possessive,
                        Case = CaseOfPersonalPronoun.Undefined,
                        Person = GrammaticalPerson.First,
                        Number = GrammaticalNumberOfWord.Plural,
                        LogicalMeaning = new List<string>()
                    }
                }
            };

            wordName = "ourselves";
            mWordsDictData.WordsDict[wordName] = new WordFrame()
            {
                Word = wordName,
                GrammaticalWordFrames = new List<BaseGrammaticalWordFrame>()
                {
                    new PronounGrammaticalWordFrame()
                    {
                        RootWord = currentRootWord,
                        TypeOfPronoun = TypeOfPronoun.Reflexive,
                        Case = CaseOfPersonalPronoun.Undefined,
                        Person = GrammaticalPerson.First,
                        Number = GrammaticalNumberOfWord.Plural,
                        LogicalMeaning = new List<string>()
                    }
                }
            };

            wordName = "they";
            currentRootWord = wordName;
            mWordsDictData.WordsDict[wordName] = new WordFrame()
            {
                Word = wordName,
                GrammaticalWordFrames = new List<BaseGrammaticalWordFrame>()
                {
                    new PronounGrammaticalWordFrame()
                    {
                        TypeOfPronoun = TypeOfPronoun.Personal,
                        Case = CaseOfPersonalPronoun.Subject,
                        Person = GrammaticalPerson.Third,
                        LogicalMeaning = new List<string>()
                        {
                            "object"
                        }
                    }
                }
            };

            wordName = "them";
            mWordsDictData.WordsDict[wordName] = new WordFrame()
            {
                Word = wordName,
                GrammaticalWordFrames = new List<BaseGrammaticalWordFrame>()
                {
                    new PronounGrammaticalWordFrame()
                    {
                        RootWord = currentRootWord,
                        TypeOfPronoun = TypeOfPronoun.Personal,
                        Case = CaseOfPersonalPronoun.Object,
                        Person = GrammaticalPerson.Third,
                        LogicalMeaning = new List<string>()
                        {
                            "object"
                        }
                    }
                }
            };

            wordName = "their";
            mWordsDictData.WordsDict[wordName] = new WordFrame()
            {
                Word = wordName,
                GrammaticalWordFrames = new List<BaseGrammaticalWordFrame>()
                {
                    new ArticleGrammaticalWordFrame()
                    {
                        RootWord = currentRootWord,
                        Kind = KindOfArticle.Definite
                    }
                }
            };

            wordName = "theirs";
            mWordsDictData.WordsDict[wordName] = new WordFrame()
            {
                Word = wordName,
                GrammaticalWordFrames = new List<BaseGrammaticalWordFrame>()
                {
                    new PronounGrammaticalWordFrame()
                    {
                        RootWord = currentRootWord,
                        TypeOfPronoun = TypeOfPronoun.Possessive,
                        Case = CaseOfPersonalPronoun.Undefined,
                        Person = GrammaticalPerson.Third,
                        Number = GrammaticalNumberOfWord.Neuter,
                        LogicalMeaning = new List<string>()
                        {
                            "object"
                        }
                    }
                }
            };

            wordName = "themselves";
            mWordsDictData.WordsDict[wordName] = new WordFrame()
            {
                Word = wordName,
                GrammaticalWordFrames = new List<BaseGrammaticalWordFrame>()
                {
                    new PronounGrammaticalWordFrame()
                    {
                        RootWord = currentRootWord,
                        TypeOfPronoun = TypeOfPronoun.Reflexive,
                        Case = CaseOfPersonalPronoun.Undefined,
                        Person = GrammaticalPerson.Third,
                        LogicalMeaning = new List<string>()
                        {
                            "object"
                        }
                    }
                }
            };

            wordName = "this";
            currentRootWord = wordName;
            mWordsDictData.WordsDict[wordName] = new WordFrame()
            {
                Word = wordName,
                GrammaticalWordFrames = new List<BaseGrammaticalWordFrame>()
                {
                    new PronounGrammaticalWordFrame()
                    {
                        TypeOfPronoun = TypeOfPronoun.Demonstrative,
                        Number = GrammaticalNumberOfWord.Singular,
                        LogicalMeaning = new List<string>()
                        {
                            "object",
                            "near_object"
                        }
                    }
                }
            };

            wordName = "these";
            mWordsDictData.WordsDict[wordName] = new WordFrame()
            {
                Word = wordName,
                GrammaticalWordFrames = new List<BaseGrammaticalWordFrame>()
                {
                    new PronounGrammaticalWordFrame()
                    {
                        RootWord = currentRootWord,
                        TypeOfPronoun = TypeOfPronoun.Demonstrative,
                        Number = GrammaticalNumberOfWord.Plural,
                        LogicalMeaning = new List<string>()
                        {
                            "object",
                            "near_object"
                        }
                    }
                }
            };

            wordName = "that";
            currentRootWord = wordName;
            mWordsDictData.WordsDict[wordName] = new WordFrame()
            {
                Word = wordName,
                GrammaticalWordFrames = new List<BaseGrammaticalWordFrame>()
                {
                    new PronounGrammaticalWordFrame()
                    {
                        TypeOfPronoun = TypeOfPronoun.Demonstrative,
                        Number = GrammaticalNumberOfWord.Singular,
                        LogicalMeaning = new List<string>()
                        {
                            "object",
                            "far_object"
                        }
                    }
                }
            };

            wordName = "those";
            mWordsDictData.WordsDict[wordName] = new WordFrame()
            {
                Word = wordName,
                GrammaticalWordFrames = new List<BaseGrammaticalWordFrame>()
                {
                    new PronounGrammaticalWordFrame()
                    {
                        RootWord = currentRootWord,
                        TypeOfPronoun = TypeOfPronoun.Demonstrative,
                        Number = GrammaticalNumberOfWord.Plural,
                        LogicalMeaning = new List<string>()
                        {
                            "object",
                            "far_object"
                        }
                    }
                }
            };

            wordName = "former";
            mWordsDictData.WordsDict[wordName] = new WordFrame()
            {
                Word = wordName,
                GrammaticalWordFrames = new List<BaseGrammaticalWordFrame>()
                {
                    new PronounGrammaticalWordFrame()
                    {
                        TypeOfPronoun = TypeOfPronoun.Demonstrative
                    }
                }
            };

            wordName = "latter";
            mWordsDictData.WordsDict[wordName] = new WordFrame()
            {
                Word = wordName,
                GrammaticalWordFrames = new List<BaseGrammaticalWordFrame>()
                {
                    new PronounGrammaticalWordFrame()
                    {
                        TypeOfPronoun = TypeOfPronoun.Demonstrative
                    }
                }
            };

            wordName = "who";
            mWordsDictData.WordsDict[wordName] = new WordFrame()
            {
                Word = wordName,
                GrammaticalWordFrames = new List<BaseGrammaticalWordFrame>()
                {
                    new PronounGrammaticalWordFrame()
                    {
                        TypeOfPronoun = TypeOfPronoun.Demonstrative,
                        IsQuestionWord = true,
                        LogicalMeaning = new List<string>()
                        {
                            "object"
                        }
                    },
                    new PronounGrammaticalWordFrame()
                    {
                        TypeOfPronoun = TypeOfPronoun.Interrogative,
                        IsQuestionWord = true,
                        LogicalMeaning = new List<string>()
                        {
                            "object"
                        }
                    }
                }
            };

            wordName = "whom";
            mWordsDictData.WordsDict[wordName] = new WordFrame()
            {
                Word = wordName,
                GrammaticalWordFrames = new List<BaseGrammaticalWordFrame>()
                {
                    new PronounGrammaticalWordFrame()
                    {
                        TypeOfPronoun = TypeOfPronoun.Demonstrative,
                        IsQuestionWord = true,
                        LogicalMeaning = new List<string>()
                        {
                            "object",
                            "as_possesive"
                        }
                    },
                    new PronounGrammaticalWordFrame()
                    {
                        TypeOfPronoun = TypeOfPronoun.Interrogative,
                        IsQuestionWord = true,
                        LogicalMeaning = new List<string>()
                        {
                            "object",
                            "as_possesive"
                        }
                    }
                }
            };

            wordName = "which";
            mWordsDictData.WordsDict[wordName] = new WordFrame()
            {
                Word = wordName,
                GrammaticalWordFrames = new List<BaseGrammaticalWordFrame>()
                {
                    new PronounGrammaticalWordFrame()
                    {
                        TypeOfPronoun = TypeOfPronoun.Demonstrative,
                        IsQuestionWord = true,
                        LogicalMeaning = new List<string>()
                        {
                            "object"
                        }
                    },
                    new PronounGrammaticalWordFrame()
                    {
                        TypeOfPronoun = TypeOfPronoun.Interrogative,
                        IsQuestionWord = true,
                        LogicalMeaning = new List<string>()
                        {
                            "object"
                        }
                    }
                }
            };

            wordName = "when";
            var wordFrame = GetWordFrame(wordName);
            wordFrame.GrammaticalWordFrames.Add(new PronounGrammaticalWordFrame()
            {
                TypeOfPronoun = TypeOfPronoun.Demonstrative,
                IsQuestionWord = true,
                LogicalMeaning = new List<string>()
                {
                    "time"
                }
            });

            wordFrame.GrammaticalWordFrames.Add(new PronounGrammaticalWordFrame()
            {
                TypeOfPronoun = TypeOfPronoun.Interrogative,
                IsQuestionWord = true,
                LogicalMeaning = new List<string>()
                {
                    "time"
                }
            });

            wordName = "where";
            wordFrame.GrammaticalWordFrames.Add(new PronounGrammaticalWordFrame()
            {
                TypeOfPronoun = TypeOfPronoun.Demonstrative,
                IsQuestionWord = true,
                LogicalMeaning = new List<string>()
                {
                    "place"
                }
            });

            wordFrame.GrammaticalWordFrames.Add(new PronounGrammaticalWordFrame()
            {
                TypeOfPronoun = TypeOfPronoun.Interrogative,
                IsQuestionWord = true,
                LogicalMeaning = new List<string>()
                {
                    "place"
                }
            });

            wordName = "something";
            mWordsDictData.WordsDict[wordName] = new WordFrame()
            {
                Word = wordName,
                GrammaticalWordFrames = new List<BaseGrammaticalWordFrame>()
                {
                    new PronounGrammaticalWordFrame()
                    {
                        TypeOfPronoun = TypeOfPronoun.Indefinite,
                        LogicalMeaning = new List<string>()
                        {
                            "object",
                            "thing"
                        }
                    }
                }
            };

            wordName = "anything";
            mWordsDictData.WordsDict[wordName] = new WordFrame()
            {
                Word = wordName,
                GrammaticalWordFrames = new List<BaseGrammaticalWordFrame>()
                {
                    new PronounGrammaticalWordFrame()
                    {
                        TypeOfPronoun = TypeOfPronoun.Indefinite,
                        LogicalMeaning = new List<string>()
                        {
                            "object",
                            "thing"
                        }
                    }
                }
            };

            wordName = "nothing";
            mWordsDictData.WordsDict[wordName] = new WordFrame()
            {
                Word = wordName,
                GrammaticalWordFrames = new List<BaseGrammaticalWordFrame>()
                {
                    new PronounGrammaticalWordFrame()
                    {
                        TypeOfPronoun = TypeOfPronoun.Indefinite,
                        IsNegation = true,
                        LogicalMeaning = new List<string>()
                        {
                            "object",
                            "thing"
                        }
                    }
                }
            };

            wordName = "somewhere";
            mWordsDictData.WordsDict[wordName] = new WordFrame()
            {
                Word = wordName,
                GrammaticalWordFrames = new List<BaseGrammaticalWordFrame>()
                {
                    new PronounGrammaticalWordFrame()
                    {
                        TypeOfPronoun = TypeOfPronoun.Indefinite,
                        LogicalMeaning = new List<string>()
                        {
                            "object",
                            "about_place"
                        }
                    }
                }
            };

            wordName = "anywhere";
            mWordsDictData.WordsDict[wordName] = new WordFrame()
            {
                Word = wordName,
                GrammaticalWordFrames = new List<BaseGrammaticalWordFrame>()
                {
                    new PronounGrammaticalWordFrame()
                    {
                        TypeOfPronoun = TypeOfPronoun.Indefinite,
                        LogicalMeaning = new List<string>()
                        {
                            "object",
                            "about_place"
                        }
                    }
                }
            };
            wordName = "nowhere";
            mWordsDictData.WordsDict[wordName] = new WordFrame()
            {
                Word = wordName,
                GrammaticalWordFrames = new List<BaseGrammaticalWordFrame>()
                {
                    new PronounGrammaticalWordFrame()
                    {
                        TypeOfPronoun = TypeOfPronoun.Indefinite,
                        IsNegation = true,
                        LogicalMeaning = new List<string>()
                        {
                            "object",
                            "about_place"
                        }
                    }
                }
            };

            wordName = "someone";
            mWordsDictData.WordsDict[wordName] = new WordFrame()
            {
                Word = wordName,
                GrammaticalWordFrames = new List<BaseGrammaticalWordFrame>()
                {
                    new PronounGrammaticalWordFrame()
                    {
                        TypeOfPronoun = TypeOfPronoun.Indefinite,
                        LogicalMeaning = new List<string>()
                        {
                            "object",
                            "people"
                        }
                    }
                }
            };

            wordName = "anyone";
            mWordsDictData.WordsDict[wordName] = new WordFrame()
            {
                Word = wordName,
                GrammaticalWordFrames = new List<BaseGrammaticalWordFrame>()
                {
                    new PronounGrammaticalWordFrame()
                    {
                        TypeOfPronoun = TypeOfPronoun.Indefinite,
                        LogicalMeaning = new List<string>()
                        {
                            "object",
                            "people"
                        }
                    }
                }
            };

            wordName = "what";
            wordFrame = GetWordFrame(wordName);
            wordFrame.GrammaticalWordFrames.Add(new PronounGrammaticalWordFrame()
            {
                TypeOfPronoun = TypeOfPronoun.Interrogative,
                IsQuestionWord = true,
                LogicalMeaning = new List<string>()
                {
                    "object"
                }
            });

            wordName = "whose";
            wordFrame = GetWordFrame(wordName);
            wordFrame.GrammaticalWordFrames.Add(new PronounGrammaticalWordFrame()
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
            wordFrame = GetWordFrame(wordName);
            wordFrame.GrammaticalWordFrames.Add(new PronounGrammaticalWordFrame()
            {
                TypeOfPronoun = TypeOfPronoun.Interrogative,
                IsQuestionWord = true,
                LogicalMeaning = new List<string>()
                {
                    "reason"
                }
            });

            wordName = "how";
            wordFrame = GetWordFrame(wordName);
            wordFrame.GrammaticalWordFrames.Add(new PronounGrammaticalWordFrame()
            {
                TypeOfPronoun = TypeOfPronoun.Interrogative,
                IsQuestionWord = true,
                LogicalMeaning = new List<string>()
                {
                    "way"
                }
            });
        }
    }
}

/*
https://en.wikipedia.org/wiki/Pronoun

Indefinite:
no_one (people)
*/
