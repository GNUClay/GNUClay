using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWObjFToBeSubjConditionV3TransOrFinNodeAction(ATNConditionQWObjFToBeSubjConditionV3TransOrFinNode_v2 item);

    public class ATNConditionQWObjFToBeSubjConditionV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWObjFToBeSubjConditionV3TransOrFinNodeFactory_v2(ATNConditionQWObjFToBeSubjConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWObjFToBeSubjConditionV3TransOrFinNodeFactory_v2(ATNConditionQWObjFToBeSubjConditionV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWObjFToBeSubjConditionV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWObjFToBeSubjConditionTransNode_v2 mParentNode;
        private ATNConditionQWObjFToBeSubjConditionV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWObjFToBeSubjConditionV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWObjFToBeSubjConditionV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWObjFToBeSubjConditionV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWObj_FToBe_Subj_Condition_V3_Condition_Fin
*/

    public class ATNConditionQWObjFToBeSubjConditionV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWObjFToBeSubjConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjFToBeSubjConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWObjFToBeSubjConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjFToBeSubjConditionV3TransOrFinNode_v2 sameNode, InitATNConditionQWObjFToBeSubjConditionV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWObj_FToBe_Subj_Condition_V3_TransOrFin;

        public ATNConditionQWObjFToBeSubjConditionTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWObjFToBeSubjConditionV3TransOrFinNode_v2 mSameNode;
        private InitATNConditionQWObjFToBeSubjConditionV3TransOrFinNodeAction mInitAction;

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

