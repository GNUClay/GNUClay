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
        }
    }
}

/*
https://en.wikipedia.org/wiki/Pronoun

<table class="wikitable">
<tbody><tr>
<th>Subject
</th>
<th>Object
</th>
<th>Possessive
</th>
<th>Reflexive
</th></tr>
<tr>
<td>I
</td>
<td>me
</td>
<td>my (determiner) / mine (pronoun)
</td>
<td>myself
</td></tr>
<tr>
<td>you
</td>
<td>you
</td>
<td>your (determiner) / yours (pronoun)
</td>
<td>yourself
</td></tr>
<tr>
<td>he
</td>
<td>him
</td>
<td>his
</td>
<td>himself
</td></tr>
<tr>
<td>she
</td>
<td>her
</td>
<td>her (determiner) / hers (pronoun)
</td>
<td>herself
</td></tr>
<tr>
<td>it
</td>
<td>it
</td>
<td>its
</td>
<td>itself
</td></tr>
<tr>
<td>we
</td>
<td>us
</td>
<td>our (determiner) / ours (pronoun)
</td>
<td>ourselves
</td></tr>
<tr>
<td>you
</td>
<td>you
</td>
<td>your (determiner) / yours (pronoun)
</td>
<td>yourselves
</td></tr>
<tr>
<td>they
</td>
<td>them
</td>
<td>their (determiner) / theirs (pronoun)
</td>
<td>themselves
</td></tr></tbody></table>

<table class="wikitable">
<tbody><tr>
<th>Demonstrative
</th>
<th>Relative
</th>
<th>Indefinite
</th>
<th>Interrogative
</th></tr>
<tr>
<td>this
</td>
<td>that
</td>
<td>something / anything / nothing (things)
</td>
<td>who
</td></tr>
<tr>
<td>these
</td>
<td>who/whom
</td>
<td>somewhere / anywhere / nowhere (places)
</td>
<td>what
</td></tr>
<tr>
<td>that
</td>
<td>which
</td>
<td>someone / anyone / no one (people)
</td>
<td>which
</td></tr>
<tr>
<td>those
</td>
<td>when
</td>
<td>
</td>
<td>whom
</td></tr>
<tr>
<td>former/latter
</td>
<td>where
</td>
<td>
</td>
<td>whose
</td></tr>
<tr>
<td>
</td>
<td>
</td>
<td>
</td>
<td>where (adverb/subordinate conjunction)
</td></tr>
<tr>
<td>
</td>
<td>
</td>
<td>
</td>
<td>when (adverb/subordinate conjunction)
</td></tr>
<tr>
<td>
</td>
<td>
</td>
<td>
</td>
<td>why (adverb/subordinate conjunction)
</td></tr>
<tr>
<td>
</td>
<td>
</td>
<td>
</td>
<td>how (adverb/subordinate conjunction)
</td></tr></tbody></table>
*/