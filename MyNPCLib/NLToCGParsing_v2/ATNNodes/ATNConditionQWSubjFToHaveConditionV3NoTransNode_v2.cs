using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjFToHaveConditionV3NoTransNodeAction(ATNConditionQWSubjFToHaveConditionV3NoTransNode_v2 item);

    public class ATNConditionQWSubjFToHaveConditionV3NoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjFToHaveConditionV3NoTransNodeFactory_v2(ATNConditionQWSubjFToHaveConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjFToHaveConditionV3NoTransNodeFactory_v2(ATNConditionQWSubjFToHaveConditionV3NoTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjFToHaveConditionV3NoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjFToHaveConditionV3TransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjFToHaveConditionV3NoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjFToHaveConditionV3NoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjFToHaveConditionV3NoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjFToHaveConditionV3NoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_FToHave_Condition_V3_No_Obj_TransOrFin
*/

    public class ATNConditionQWSubjFToHaveConditionV3NoTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjFToHaveConditionV3NoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToHaveConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjFToHaveConditionV3NoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToHaveConditionV3NoTransNode_v2 sameNode, InitATNConditionQWSubjFToHaveConditionV3NoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_FToHave_Condition_V3_No_Trans;

        public ATNConditionQWSubjFToHaveConditionV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjFToHaveConditionV3NoTransNode_v2 mSameNode;
        private InitATNConditionQWSubjFToHaveConditionV3NoTransNodeAction mInitAction;

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

