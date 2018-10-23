using MyNPCLib.SimpleWordsDict;
using System;
using System.Collections.Generic;
using System.Text;

namespace DictionaryGenerator
{
    public partial class WordsFactory
    {
        private void ProcessAllComplexNumerals()
        {
            //1
            var word = "one-off";
            var value = 1f;
            var rootWord = "one";
            AddGrammaticalWordFrame(word, new NumeralGrammaticalWordFrame()
            {
                NumeralType = NumeralType.Ordinal,
                RepresentedNumber = value,
                RootWord = rootWord,
                LogicalMeaning = new List<string>()
                {
                    "multiplicating"
                }
            });

            //21 - 99

        }
    }
}

/*
            word = "";
            value = ;
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

Cardinal numbers
	
If a number is in the range 21 to 99, and the second digit is not zero, one typically writes the number as two words separated by a hyphen.
21 	twenty-one
25 	twenty-five
32 	thirty-two
58 	fifty-eight
64 	sixty-four
79 	seventy-nine
83 	eighty-three
99 	ninety-nine

Ordinal numbers such as 21st, 33rd, etc., are formed by combining a cardinal ten with an ordinal unit.
21st 	twenty-first
25th 	twenty-fifth
32nd 	thirty-second
58th 	fifty-eighth
64th 	sixty-fourth
79th 	seventy-ninth
83rd 	eighty-third
99th 	ninety-ninth
*/
