using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToDoNotConditionVerbTransOrFinNodeAction(ATNSubjFToDoNotConditionVerbTransOrFinNode_v2 item);

    public class ATNSubjFToDoNotConditionVerbTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToDoNotConditionVerbTransOrFinNodeFactory_v2(ATNSubjFToDoNotConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToDoNotConditionVerbTransOrFinNodeFactory_v2(ATNSubjFToDoNotConditionVerbTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToDoNotConditionVerbTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToDoNotConditionTransNode_v2 mParentNode;
        private ATNSubjFToDoNotConditionVerbTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToDoNotConditionVerbTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToDoNotConditionVerbTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToDoNotConditionVerbTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_FToDo_Not_Condition_Verb_Obj_TransOrFin
    Subj_FToDo_Not_Condition_Verb_Condition_Fin
*/

    public class ATNSubjFToDoNotConditionVerbTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToDoNotConditionVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToDoNotConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToDoNotConditionVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToDoNotConditionVerbTransOrFinNode_v2 sameNode, InitATNSubjFToDoNotConditionVerbTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToDo_Not_Condition_Verb_TransOrFin;

        public ATNSubjFToDoNotConditionTransNode_v2 ParentNode { get; private set; }
        private ATNSubjFToDoNotConditionVerbTransOrFinNode_v2 mSameNode;
        private InitATNSubjFToDoNotConditionVerbTransOrFinNodeAction mInitAction;

        protected override void ImplementGoalToken()
        {
            throw new NotImplementedException();
        }

        protected override void ProcessNextToken()
        {
            throw new NotImplementedException();
        }
    }
}

