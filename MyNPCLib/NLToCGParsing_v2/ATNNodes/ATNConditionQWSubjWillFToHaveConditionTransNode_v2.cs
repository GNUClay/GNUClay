using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjWillFToHaveConditionTransNodeAction(ATNConditionQWSubjWillFToHaveConditionTransNode_v2 item);

    public class ATNConditionQWSubjWillFToHaveConditionTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjWillFToHaveConditionTransNodeFactory_v2(ATNConditionQWSubjWillFToHaveTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjWillFToHaveConditionTransNodeFactory_v2(ATNConditionQWSubjWillFToHaveConditionTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjWillFToHaveConditionTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjWillFToHaveTransNode_v2 mParentNode;
        private ATNConditionQWSubjWillFToHaveConditionTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjWillFToHaveConditionTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjWillFToHaveConditionTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjWillFToHaveConditionTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_Will_FToHave_Condition_V3_TransOrFin
*/

    public class ATNConditionQWSubjWillFToHaveConditionTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjWillFToHaveConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillFToHaveTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjWillFToHaveConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillFToHaveConditionTransNode_v2 sameNode, InitATNConditionQWSubjWillFToHaveConditionTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_Will_FToHave_Condition_Trans;

        public ATNConditionQWSubjWillFToHaveTransNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjWillFToHaveConditionTransNode_v2 mSameNode;
        private InitATNConditionQWSubjWillFToHaveConditionTransNodeAction mInitAction;

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

