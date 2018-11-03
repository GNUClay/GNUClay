using MyNPCLib.NLToCGParsing;
using MyNPCLib.SimpleWordsDict;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToDoTransNodeAction(ATNFToDoTransNode_v2 item);

    public class ATNFToDoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToDoTransNodeFactory_v2(ATNInitNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToDoTransNodeFactory_v2(ATNFToDoTransNode_v2 sameNode, ATNExtendedToken token, InitATNFToDoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNInitNode_v2 mParentNode;
        private ATNFToDoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToDoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToDoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToDoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    FToDo_Subj_Trans
    FToDo_Not_Trans
*/

    public class ATNFToDoTransNode_v2: BaseATNNode_v2
    {
        public ATNFToDoTransNode_v2(ContextOfATNParsing_v2 context, ATNInitNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToDoTransNode_v2(ContextOfATNParsing_v2 context, ATNFToDoTransNode_v2 sameNode, InitATNFToDoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToDo_Trans;

        public ATNInitNode_v2 ParentNode { get; private set; }
        private ATNFToDoTransNode_v2 mSameNode;
        private InitATNFToDoTransNodeAction mInitAction;

        protected override void ImplementGoalToken()
        {
#if DEBUG
            LogInstance.Log($"Token = {Token}");
            LogInstance.Log($"Context = {Context}");
#endif

            Sentence.Aspect = GrammaticalAspect.Simple;
            Sentence.Tense = Token.Tense;
            Sentence.Voice = GrammaticalVoice.Active;
            Sentence.Modal = KindOfModal.None;
            Sentence.Mood = GrammaticalMood.Undefined;
            Sentence.IsQuestion = true;
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
                        AddTask(new ATNFToDoSubjTransNodeFactory_v2(this, item));
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(nameof(kindOfItem), kindOfItem, null);
                }
            }
        }
    }
}

