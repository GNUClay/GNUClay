using MyNPCLib.SimpleWordsDict;
using System;
using System.Collections.Generic;
using System.Text;

namespace DictionaryGenerator
{
    public partial class WordsFactory
    {
        private void ProcessAllPrepositions()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessAllPrepositions");
#endif

            var wordName = "to";
            mWordsDictData.WordsDict[wordName] = new WordFrame()
            {
                Word = wordName,
                GrammaticalWordFrames = new List<BaseGrammaticalWordFrame>()
                {
                    new PrepositionGrammaticalWordFrame()
                }
            };
        }
    }
}

/*
https://en.wikipedia.org/wiki/List_of_English_prepositions

Some single words

Prepositions

    aboard
    about
    above
    absent (law)
    across
        cross (archaic)
    after
    against
        'gainst, gainst (poetic or archaic); again, gain (archaic)
    along
        'long (abbreviation), alongst (archaic)
    alongside
    amid
        amidst, mid, midst (poetic or archaic);
    among
        amongst (in US English poetic or archaic)
        'mong, mong, 'mongst (abbreviations)
    apropos (rare for apropos of)
    apud (formal)
    around
        'round, round (abbreviations)
    as
    astride
    at
        @ (abbreviation)
    atop, ontop
    bar
    before
        afore, tofore (dialectal or archaic)
        B4 (abbreviation)
    behind
        ahind (dialectal or archaic)
    below
        ablow, allow (Scotland)
    beneath
        'neath, neath (poetic)
    beside
    besides
    between
        atween (dialectal or archaic)
    beyond
        ayond (dialectal or archaic)
    but
    by
    chez (rare)
    circa
        c., ca. (abbreviations)
    come
    dehors (law)
    despite
        spite (abbreviation)
    down
    during
    except
    for
        4 (abbreviation)
    from
    in
    inside
    into
    less
    like
    minus
    near
        nearer (comparative), nearest (superlative)
        anear (archaic)
    notwithstanding (also postpositional)
    of
        o' (poetic or eye-dialect)
    off
    on
    onto
    opposite
    out
        outen (archaic or dialectal)
    outside
    over
        o'er (poetic)
    pace (formal)
    past
    per
    plus
    post (often hyphenated)
    pre (often hyphenated)
    pro (often hyphenated)
    qua (formal)
    re (often used with colon)
    sans (formal)
    save
        sauf (archaic)
    short
    since
        sithence (archaic)
    than
    through
        thru (abbreviation)
    throughout
        thruout (abbreviation)
    till
    to
        2 (abbreviation)
    toward, towards
    under
    underneath
    unlike
    until
        'til, til (abbreviations)
    unto
    up
    upon
        'pon, pon (abbreviations)
    upside
    versus
        vs., v. (abbreviations)
    via
    vice (formal)
    vis-à-vis (formal)
    with
        w/, wi', c̄ (abbreviations)
    within
        w/i (abbreviation)
    without
        w/o (abbreviation)
    worth

Multiple words
Two words

    according to
    across from
    adjacent to
    ahead of
    along with
    apart from
    as for
    as of
    as per
    as regards
    aside from
    back to
    because of
    close to
    counter to
    down on
    due to
    except for
    far from
    inside of
    instead of
    left of
    near to
    next to
    opposite of
    opposite to
    other than
    out from
    out of
    outside of
    owing to
    prior to
    pursuant to
    rather than
    regardless of
    right of
    subsequent to
    such as
    thanks to
    up to

Three words

    as far as is one example of the many expressions which can be analyzed as as+adjective+as rather than a multiword preposition
    as opposed to
    as soon as
    as well as

Preposition + (article) + noun + preposition

English has many idiomatic expressions that act as prepositions that can be analyzed as a preposition followed by a noun (sometimes preceded by the definite or, occasionally, indefinite article) followed by another preposition.[1] Common examples include:

    at the behest of
    by means of
    by virtue of
    for the sake of
    for lack of
    for want of
    in accordance with
    in addition to
    in case of
    in front of
    in lieu of
    in place of
    in point of
    in spite of
    on account of
    on behalf of
    on top of
    with regard to (sometimes written as "w/r/t")
    with respect to
    with a view to

Archaic or dialectal

See also archaic forms of modern prepositions listed above.

    abaft (nautical or archaic)
    abeam (nautical)
    aboon, abun, abune (dialectal)
    afront (dialectal or archaic)
    ajax (Polari)
    alongst
    aloof
    anenst, anent (rare, U.K. dialectal)
    athwart (nautical or archaic)
    atop, ontop
    behither
    ben (dialectal)
    betwixt, atwix (dialectal or archaic)
        'twixt, twixt (abbreviations)
    bewest (dialectal or archaic)
    benorth (dialectal or archaic)
    emforth
    ere (poetic or archaic)
        or
    forby (dialectal or archaic)
    foreanent, forenenst (dialectal or archaic)
    foregain, foregainst (dialectal or archaic)
    forth
    fromward, froward, fromwards
    furth (Scotland)
    gainward
    imell (dialectal or archaic)
    inmid, inmiddes
    mang (Devon)
    mauger, maugre
    nearhand (archaic or dialectal)
    next (archaic for next to; originally superlative of nigh)
    nigh, anigh, anighst (poetic or archaic)
    outwith (dialectal)
    overthwart (archaic or dialectal)
    [[wikt:quoad#Preposition|quoad]] (formal; a Latin term)
    umbe, umb, um (archaic or dialectal)
    unto (archaic or poetic)
    uptill

Postpositions

    ago
    apart
    aside
        aslant (archaic)
    away
    hence
    notwithstanding (also prepositional)
    on
    short (also prepositional)
    through
    withal (archaic) 
*/
