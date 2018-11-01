using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjWillFToHaveV3NoTransNodeAction(ATNConditionQWSubjWillFToHaveV3NoTransNode_v2 item);

    public class ATNConditionQWSubjWillFToHaveV3NoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjWillFToHaveV3NoTransNodeFactory_v2(ATNConditionQWSubjWillFToHaveV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjWillFToHaveV3NoTransNodeFactory_v2(ATNConditionQWSubjWillFToHaveV3NoTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjWillFToHaveV3NoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjWillFToHaveV3TransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjWillFToHaveV3NoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjWillFToHaveV3NoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjWillFToHaveV3NoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjWillFToHaveV3NoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_Will_FToHave_V3_No_Obj_TransOrFin
*/

    public class ATNConditionQWSubjWillFToHaveV3NoTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjWillFToHaveV3NoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillFToHaveV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjWillFToHaveV3NoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillFToHaveV3NoTransNode_v2 sameNode, InitATNConditionQWSubjWillFToHaveV3NoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_Will_FToHave_V3_No_Trans;

        public ATNConditionQWSubjWillFToHaveV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjWillFToHaveV3NoTransNode_v2 mSameNode;
        private InitATNConditionQWSubjWillFToHaveV3NoTransNodeAction mInitAction;

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

