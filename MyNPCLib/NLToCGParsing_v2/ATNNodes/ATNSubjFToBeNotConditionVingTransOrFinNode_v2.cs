using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToBeNotConditionVingTransOrFinNodeAction(ATNSubjFToBeNotConditionVingTransOrFinNode_v2 item);

    public class ATNSubjFToBeNotConditionVingTransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToBeNotConditionVingTransOrFinNodeFactory_v2(ATNSubjFToBeNotConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToBeNotConditionVingTransOrFinNodeFactory_v2(ATNSubjFToBeNotConditionVingTransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToBeNotConditionVingTransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToBeNotConditionTransNode_v2 mParentNode;
        private ATNSubjFToBeNotConditionVingTransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToBeNotConditionVingTransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToBeNotConditionVingTransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToBeNotConditionVingTransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_FToBe_Not_Condition_Ving_Obj_TransOrFin
    Subj_FToBe_Not_Condition_Ving_Condition_Fin
*/

    public class ATNSubjFToBeNotConditionVingTransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToBeNotConditionVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeNotConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToBeNotConditionVingTransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeNotConditionVingTransOrFinNode_v2 sameNode, InitATNSubjFToBeNotConditionVingTransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToBe_Not_Condition_Ving_TransOrFin;

        public ATNSubjFToBeNotConditionTransNode_v2 ParentNode { get; private set; }
        private ATNSubjFToBeNotConditionVingTransOrFinNode_v2 mSameNode;
        private InitATNSubjFToBeNotConditionVingTransOrFinNodeAction mInitAction;

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

