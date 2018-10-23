using MyNPCLib.SimpleWordsDict;
using System;
using System.Collections.Generic;
using System.Text;

namespace DictionaryGenerator
{
    public partial class WordsFactory
    {
        private void ProcessAllNumerals()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessAllNumerals");
#endif
            //0 - 10
            var word = "zero";
            var value = 0f;
            var rootWord = word;

            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame() {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value
            });

            word = "naught";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "nought";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "aught";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord,
                IsArchaic = true
            });

            word = "oh";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "nil";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "nothing";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "null";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            AddGrammaticalWordFrame(word, new NounGrammaticalWordFrame()
            {
            });

            word = "love";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "zilch";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "nada";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "zip";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "nix";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "cypher";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "duck";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "blank";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "zeroth";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "noughth";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "0th";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "noughth";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "one";
            value = 1f;
            rootWord = word;
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value
            });

            word = "solo";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "unit";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "unity";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "once";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord,
                LogicalMeaning = new List<string>()
                {
                    "time"
                }
            });

            word = "solitary";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord,
                LogicalMeaning = new List<string>()
                {
                    "multiplicating"
                }
            });

            word = "singular";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord,
                LogicalMeaning = new List<string>()
                {
                    "multiplicating"
                }
            });

            word = "1st";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "first";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "two";
            value = 2f;
            rootWord = word;
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value
            });

            word = "couple";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "brace";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "pair";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "deuce";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "duo";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "quadratic";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "twice";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord,
                LogicalMeaning = new List<string>()
                {
                    "time"
                }
            });

            word = "double";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord,
                LogicalMeaning = new List<string>()
                {
                    "multiplicating"
                }
            });

            word = "twofold";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord,
                LogicalMeaning = new List<string>()
                {
                    "multiplicating"
                }
            });

            word = "duplicate";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord,
                LogicalMeaning = new List<string>()
                {
                    "multiplicating"
                }
            });

            word = "2nd";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "second";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "three";
            value = 3f;
            rootWord = word;
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value
            });

            word = "trio";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "cubic";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "thrice";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord,
                LogicalMeaning = new List<string>()
                {
                    "time"
                }
            });

            word = "triple";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord,
                LogicalMeaning = new List<string>()
                {
                    "multiplicating"
                }
            });

            word = "threefold";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord,
                LogicalMeaning = new List<string>()
                {
                    "multiplicating"
                }
            });

            word = "triplicate";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord,
                LogicalMeaning = new List<string>()
                {
                    "multiplicating"
                }
            });

            word = "3rd";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "third";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "thirds";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "four";
            value = 4f;
            rootWord = word;
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value
            });

            word = "quartet";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "quad";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "quadruple";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord,
                LogicalMeaning = new List<string>()
                {
                    "time"
                }
            });

            word = "fourfold";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord,
                LogicalMeaning = new List<string>()
                {
                    "multiplicating"
                }
            });

            word = "4th";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "fourth";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "fourths";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "quarter";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "quarters";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "five";
            value = 5f;
            rootWord = word;
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value
            });

            word = "quintet";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "quintic";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "quint";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "quintuple";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord,
                LogicalMeaning = new List<string>()
                {
                    "multiplicating"
                }
            });

            word = "fivefold";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord,
                LogicalMeaning = new List<string>()
                {
                    "multiplicating"
                }
            });

            word = "5th";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "fifth";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "fourths";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "six";
            value = 6f;
            rootWord = word;
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value
            });

            word = "sextet";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "sextic";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "hectic";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "sextuple";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord,
                LogicalMeaning = new List<string>()
                {
                    "multiplicating"
                }
            });

            word = "hextuple";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord,
                LogicalMeaning = new List<string>()
                {
                    "multiplicating"
                }
            });

            word = "sixfold";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord,
                LogicalMeaning = new List<string>()
                {
                    "multiplicating"
                }
            });

            word = "6th";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "sixth";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "sixths";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "seven";
            value = 7f;
            rootWord = word;
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value
            });

            word = "septet";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "septic";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "heptic";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "septuple";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord,
                LogicalMeaning = new List<string>()
                {
                    "multiplicating"
                }
            });

            word = "heptuple";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord,
                LogicalMeaning = new List<string>()
                {
                    "multiplicating"
                }
            });

            word = "sevenfold";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord,
                LogicalMeaning = new List<string>()
                {
                    "multiplicating"
                }
            });

            word = "7th";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "seventh";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "sevenths";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "eight";
            value = 8f;
            rootWord = word;
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value
            });

            word = "octet";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "8th";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "eighth";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "eighths";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "nine";
            value = 9f;
            rootWord = word;
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value
            });

            word = "nonet";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "9th";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "ninth";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "ten";
            value = 10f;
            rootWord = word;
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value
            });

            word = "dime";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "decet";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "10th";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "tenth";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "tenths";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            //11 - 20
            word = "eleven";
            value = 11f;
            rootWord = word;
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value
            });

            word = "11th";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "eleventh";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "elevenths";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "twelve";
            value = 12f;
            rootWord = word;
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value
            });

            word = "dozen";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "12th";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "twelfth";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "twelfths";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "thirteen";
            value = 13f;
            rootWord = word;
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value
            });

            word = "13th";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "thirteenth";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "thirteenths";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "fourteen";
            value = 14f;
            rootWord = word;
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value
            });

            word = "14th";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "fourteenth";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "fourteenths";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "fifteen";
            value = 15f;
            rootWord = word;
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value
            });

            word = "15th";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "fifteenth";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

			word = "fifteenths";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });
			
            word = "sixteen";
            value = 16f;
            rootWord = word;
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value
            });

            word = "16th";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "sixteenth";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "sixteenths";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });			
			
            word = "seventeen";
            value = 17f;
            rootWord = word;
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value
            });

            word = "17th";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "seventeenth";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "seventeenths";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });			
			
            word = "eighteen";
            value = 18f;
            rootWord = word;
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value
            });

            word = "18th";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "eighteenth";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

			word = "eighteenths";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });
			
            word = "nineteen";
            value = 19f;
            rootWord = word;
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value
            });

            word = "19th";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "nineteenth";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

			word = "nineteenths";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });
			
            //20 - 80
            word = "twenty";
            value = 20f;
            rootWord = word;
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value
            });

            word = "20th";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "twentieth";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

			word = "twentieths";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });
			
            word = "thirty";
            value = 30f;
            rootWord = word;
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value
            });

            word = "30th";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "thirtieth";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "thirtieths";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });			
			
            word = "forty";
            value = 40f;
            rootWord = word;
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value
            });

            word = "40th";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "fortieth";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "fortieths";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });			
			
            word = "fifty";
            value = 50f;
            rootWord = word;
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value
            });

            word = "50th";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "fiftieth";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "fiftieths";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });			
			
            word = "sixty";
            value = 60f;
            rootWord = word;
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value
            });

            word = "60th";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "sixtieth";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "sixtieths";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });			
			
            word = "seventy";
            value = 70f;
            rootWord = word;
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value
            });

            word = "70th";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "seventieth";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

			word = "seventieths";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });
			
            word = "eighty";
            value = 80f;
            rootWord = word;
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value
            });

            word = "80th";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "eightieth";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

			word = "eightieths";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });
			
            word = "ninety";
            value = 90f;
            rootWord = word;
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value
            });

            word = "90th";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "ninetieth";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "ninetieths";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });			
			
            //>= 100


            //word = "";
            /*     	
              	 		 	  		 	  	  			  		 	
 	 		 	 	
            */


        }
    }
}
/*
            word = "";
            value = f;
            rootWord = word;
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Cardinal,
                RepresentedNumber = value
            });

            word = "";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            });

            word = "";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord
            }); 
*/

/*
https://en.wikipedia.org/wiki/English_numerals


In English, the hundreds are perfectly regular, except that the word hundred remains in its singular form regardless of the number preceding it.

    100 	hundred 100th hundredth hundredths
    ×100 	..... 	hundredfold

    1000 thousand 1000th thousandth thousandths

    1000000 myriad

    1000000 million  1000000th millionth millionths



1,000,000,000 	109 	one billion
a thousand million 	one milliard
a thousand million 	one hundred crore
(one arab)
1,000,000,000,000 	1012 	one trillion
a thousand billion 	one billion
a million million 	one lakh crore
(ten kharab)
1,000,000,000,000,000 	1015 	one quadrillion
a thousand trillion 	one billiard
a thousand billion 	ten crore crore
(one padm)
1,000,000,000,000,000,000 	1018 	one quintillion
a thousand quadrillion 	one trillion
a million billion 	ten thousand crore crore
(ten shankh)
1,000,000,000,000,000,000,000 	1021 	one sextillion
a thousand quintillion 	one trilliard
a thousand trillion 	one crore crore crore 

A few numbers have special names (in addition to their regular names):
          
    10,000: a  (a hundred hundred), commonly used in the sense of an indefinite very high number
    10100: googol (1 followed by 100 zeros), used in mathematics
    10googol: googolplex (1 followed by a googol of zeros)
    10googolplex: googolplexplex (1 followed by a googolplex of zeros)

Compare these specialist multiplicative numbers to express how many times some thing exists (adjectives):
	
0.5 	half

 
*/
