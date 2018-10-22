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
            word = "noughth";
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

            //21 - 99

            //>= 100
        }
    }
}

/*
https://en.wikipedia.org/wiki/English_numerals

    Cardinal numbers

Cardinal numbers refer to the size of a group. In English, these words are numerals.
        	10 	ten 	  	 
1 	one 	11 	eleven 	  	 
2 	two 	12 	twelve (a dozen) 	20 	twenty (a score)
3 	three 	13 	thirteen 	30 	thirty
4 	four 	14 	fourteen 	40 	forty (no "u")
5 	five 	15 	fifteen (note "f", not "v") 	50 	fifty (note "f", not "v")
6 	six 	16 	sixteen 	60 	sixty
7 	seven 	17 	seventeen 	70 	seventy
8 	eight 	18 	eighteen (only one "t") 	80 	eighty (only one "t")
9 	nine 	19 	nineteen 	90 	ninety (note the "e")

If a number is in the range 21 to 99, and the second digit is not zero, one typically writes the number as two words separated by a hyphen.
21 	twenty-one
25 	twenty-five
32 	thirty-two
58 	fifty-eight
64 	sixty-four
79 	seventy-nine
83 	eighty-three
99 	ninety-nine

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

Specialized numbers
See also: Number prefix § Table of number prefixes in English, and Anniversary § Anniversary names

A few numbers have special names (in addition to their regular names):

    1:
        ace in certain sports and games, as in tennis or golf, indicating success with one stroke, and the face of a die, playing card or domino half with one pip
        birdie in golf denotes one stroke less than par, and bogey, one stroke more than par
        solo
        unit
        linear the degree of a polynomial is 1; also for explicitly denoting the first power of a unit: linear meter
        unity in mathematics
        protagonist first actor in theater of Ancient Greece
    2:
        couple
        brace, from Old French "arms" (the plural of arm), as in "what can be held in two arms".
        pair
        deuce the face of a die, playing card or domino half with two pips
        eagle in golf denotes two strokes less than par
        duo
        quadratic the degree of a polynomial is 2
            also square or squared for denoting the second power of a unit: square meter or meter squared
        penultimate, second from the end
        deuteragonist second actor in theater of Ancient Greece
    3:
        trey the face of a die or playing card with three pips, a three-point field goal in basketball, nickname for the third carrier of the same personal name in a family
        trio
        trips: three-of-a-kind in a poker hand. a player has three cards with the same numerical value
        cubic the degree of a polynomial is 3
            also cube or cubed for denoting the third power of a unit: cubic meter or meter cubed
        albatross in golf denotes three strokes less than par. Sometimes called double eagle
        hat-trick or hat trick: achievement of three feats in sport or other contexts[4]
        antepenultimate third from the end
        tritagonist third actor in theater of Ancient Greece
        turkey in bowling, three consecutive strikes
    4:
        cater: (rare) the face of a die or playing card with four pips
        quartet
        quartic or biquadratic the degree of a polynomial is 4
        quad (short for quadruple or the like) several specialized sets of four, such as four of a kind in poker, a carburetor with four inputs, etc.,
        condor in golf denotes four strokes less than par
        preantepenultimate fourth from the end
    5:
        cinque or cinq (rare) the face of a die or playing card with five pips
        quintet
        nickel (informal American, from the value of the five-cent US nickel, but applied in non-monetary references)
        quintic the degree of a polynomial is 5
        quint (short for quintuplet or the like) several specialized sets of five, such as quintuplets, etc.
    6:
        half a dozen
        sice (rare) the face of a die or playing card with six pips
        sextet
        sextic or hectic the degree of a polynomial is 6
    7:
        septet
        septic or heptic the degree of a polynomial is 7
    8:
        octet
    9:
        nonet
    10:
        dime (informal American, from the value of the ten-cent US dime, but applied in non-monetary references)
        decet
        decade, used for years but also other groups of 10 as in rosary prayers or Braille symbols
    12: a dozen (first power of the duodecimal base), used mostly in commerce
    13: a baker's dozen
    20: a score (first power of the vigesimal base), nowadays archaic; famously used in the opening of the Gettysburg Address: "Four score and seven years ago..." The Number of the Beast in the King James Bible is rendered "Six hundred threescore and six". Also in The Book of Common Prayer, Psalm 90 as used in the Burial Service - "The days of our age are threescore years and ten; ...."
    50: half-century, literally half of a hundred, usually used in cricket scores.
    60: a shock: historical commercial count, described as "three scores".[5]
    100:
        A century, also used in cricket scores and in cycling for 100 miles.
        A ton, in Commonwealth English, the speed of 100 mph[6] or 100 km/h.
        A small hundred or short hundred (archaic, see 120 below)
    120:
        A great hundred or long hundred (twelve tens; as opposed to the small hundred, i.e. 100 or ten tens), also called small gross (ten dozens), both archaic
        Also sometimes referred to as duodecimal hundred, although that could literally also mean 144, which is twelve squared
    144: a gross (a dozen dozens, second power of the duodecimal base), used mostly in commerce
    1000:
        a grand, colloquially used especially when referring to money, also in fractions and multiples, e.g. half a grand, two grand, etc. Grand can also be shortened to "G" in many cases.
        K, originally from the abbreviation of kilo-, e.g. "He only makes $20K a year."
        Millennium (plural: millennia), a period of one thousand years.
        kilo- (Greek for "one thousand"), a decimal unit prefix in the Metric system denoting multiplication by "one thousand". For example: 1 Kilometer = 1000 meters.
    1728: a great gross (a dozen gross, third power of the duodecimal base), used historically in commerce
    10,000: a myriad (a hundred hundred), commonly used in the sense of an indefinite very high number
    100,000: a lakh (a hundred thousand), in Indian English
    10,000,000: a crore (a hundred lakh), in Indian English and written as 100,00,000.
    10100: googol (1 followed by 100 zeros), used in mathematics
    10googol: googolplex (1 followed by a googol of zeros)
    10googolplex: googolplexplex (1 followed by a googolplex of zeros)

Combinations of numbers in most sports scores are read as in the following examples:

    1–0    British English: one-nil; American English: one-nothing, one-zip, or one-zero
    0–0    British English: nil-nil or nil all; American English: zero-zero or nothing-nothing, (occasionally scoreless or no score)
    2–2    two-two or two all; American English also twos, two to two, even at two, or two up.

Naming conventions of Tennis scores (and related sports) are different from other sports.

The centuries of Italian culture have names in English borrowed from Italian:

    duecento "(one thousand and) two hundred" for the years 1200 to 1299, or approximately 13th century
    trecento 14th century
    quattrocento 15th century
    cinquecento 16th century
    seicento 17th century
    settecento 18th century
    ottocento 19th century
    novecento 20th century

    Multiplicative adverbs

A few numbers have specialised multiplicative numbers (adverbs) which express how many times some event happens:
one time 	once
two times 	twice
three times 	thrice
(largely obsolete)

Compare these specialist multiplicative numbers to express how many times some thing exists (adjectives):
× 1 	solitary 	singular 	one-off
× 2 	double 	twofold 	duplicate
× 3 	triple 	threefold 	triplicate
× 4 	quadruple 	fourfold 	
× 5 	quintuple 	fivefold 	
× 6 	sextuple, hextuple 	sixfold 	
× 7 	septuple, heptuple 	sevenfold 	
×100 	..... 	hundredfold 	

    Ordinal numbers
See also: Numbering of storeys in buildings

Ordinal numbers refer to a position in a series. Common ordinals include:
            	10th 	tenth 	  	 
1st 	first 	11th 	eleventh 	  	 
2nd 	second 	12th 	twelfth (note "f", not "v") 	20th 	twentieth
3rd 	third 	13th 	thirteenth 	30th 	thirtieth
4th 	fourth 	14th 	fourteenth 	40th 	fortieth
5th 	fifth 	15th 	fifteenth 	50th 	fiftieth
6th 	sixth 	16th 	sixteenth 	60th 	sixtieth
7th 	seventh 	17th 	seventeenth 	70th 	seventieth
8th 	eighth (only one "t") 	18th 	eighteenth 	80th 	eightieth
9th 	ninth (no "e") 	19th 	nineteenth 	90th 	ninetieth

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
