using MyNPCLib.NLToCGParsing;
using MyNPCLib.NLToCGParsing.PhraseTree;
using MyNPCLib.NLToCGParsing_v2.PhraseTree;
using MyNPCLib.SimpleWordsDict;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNVerbTransOrFinNodeAction(ATNVerbTransOrFinNode_v2 item);

    public class ATNVerbTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNVerbTransOrFinNodeFactory_v2(ATNInitNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNVerbTransOrFinNodeFactory_v2(ATNVerbTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNVerbTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNInitNode_v2 mParentNode;
        private ATNVerbTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNVerbTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNVerbTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNVerbTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Verb_Obj_TransOrFin
    Verb_No_Trans
    Verb_Condition_Fin
*/

    public class ATNVerbTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNInitNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNVerbTransOrFinNode_v2 sameNode, InitATNVerbTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Verb_TransOrFin;

        public ATNInitNode_v2 ParentNode { get; private set; }
        private ATNVerbTransOrFinNode_v2 mSameNode;
        private InitATNVerbTransOrFinNodeAction mInitAction;

        protected override void ImplementGoalToken()
        {
#if DEBUG
            LogInstance.Log($"Token = {Token}");
            LogInstance.Log($"Context = {Context}");
#endif

            var partOfSpeech = Token.PartOfSpeech;

            switch (partOfSpeech)
            {
                case GrammaticalPartOfSpeech.Verb:
                    {
                        var verbPhrase = new VerbPhrase_v2();
                        verbPhrase.Verb = Token;
                        Sentence.VerbPhrase = verbPhrase;
                        Sentence.Aspect = GrammaticalAspect.Simple;
                        Sentence.Tense = Token.Tense;
                        Sentence.Mood = GrammaticalMood.Imperative;
                        Sentence.Voice = GrammaticalVoice.Active;
                        Sentence.Modal = KindOfModal.None;
                    }
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(partOfSpeech), partOfSpeech, null);
            }
        }

        protected override void ProcessNextToken()
        {
            var extendedTokensList = Get—lusterOfExtendedTokens();

#if DEBUG
            LogInstance.Log($"extendedTokensList.Count = {extendedTokensList.Count}");
#endif

            if (extendedTokensList.Count == 0)
            {
                throw new NotImplementedException();
            }

            foreach (var item in extendedTokensList)
            {
#if DEBUG
                LogInstance.Log($"item = {item}");
#endif

                var kindOfItem = item.KindOfItem;

                switch (kindOfItem)
                {
                    case KindOfItemOfSentence.Subj:
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(nameof(kindOfItem), kindOfItem, null);
                }
            }
        }
    }
}

