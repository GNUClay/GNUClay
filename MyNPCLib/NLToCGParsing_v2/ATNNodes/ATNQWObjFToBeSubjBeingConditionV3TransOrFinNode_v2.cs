using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWObjFToBeSubjBeingConditionV3TransOrFinNodeAction(ATNQWObjFToBeSubjBeingConditionV3TransOrFinNode_v2 item);

    public class ATNQWObjFToBeSubjBeingConditionV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWObjFToBeSubjBeingConditionV3TransOrFinNodeFactory_v2(ATNQWObjFToBeSubjBeingConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWObjFToBeSubjBeingConditionV3TransOrFinNodeFactory_v2(ATNQWObjFToBeSubjBeingConditionV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWObjFToBeSubjBeingConditionV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWObjFToBeSubjBeingConditionTransNode_v2 mParentNode;
        private ATNQWObjFToBeSubjBeingConditionV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWObjFToBeSubjBeingConditionV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWObjFToBeSubjBeingConditionV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWObjFToBeSubjBeingConditionV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWObj_FToBe_Subj_Being_Condition_V3_Condition_Fin
*/

    public class ATNQWObjFToBeSubjBeingConditionV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNQWObjFToBeSubjBeingConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjFToBeSubjBeingConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWObjFToBeSubjBeingConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjFToBeSubjBeingConditionV3TransOrFinNode_v2 sameNode, InitATNQWObjFToBeSubjBeingConditionV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWObj_FToBe_Subj_Being_Condition_V3_TransOrFin;

        public ATNQWObjFToBeSubjBeingConditionTransNode_v2 ParentNode { get; private set; }
        private ATNQWObjFToBeSubjBeingConditionV3TransOrFinNode_v2 mSameNode;
        private InitATNQWObjFToBeSubjBeingConditionV3TransOrFinNodeAction mInitAction;

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

