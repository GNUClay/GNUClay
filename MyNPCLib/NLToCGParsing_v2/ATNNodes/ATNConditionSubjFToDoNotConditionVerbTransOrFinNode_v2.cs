using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToDoNotConditionVerbTransOrFinNodeAction(ATNConditionSubjFToDoNotConditionVerbTransOrFinNode_v2 item);

    public class ATNConditionSubjFToDoNotConditionVerbTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToDoNotConditionVerbTransOrFinNodeFactory_v2(ATNConditionSubjFToDoNotConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToDoNotConditionVerbTransOrFinNodeFactory_v2(ATNConditionSubjFToDoNotConditionVerbTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToDoNotConditionVerbTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToDoNotConditionTransNode_v2 mParentNode;
        private ATNConditionSubjFToDoNotConditionVerbTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToDoNotConditionVerbTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToDoNotConditionVerbTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToDoNotConditionVerbTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_FToDo_Not_Condition_Verb_Obj_TransOrFin
    Condition_Subj_FToDo_Not_Condition_Verb_Condition_Fin
*/

    public class ATNConditionSubjFToDoNotConditionVerbTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToDoNotConditionVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToDoNotConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToDoNotConditionVerbTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToDoNotConditionVerbTransOrFinNode_v2 sameNode, InitATNConditionSubjFToDoNotConditionVerbTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToDo_Not_Condition_Verb_TransOrFin;

        public ATNConditionSubjFToDoNotConditionTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToDoNotConditionVerbTransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjFToDoNotConditionVerbTransOrFinNodeAction mInitAction;

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

