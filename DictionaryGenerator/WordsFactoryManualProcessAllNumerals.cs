﻿using MyNPCLib.SimpleWordsDict;
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

            //word = "";
            /*     	
	          		        

            */

            //11 - 20

            //>= 100
        }
    }
}

/*
https://en.wikipedia.org/wiki/English_numerals

    Cardinal numbers

        	10 	ten 	  	 
    	 	11 	eleven 	  	 
 	     	12 	twelve (a dozen) 	20 	twenty (a score)
    	 	13 	thirteen 	30 	thirty
    	 	14 	fourteen 	40 	forty (no "u")
      	 	15 	fifteen (note "f", not "v") 	50 	fifty (note "f", not "v")
    	  	16 	sixteen 	60 	sixty
    	 	17 	seventeen 	70 	seventy
    	 	18 	eighteen (only one "t") 	80 	eighty (only one "t")
    	 	19 	nineteen 	90 	ninety (note the "e")

In English, the hundreds are perfectly regular, except that the word hundred remains in its singular form regardless of the number preceding it.
100 	one hundred
200 	two hundred
… 	…
900 	nine hundred

So too are the thousands, with the number of thousands followed by the word "thousand".
1,000 	one thousand
2,000 	two thousand
… 	…
10,000 	ten thousand or (rarely used) a myriad, which usually means an indefinitely large number.
11,000 	eleven thousand
… 	…
20,000 	twenty thousand
21,000 	twenty-one thousand
30,000 	thirty thousand
85,000 	eighty-five thousand
100,000 	one hundred thousand or one lakh (Indian English)
999,000 	nine hundred and ninety-nine thousand (inclusively British English, Irish English, Australian English, and New Zealand English)
nine hundred ninety-nine thousand (American English)
1,000,000 	one million
10,000,000 	ten million or one crore (Indian English)

Number notation 	Power
notation 	Short scale 	Long scale 	Indian
(or South Asian) English
1,000,000 	106 	one million 	one million 	ten lakh
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
          
    10:
        dime (informal American, from the value of the ten-cent US dime, but applied in non-monetary references)
        decet
        decade, used for years but also other groups of 10 as in rosary prayers or Braille symbols
    12: a dozen (first power of the duodecimal base), used mostly in commerce

    10,000: a myriad (a hundred hundred), commonly used in the sense of an indefinite very high number
    10100: googol (1 followed by 100 zeros), used in mathematics
    10googol: googolplex (1 followed by a googol of zeros)
    10googolplex: googolplexplex (1 followed by a googolplex of zeros)

Compare these specialist multiplicative numbers to express how many times some thing exists (adjectives):
	
×100 	..... 	hundredfold 	

    Ordinal numbers

Ordinal numbers refer to a position in a series. Common ordinals include:
            	10th 	tenth 	  	 
 	        	11th 	eleventh 	  	 
 	        	12th 	twelfth (note "f", not "v") 	20th 	twentieth
 	        	13th 	thirteenth 	30th 	thirtieth
            	14th 	fourteenth 	40th 	fortieth
 	            15th 	fifteenth 	50th 	fiftieth
            	16th 	sixteenth 	60th 	sixtieth
            	17th 	seventeenth 	70th 	seventieth
            	18th 	eighteenth 	80th 	eightieth
            	19th 	nineteenth 	90th 	ninetieth
 
*/
