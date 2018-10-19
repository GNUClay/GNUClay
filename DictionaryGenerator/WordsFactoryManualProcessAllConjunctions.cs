using System;
using System.Collections.Generic;
using System.Text;

namespace DictionaryGenerator
{
    public partial class WordsFactory
    {
        private void ProcessAllConjunctions()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessAllConjunctions");
#endif
        }
    }
}

/*
http://www.smart-words.org/linking-words/conjunctions.html

Coordinating Conjunctions:
And, but, for, nor, or, so, yet

Subordinating Conjunctions:


Conjunctions Concession

    though
    although
    even though
    while

Conjunctions Condition

    if
    only if
    unless
    until
    provided that
    assuming that
    even if
    in case (that)
    lest

Conjunctions Comparison

    than
    rather than
    whether
    as much as
    whereas

Conjunctions Time

    after
    as long as
    as soon as
    before
    by the time
    now that
    once
    since
    till
    until
    when
    whenever
    while

 

Conjunctions Reason

    because
    since
    so that
    in order (that)
    why

Relative Adjective

    that
    what
    whatever
    which
    whichever
     

Relative Pronoun

    who
    whoever
    whom
    whomever
    whose
     
     

Conjunctions Manner

    how
    as though
    as if

Conjunctions Place

    where
    wherever


Correlative Conjunctions:


    as . . . as
    just as . . . so
    both . . . and
    hardly . . . when
    scarcely . . . when

    either . . . or
    neither . . . nor
     
    if . . . then
    not . . . but

    what with . . . and
    whether . . . or
    not only . . . but also
    no sooner . . . than
    rather . . . than


*/