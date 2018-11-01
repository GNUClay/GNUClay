using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToHaveConditionTransNodeAction(ATNConditionSubjFToHaveConditionTransNode_v2 item);

    public class ATNConditionSubjFToHaveConditionTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToHaveConditionTransNodeFactory_v2(ATNConditionSubjFToHaveTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToHaveConditionTransNodeFactory_v2(ATNConditionSubjFToHaveConditionTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToHaveConditionTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToHaveTransNode_v2 mParentNode;
        private ATNConditionSubjFToHaveConditionTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToHaveConditionTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToHaveConditionTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToHaveConditionTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_FToHave_Condition_V3_TransOrFin
*/

    public class ATNConditionSubjFToHaveConditionTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToHaveConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToHaveTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToHaveConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToHaveConditionTransNode_v2 sameNode, InitATNConditionSubjFToHaveConditionTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToHave_Condition_Trans;

        public ATNConditionSubjFToHaveTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToHaveConditionTransNode_v2 mSameNode;
        private InitATNConditionSubjFToHaveConditionTransNodeAction mInitAction;

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

