using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWObjFToBeSubjV3TransOrFinNodeAction(ATNConditionQWObjFToBeSubjV3TransOrFinNode_v2 item);

    public class ATNConditionQWObjFToBeSubjV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWObjFToBeSubjV3TransOrFinNodeFactory_v2(ATNConditionQWObjFToBeSubjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWObjFToBeSubjV3TransOrFinNodeFactory_v2(ATNConditionQWObjFToBeSubjV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWObjFToBeSubjV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWObjFToBeSubjTransNode_v2 mParentNode;
        private ATNConditionQWObjFToBeSubjV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWObjFToBeSubjV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWObjFToBeSubjV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWObjFToBeSubjV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWObj_FToBe_Subj_V3_Condition_Fin
*/

    public class ATNConditionQWObjFToBeSubjV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWObjFToBeSubjV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjFToBeSubjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWObjFToBeSubjV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjFToBeSubjV3TransOrFinNode_v2 sameNode, InitATNConditionQWObjFToBeSubjV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWObj_FToBe_Subj_V3_TransOrFin;

        public ATNConditionQWObjFToBeSubjTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWObjFToBeSubjV3TransOrFinNode_v2 mSameNode;
        private InitATNConditionQWObjFToBeSubjV3TransOrFinNodeAction mInitAction;

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

