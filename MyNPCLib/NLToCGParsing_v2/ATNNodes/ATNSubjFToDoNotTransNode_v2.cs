using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToDoNotTransNodeAction(ATNSubjFToDoNotTransNode_v2 item);

    public class ATNSubjFToDoNotTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToDoNotTransNodeFactory_v2(ATNSubjFToDoTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToDoNotTransNodeFactory_v2(ATNSubjFToDoNotTransNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToDoNotTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToDoTransNode_v2 mParentNode;
        private ATNSubjFToDoNotTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToDoNotTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToDoNotTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToDoNotTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_FToDo_Not_Verb_TransOrFin
    Subj_FToDo_Not_Condition_Trans
*/

    public class ATNSubjFToDoNotTransNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToDoNotTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToDoTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToDoNotTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToDoNotTransNode_v2 sameNode, InitATNSubjFToDoNotTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToDo_Not_Trans;

        public ATNSubjFToDoTransNode_v2 ParentNode { get; private set; }
        private ATNSubjFToDoNotTransNode_v2 mSameNode;
        private InitATNSubjFToDoNotTransNodeAction mInitAction;

        protected override void ImplementGoalToken()
        {
#if DEBUG
            LogInstance.Log($"Token = {Token}");
            LogInstance.Log($"Context = {Context}");
#endif

            Sentence.IsNegation = true;
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
                    case KindOfItemOfSentence.Verb:
                        AddTask(new ATNSubjFToDoNotVerbTransOrFinNodeFactory_v2(this, item));
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(nameof(kindOfItem), kindOfItem, null);
                }
            }
        }
    }
}

