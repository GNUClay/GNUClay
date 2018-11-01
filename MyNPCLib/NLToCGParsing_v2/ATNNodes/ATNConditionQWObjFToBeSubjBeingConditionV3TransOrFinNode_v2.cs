using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWObjFToBeSubjBeingConditionV3TransOrFinNodeAction(ATNConditionQWObjFToBeSubjBeingConditionV3TransOrFinNode_v2 item);

    public class ATNConditionQWObjFToBeSubjBeingConditionV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWObjFToBeSubjBeingConditionV3TransOrFinNodeFactory_v2(ATNConditionQWObjFToBeSubjBeingConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWObjFToBeSubjBeingConditionV3TransOrFinNodeFactory_v2(ATNConditionQWObjFToBeSubjBeingConditionV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWObjFToBeSubjBeingConditionV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWObjFToBeSubjBeingConditionTransNode_v2 mParentNode;
        private ATNConditionQWObjFToBeSubjBeingConditionV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWObjFToBeSubjBeingConditionV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWObjFToBeSubjBeingConditionV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWObjFToBeSubjBeingConditionV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWObj_FToBe_Subj_Being_Condition_V3_Condition_Fin
*/

    public class ATNConditionQWObjFToBeSubjBeingConditionV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWObjFToBeSubjBeingConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjFToBeSubjBeingConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWObjFToBeSubjBeingConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjFToBeSubjBeingConditionV3TransOrFinNode_v2 sameNode, InitATNConditionQWObjFToBeSubjBeingConditionV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWObj_FToBe_Subj_Being_Condition_V3_TransOrFin;

        public ATNConditionQWObjFToBeSubjBeingConditionTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWObjFToBeSubjBeingConditionV3TransOrFinNode_v2 mSameNode;
        private InitATNConditionQWObjFToBeSubjBeingConditionV3TransOrFinNodeAction mInitAction;

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

