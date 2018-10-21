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
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                TypeOfPronoun = TypeOfPronoun.Personal,
                Case = CaseOfPersonalPronoun.Subject,
                Person = GrammaticalPerson.First,
                Number = GrammaticalNumberOfWord.Singular,
                LogicalMeaning = new List<string>()
                {
                    "object"
                }
            });

            wordName = "me";
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
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
            });

            wordName = "my";
            AddGrammaticalWordFrame(wordName, );
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
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                RootWord = currentRootWord,
                TypeOfPronoun = TypeOfPronoun.Possessive,
                Case = CaseOfPersonalPronoun.Undefined,
                Person = GrammaticalPerson.First,
                Number = GrammaticalNumberOfWord.Singular,
                LogicalMeaning = new List<string>()
            });

            wordName = "myself";
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                RootWord = currentRootWord,
                TypeOfPronoun = TypeOfPronoun.Reflexive,
                Case = CaseOfPersonalPronoun.Undefined,
                Person = GrammaticalPerson.First,
                Number = GrammaticalNumberOfWord.Singular,
                LogicalMeaning = new List<string>()
            });

            wordName = "you";
            currentRootWord = wordName;
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                TypeOfPronoun = TypeOfPronoun.Personal,
                Case = CaseOfPersonalPronoun.Subject,
                Person = GrammaticalPerson.Second,
                Number = GrammaticalNumberOfWord.Neuter,
                LogicalMeaning = new List<string>()
                {
                    "object"
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
                    "object"
                }
            });

            wordName = "your";
            AddGrammaticalWordFrame(wordName, );
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
            AddGrammaticalWordFrame(wordName, );
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
            AddGrammaticalWordFrame(wordName, );
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
            AddGrammaticalWordFrame(wordName, );
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
            AddGrammaticalWordFrame(wordName, );
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
            AddGrammaticalWordFrame(wordName, );
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
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
            {
                RootWord = currentRootWord,
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
                RootWord = currentRootWord,
                TypeOfPronoun = TypeOfPronoun.Reflexive,
                Case = CaseOfPersonalPronoun.Undefined,
                Person = GrammaticalPerson.Third,
                Number = GrammaticalNumberOfWord.Singular,
                Gender = GrammaticalGender.Masculine,
                LogicalMeaning = new List<string>()
            });

            wordName = "she";
            currentRootWord = wordName;
            AddGrammaticalWordFrame(wordName, new PronounGrammaticalWordFrame()
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
            });

            wordName = "her";
            AddGrammaticalWordFrame(wordName, );

            AddGrammaticalWordFrame(wordName, );
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
            AddGrammaticalWordFrame(wordName, );
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
            AddGrammaticalWordFrame(wordName, );
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
            AddGrammaticalWordFrame(wordName, );

            AddGrammaticalWordFrame(wordName, );
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
            AddGrammaticalWordFrame(wordName, );
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
            AddGrammaticalWordFrame(wordName, );
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
            AddGrammaticalWordFrame(wordName, );
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
            AddGrammaticalWordFrame(wordName, );
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
            AddGrammaticalWordFrame(wordName, );
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
            AddGrammaticalWordFrame(wordName, );
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
            AddGrammaticalWordFrame(wordName, );
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
            AddGrammaticalWordFrame(wordName, );
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
            AddGrammaticalWordFrame(wordName, );
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
            AddGrammaticalWordFrame(wordName, );
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
            AddGrammaticalWordFrame(wordName, );
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
            AddGrammaticalWordFrame(wordName, );
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
            AddGrammaticalWordFrame(wordName, );
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
            AddGrammaticalWordFrame(wordName, );
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
            AddGrammaticalWordFrame(wordName, );
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
            AddGrammaticalWordFrame(wordName, );
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
            AddGrammaticalWordFrame(wordName, );
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
            AddGrammaticalWordFrame(wordName, );
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
            AddGrammaticalWordFrame(wordName, );
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
            AddGrammaticalWordFrame(wordName, );
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
            AddGrammaticalWordFrame(wordName, );
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
            AddGrammaticalWordFrame(wordName, );
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

            AddGrammaticalWordFrame(wordName, );
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
            AddGrammaticalWordFrame(wordName, );
            wordFrame.GrammaticalWordFrames.Add(new PronounGrammaticalWordFrame()
            {
                TypeOfPronoun = TypeOfPronoun.Demonstrative,
                IsQuestionWord = true,
                LogicalMeaning = new List<string>()
                {
                    "place"
                }
            });

            AddGrammaticalWordFrame(wordName, );
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
            AddGrammaticalWordFrame(wordName, );
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
            AddGrammaticalWordFrame(wordName, );
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
            AddGrammaticalWordFrame(wordName, );
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
            AddGrammaticalWordFrame(wordName, );
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
            AddGrammaticalWordFrame(wordName, );
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
            AddGrammaticalWordFrame(wordName, );
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
            AddGrammaticalWordFrame(wordName, );
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
            AddGrammaticalWordFrame(wordName, );
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
            AddGrammaticalWordFrame(wordName, );
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
            AddGrammaticalWordFrame(wordName, );
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
            AddGrammaticalWordFrame(wordName, );
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
            AddGrammaticalWordFrame(wordName, );
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
