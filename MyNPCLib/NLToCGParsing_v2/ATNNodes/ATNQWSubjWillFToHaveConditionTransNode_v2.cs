using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjWillFToHaveConditionTransNodeAction(ATNQWSubjWillFToHaveConditionTransNode_v2 item);

    public class ATNQWSubjWillFToHaveConditionTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjWillFToHaveConditionTransNodeFactory_v2(ATNQWSubjWillFToHaveTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjWillFToHaveConditionTransNodeFactory_v2(ATNQWSubjWillFToHaveConditionTransNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjWillFToHaveConditionTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjWillFToHaveTransNode_v2 mParentNode;
        private ATNQWSubjWillFToHaveConditionTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjWillFToHaveConditionTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjWillFToHaveConditionTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjWillFToHaveConditionTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    QWSubj_Will_FToHave_Condition_V3_TransOrFin
*/

    public class ATNQWSubjWillFToHaveConditionTransNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjWillFToHaveConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillFToHaveTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjWillFToHaveConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillFToHaveConditionTransNode_v2 sameNode, InitATNQWSubjWillFToHaveConditionTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_Will_FToHave_Condition_Trans;

        public ATNQWSubjWillFToHaveTransNode_v2 ParentNode { get; private set; }
        private ATNQWSubjWillFToHaveConditionTransNode_v2 mSameNode;
        private InitATNQWSubjWillFToHaveConditionTransNodeAction mInitAction;

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

