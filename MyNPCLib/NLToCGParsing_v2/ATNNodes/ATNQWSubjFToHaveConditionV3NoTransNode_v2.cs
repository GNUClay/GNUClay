using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjFToHaveConditionV3NoTransNodeAction(ATNQWSubjFToHaveConditionV3NoTransNode_v2 item);

    public class ATNQWSubjFToHaveConditionV3NoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjFToHaveConditionV3NoTransNodeFactory_v2(ATNQWSubjFToHaveConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjFToHaveConditionV3NoTransNodeFactory_v2(ATNQWSubjFToHaveConditionV3NoTransNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjFToHaveConditionV3NoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjFToHaveConditionV3TransOrFinNode_v2 mParentNode;
        private ATNQWSubjFToHaveConditionV3NoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjFToHaveConditionV3NoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjFToHaveConditionV3NoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjFToHaveConditionV3NoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_FToHave_Condition_V3_No_Obj_TransOrFin
*/

    public class ATNQWSubjFToHaveConditionV3NoTransNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjFToHaveConditionV3NoTransNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToHaveConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjFToHaveConditionV3NoTransNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToHaveConditionV3NoTransNode_v2 sameNode, InitATNQWSubjFToHaveConditionV3NoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_FToHave_Condition_V3_No_Trans;

        public ATNQWSubjFToHaveConditionV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjFToHaveConditionV3NoTransNode_v2 mSameNode;
        private InitATNQWSubjFToHaveConditionV3NoTransNodeAction mInitAction;

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

